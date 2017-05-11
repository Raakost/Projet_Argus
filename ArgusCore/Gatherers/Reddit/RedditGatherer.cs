using ArgusEntities.Entities.Reddit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ArgusCore.Gatherers.Reddit
{
    public class RedditGatherer : Gatherer
    {
        private string coreFolder = @"C:\Argus\";
        private string subRedditFile = "";

        private DiscOps discOps;

        private List<string> subReddits;
        private Analyzer analyzer = Analyzer.Instance;

        private System.Threading.Timer timer;

        private string redditStr = "https://reddit.com/r/";
        private string jsonSuffix = ".json";

        public RedditGatherer()
        {
            discOps = new DiscOps();

            subRedditFile = coreFolder + "SubReddits.json";
            if (File.Exists(subRedditFile))
            {
                subReddits = discOps.LoadFromDisc<List<string>>(subRedditFile);
            }
            else
            {
                discOps.EnsureFolderExists(coreFolder);
                subReddits = new List<string>();
                discOps.SaveToDisc<List<string>>(subReddits, subRedditFile);
            }
        }
        public void AddToList(string subreddit)
        {
            subReddits.Add(subreddit);
            discOps.SaveToDisc<List<string>>(subReddits, subRedditFile);
        }
        public List<string> ReadAll()
        {
            return subReddits;
        }
        public void Delete(string item)
        {
            subReddits.Remove(item);
            discOps.SaveToDisc<List<string>>(subReddits, subRedditFile);
        }
        public void Start(int sec)
        {
            // Start timer
            if (timer == null)
            {
                timer = new System.Threading.Timer(
                   e => RunStrategy(),
                   null,
                   TimeSpan.Zero,
                   TimeSpan.FromSeconds(sec));
            }
        }
        public void Stop()
        {
            // Stop timer
            timer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
        }
        private void RunStrategy()
        {
            // Run through all subReddits and look for new posts and urls of interest.
            ReallAllSubreddit();
        }
        private void ReallAllSubreddit()
        {
            foreach (var subreddit in subReddits)
            {
                HeadLines(subreddit, false);
                HeadLines(subreddit, true);
            }
        }
        private void HeadLines(string subreddit, bool getNew)
        {
            string fullUrl = redditStr + subreddit + jsonSuffix;
            if (getNew == true)
            {
                fullUrl = redditStr + subreddit + "/new/" + jsonSuffix;
            }
            var jsonData = webHandler.DownloadString(fullUrl);

            var data = (ArgusReddit)DeserializeJson<ArgusReddit>(jsonData);
            analyzer.EvaluateInterset(data);
        }
    }
}
