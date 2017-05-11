﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace ArgusCore
{
    public class DiscOps
    {
        public void SaveToDisc<T>(object o, string filePath)
        {
            DeleteFileIfExists(filePath);
            using (var IFileStream = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(o.GetType());
                serializer.WriteObject(IFileStream, o);
                IFileStream.Close();
            };
        }
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
                //string sourceFile = Path.Combine(coreFolder, file);
                //string destinationFile = Path.Combine(coreFolder, "Faulty", file);
                //File.Move(sourceFile, destinationFile);
                return obj;
            }
        }
        private void DeleteFileIfExists(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
        public void EnsureFolderExists(string folderPath)
        {
            bool exists = Directory.Exists(folderPath);
            if (!exists)
                Directory.CreateDirectory(folderPath);
        }
    }
}