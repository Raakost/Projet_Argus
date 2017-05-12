using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ArgusCore.Gatherers.Utils;

namespace ArgusCore
{
    public class KeywordManager
    {

        private string coreFolder = @"C:\Argus\";
        private string keywordFile = "";
        private List<string> keywords;

        private DiscOps discOps;

        private static readonly KeywordManager instance = new KeywordManager();

        static KeywordManager()
        {

        }
        private KeywordManager()
        {
            discOps = new DiscOps();

            keywordFile = coreFolder + "Keywords.json";
            if (File.Exists(keywordFile))
            {
                keywords = discOps.LoadFromDisc<List<string>>(keywordFile);
            }
            else
            {
                discOps.EnsureFolderExists(coreFolder);
                keywords = new List<string>();
                discOps.SaveToDisc<List<string>>(keywords, keywordFile);
            }
        }
        public static KeywordManager Instance
        {
            get
            {
                return instance;
            }
        }

        public void AddToList(string item)
        {
            keywords.Add(item);
            discOps.SaveToDisc<List<string>>(keywords, keywordFile);
        }

        public List<string> ReadAll()
        {
            return keywords;
        }

        public void Delete(string item)
        {
            keywords.Remove(item);
            discOps.SaveToDisc<List<string>>(keywords, keywordFile);
        }
    }
}
