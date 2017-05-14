using ArgusCore.Gatherers.Utils;
using ArgusEntities.Entities.Reddit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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
            List<ArgusReddit> dataFound = new List<ArgusReddit>();
            // Run through all subReddits and look for new posts and urls of interest.
            foreach (var subreddit in subReddits)
            {
                var featuredPosts = GetSubredditPosts(subreddit, false);
                if(featuredPosts != null)
                {
                    dataFound.Add(featuredPosts);
                }
                var latestPosts = GetSubredditPosts(subreddit, true);
                if(latestPosts != null)
                {
                    dataFound.Add(latestPosts);
                }
            }
            analyzer.EvaluateInterset(dataFound);
        }
        private ArgusReddit GetSubredditPosts(string subreddit, bool getNew)
        {
            string fullUrl = redditStr + subreddit + jsonSuffix;
            if (getNew == true)
            {
                fullUrl = redditStr + subreddit + "/new/" + jsonSuffix;
            }
            return GetRedditData(fullUrl);
        }
        private ArgusReddit GetRedditData(string url)
        {
            var jsonData = webHandler.DownloadString(url);

            var data = (ArgusReddit)DeserializeJson<ArgusReddit>(jsonData);
            return data;
        }
        public bool IsSubredditValid(string subreddit)
        {
            string fullUrl = redditStr + subreddit + jsonSuffix;

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
