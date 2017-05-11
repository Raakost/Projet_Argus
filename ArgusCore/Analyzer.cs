using ArgusEntities.Entities.Reddit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgusCore
{
    public class Analyzer : IObservable<Object>
    {
        private List<IObserver<Object>> observers = new List<IObserver<Object>>();
        private KeywordManager keywordMgr;

        List<ArgusChild> childrenFound;

        private static readonly Analyzer instance = new Analyzer();

        static Analyzer()
        {

        }
        private Analyzer()
        {
            childrenFound = new List<ArgusChild>();
            keywordMgr = KeywordManager.Instance;
        }
        public static Analyzer Instance
        {
            get
            {
                return instance;
            }
        }

        public void EvaluateInterset(ArgusReddit input)
        {
            List<ArgusChild> InterestPoints = new List<ArgusChild>();
            foreach (var child in input.data.children)
            {
                if (EvaluateString(child.data.title))
                {
                    // Is it already in our list?
                    bool containsItem = childrenFound.Any(item => item.data.id == child.data.id);
                    if (!containsItem)
                    {
                        childrenFound.Add(child);
                        InterestPoints.Add(child);
                    }
                }
            }
            if (InterestPoints.Count > 0)
            {
                Result(InterestPoints);
            }
        }

        private bool EvaluateString(string input)
        {
            bool result = false;

            foreach (var keyword in keywordMgr.ReadAll())
            {
                if (input.ToLower().Contains(keyword))
                {
                    return true;
                }
            }
            return result;
        }

        public void Result(Object e)
        {
            foreach (var observer in observers)
            {
                observer.OnNext(e);
            }
        }

        public IDisposable Subscribe(IObserver<object> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }
            return new Unsubscriber<Object>(observers, observer);
        }
    }
    internal class Unsubscriber<Object> : IDisposable
    {
        private List<IObserver<Object>> _observers;
        private IObserver<Object> _observer;

        internal Unsubscriber(List<IObserver<Object>> observers, IObserver<Object> observer)
        {
            this._observers = observers;
            this._observer = observer;
        }

        public void Dispose()
        {
            if (_observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }
}
