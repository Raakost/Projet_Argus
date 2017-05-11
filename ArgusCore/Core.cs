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
        private Analyzer analyzer;
        private RedditGatherer redditG;
        public Core()
        {
            analyzer = new Analyzer();
            redditG = new RedditGatherer();
            redditG.Subscribe(analyzer);
        }

        public void Start()
        {
            redditG.Start(5*60);
        }
    }
}
