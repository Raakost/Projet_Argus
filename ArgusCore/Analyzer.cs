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
        private List<IObserver<Object>> observers;
        private List<string> Keywords;

        private static readonly Analyzer instance = new Analyzer();

        static Analyzer()
        {

        }
        private Analyzer()
        {
            // Load Keywords
            //Keywords = keyWordMgr.LoadKeyWords();
            observers = new List<IObserver<Object>>();
            Keywords = new List<string>();
            Keywords.Add("leak");
            Keywords.Add("shooting");
            Keywords.Add("killed");
            Keywords.Add("injured");
            Keywords.Add("airstrike");
            Keywords.Add("suicide");
            Keywords.Add("battle");
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
                    InterestPoints.Add(child);
                }
            }
            if(InterestPoints.Count > 0)
            {
                Result(InterestPoints);
            }
        }

        private bool EvaluateString(string input)
        {
            bool result = false;

            foreach (var keyword in Keywords)
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
