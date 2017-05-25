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
    public abstract class Gatherer
    {
        public DiscOps discOps;
        public WebHandler webHandler;
        private System.Threading.Timer timer;
        public Gatherer()
        {
            discOps = new DiscOps();
            webHandler = new WebHandler();
        }
        // This method is run by the timer, and is abstract
        // so that in the future this class can be used to gather
        public abstract void RunStrategy();
        // Executes RunStrategy method then waits specified amount of time, then repeats.
        public void Start(int sec)
        {        
            if (timer == null)
            {
                timer = new System.Threading.Timer(
                   e => RunStrategy(),
                   null,
                   TimeSpan.Zero,
                   TimeSpan.FromSeconds(sec));
            }
        }
        // Stops the timer.
        public void Stop()
        {           
            timer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
        }
        // Generic json serialization input is a POCO that is then converted to a json text.
        public string SerializeJson<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
                serializer.WriteObject(ms, obj);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }
        // Generic json deserialization input is a json formatted string and output is the specified object.
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


