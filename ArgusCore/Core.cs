using ArgusCore.Gatherers.Reddit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgusCore
{
    public class Core
    {
        public RedditGatherer redditGatherer;
        public Core()
        {
            redditGatherer = new RedditGatherer();
        }

        public void Start()
        {
            // Starts the reddit gatherer with a 5 minute inteval
            redditGatherer.Start(5 * 60);            
        }
    }
}