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

            // Checks if config file exists, if it exists it is loaded from disc.

            keywordFile = coreFolder + "Keywords.json";
            if (File.Exists(keywordFile))
            {
                keywords = discOps.LoadFromDisc<List<string>>(keywordFile);
            }
            else
            {
                // If it doesn't exist creates the folder, then creates an empty subreddit list, finally it's saved.
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

        // Adds input keyword to config file and saves it to disc.
        public void AddToList(string item)
        {
            keywords.Add(item);
            discOps.SaveToDisc<List<string>>(keywords, keywordFile);
        }
        // Returns all keywords in config file.
        public List<string> ReadAll()
        {
            return keywords;
        }
        // Delete input keyword from config file and saves it to disc.
        public void Delete(string item)
        {
            keywords.Remove(item);
            discOps.SaveToDisc<List<string>>(keywords, keywordFile);
        }
    }
}
