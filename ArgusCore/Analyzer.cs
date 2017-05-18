using ArgusEntities.Entities.Reddit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgusCore
{
    // Implements the observeable pattern so it can send results to the GUI.
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
        // Returns a subreddit post by input title.
        public ArgusChild GetChildByTitle(string title)
        {
            ArgusChild selectedChild = childrenFound.Where(x => x.data.title == title).FirstOrDefault();
            return selectedChild;
        }
        public void EvaluateInterset(List<ArgusReddit> input)
        {
            List<ArgusChild> InterestPoints = new List<ArgusChild>();
            // Run through each subreddit
            foreach (var subreddit in input)
            {
                // Check every post in subreddit
                foreach (var child in subreddit.data.children)
                {
                    // Evaluate post title
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
            }
            if (InterestPoints.Count > 0)
            {
                Result(InterestPoints);
            }
        }

        private bool EvaluateString(string input)
        {
            bool result = false;

            // Run through each keyword in keyword database 
            foreach (var keyword in keywordMgr.ReadAll())
            {
                // If the input string contains a keyword a boolean true is returned.
                if (input.ToLower().Contains(keyword))
                {
                    return true;
                }
            }
            // If it has come this far the input string had no keywords
            // and is therefore not of interest.
            return result;
        }

        // Runs through each observer and gives it the result object (a reddit post in our case).
        public void Result(Object e)
        {
            foreach (var observer in observers)
            {
                observer.OnNext(e);
            }
        }

        // Adds the observer to our list of observers if it's not already in the list.
        public IDisposable Subscribe(IObserver<object> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }
            return new Unsubscriber<Object>(observers, observer);
        }
    }
    // https://msdn.microsoft.com/en-us/library/ee850490(v=vs.110).aspx
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
