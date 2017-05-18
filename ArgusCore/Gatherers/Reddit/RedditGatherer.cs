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
        private string redditConfigFile = "";

        private DiscOps discOps;
        private WebHandler webHandler;

        private List<string> subReddits;
        private Analyzer analyzer = Analyzer.Instance;

        private string redditStr = "https://reddit.com/r/";
        private string jsonSuffix = ".json";

        public RedditGatherer()
        {
            discOps = new DiscOps();
            webHandler = new WebHandler();

            // Checks if config file exists, if it exists it is loaded from disc.
            
            redditConfigFile = coreFolder + "SubReddits.json";
            if (File.Exists(redditConfigFile))
            {
                subReddits = discOps.LoadFromDisc<List<string>>(redditConfigFile);
            }
            else
            {
                // If it doesn't exist creates the folder, then creates an empty subreddit list, finally it's saved.
                discOps.EnsureFolderExists(coreFolder);
                subReddits = new List<string>();
                discOps.SaveToDisc<List<string>>(subReddits, redditConfigFile);
            }
        }

        // Adds subreddit to list and saves the list to file.
        public void AddSubReddit(string subreddit)
        {
            subReddits.Add(subreddit);
            discOps.SaveToDisc<List<string>>(subReddits, redditConfigFile);
        }
        // Returns list of subreddits.
        public List<string> ReadAllSubReddits()
        {
            return subReddits;
        }
        // Deletes subreddit from list and saves the list to file.
        public void DeleteSubreddit(string item)
        {
            subReddits.Remove(item);
            discOps.SaveToDisc<List<string>>(subReddits, redditConfigFile);
        }
        // This is overridden RunStrategy from the abstract gatherer.
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
        // Gets subreddit posts from input string and get the "new" page of a subreddit if the bool input is true.
        private ArgusReddit GetSubredditPosts(string subreddit, bool getNew)
        {
            string fullUrl = redditStr + subreddit + jsonSuffix;
            if (getNew == true)
            {
                fullUrl = redditStr + subreddit + "/new/" + jsonSuffix;
            }
            return GetRedditData(fullUrl);
        }
        // Downloads subreddit json string and parses it to a POCO
        private ArgusReddit GetRedditData(string url)
        {
            var jsonData = webHandler.DownloadString(url);

            var data = (ArgusReddit)DeserializeJson<ArgusReddit>(jsonData);
            return data;
        }
        // Checks if the subreddit exists or if the subreddit is private.
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
