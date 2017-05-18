using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace ArgusCore.Gatherers.Utils
{
    public class DiscOps
    {
        // Save input object to input file path.
        public void SaveToDisc<T>(object o, string filePath)
        {
            // If file exists delete first to avoid corrupted data.
            DeleteFileIfExists(filePath);
            using (var IFileStream = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(o.GetType());
                serializer.WriteObject(IFileStream, o);
                IFileStream.Close();
            };
        }
        // Load file from input file path to a specified object type.
        public T LoadFromDisc<T>(string file)
        {
            T obj = Activator.CreateInstance<T>();
            DataContractJsonSerializer ISerializer = new DataContractJsonSerializer(obj.GetType());
            try
            {
                using (var IFileStream = new FileStream(file, FileMode.Open))
                {
                    obj = (T)ISerializer.ReadObject(IFileStream);
                    return obj;
                }
            }
            catch (SerializationException)
            {
                return obj;
            }
        }
        // Deletes file at input file path if it exists.
        private void DeleteFileIfExists(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
        // Check if folder path exists, if not it is created.
        public void EnsureFolderExists(string folderPath)
        {
            bool exists = Directory.Exists(folderPath);
            if (!exists)
                Directory.CreateDirectory(folderPath);
        }
    }
}
