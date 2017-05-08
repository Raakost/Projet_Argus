using ArgusEntities.Entities.Reddit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgusCore.Gatherers.Reddit
{
    public class RedditGatherer : Gatherer
    {
        private string redditStr = "https://reddit.com/r/";
        private string jsonSuffix = ".json";

        public RedditGatherer()
        {
            
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

            //Result(DeserializeJson<dynamic>(jsonData));
        }
    }
}
