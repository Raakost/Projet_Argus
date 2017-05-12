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
        public void AddSubReddit(string subreddit)
        {
            subReddits.Add(subreddit);
            discOps.SaveToDisc<List<string>>(subReddits, subRedditFile);
        }
        public List<string> ReadAllSubReddits()
        {
            return subReddits;
        }
        public void DeleteSubreddit(string item)
        {
            subReddits.Remove(item);
            discOps.SaveToDisc<List<string>>(subReddits, subRedditFile);
        }
        public override void RunStrategy()
        {
            // Run through all subReddits and look for new posts and urls of interest.
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
            analyzer.EvaluateInterset(GetRedditData(fullUrl));
        }
        private ArgusReddit GetRedditData(string url)
        {
            var jsonData = webHandler.DownloadString(url);

            var data = (ArgusReddit)DeserializeJson<ArgusReddit>(jsonData);
            return data;
        }
        public bool IsSubredditValid(string subreddit)
        {
            string fullUrl = redditStr + subreddit +jsonSuffix;

            var data = GetRedditData(fullUrl);

            if (data.data.children.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
