using ArgusCore.Gatherers.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace ArgusCore.Gatherers
{
    public abstract class Gatherer : UtilFacade
    {
        private System.Threading.Timer timer;
        public Gatherer()
        {
        }
        public abstract void RunStrategy();
        public void Start(int sec)
        {
            // Start timer
            if (timer == null)
            {
                timer = new System.Threading.Timer(
                   e => RunStrategy(),
                   null,
                   TimeSpan.Zero,
                   TimeSpan.FromSeconds(sec));
            }
        }
        public void Stop()
        {
            // Stop timer
            timer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
        }
        public string SerializeJson<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
                serializer.WriteObject(ms, obj);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }
        public T DeserializeJson<T>(string json)
        {
            using (MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                T obj = Activator.CreateInstance<T>();
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
                obj = (T)serializer.ReadObject(ms);
                ms.Close();
                return obj;
            }

        }
    }
}


