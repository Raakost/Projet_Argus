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
        private Analyzer analyzer = Analyzer.Instance;
        private RedditGatherer redditG;
        public Core()
        {
            redditG = new RedditGatherer();
        }

        public void Start()
        {
            redditG.Start(5 * 60);
            
        }
    }
}
