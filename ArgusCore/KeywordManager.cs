using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace ArgusCore
{
    public class KeywordManager
    {
        private string coreFolder = @"C:\Argus\";
        private List<string> subReddits;

        public KeywordManager()
        {
            subReddits = new List<string>();
        }

        public void addToList(string item)
        {
            subReddits.Add(item);
        }

        public List<string> ReadAll()
        {
            return subReddits;
        }

        public void delete(string item)
        {
            subReddits.Remove(item);
        }


        public void saveToDisc<T>(object o, string filePath)
        {

            using (var IFileStream = new FileStream(filePath, FileMode.OpenOrCreate)) {

                DataContractJsonSerializer serializer = new DataContractJsonSerializer(o.GetType());
                serializer.WriteObject(IFileStream, o);
                IFileStream.Close();
            };
        }

        public T loadFromDisc<T>(string file)
        {
            T obj = Activator.CreateInstance<T>();
            DataContractJsonSerializer ISerializer = new DataContractJsonSerializer(obj.GetType());
            try
            {
                using(var IFileStream = new FileStream(file, FileMode.Open))
                {
                    obj = (T)ISerializer.ReadObject(IFileStream);
                    return obj;
                }
            }
            catch (SerializationException)
            {
                string sourceFile = Path.Combine(coreFolder, file);
                string destinationFile = Path.Combine(coreFolder, "Faulty", file);
                File.Move(sourceFile, destinationFile);
                return obj;
            }
        }
    }
}
