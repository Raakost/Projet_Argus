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
    public abstract class Gatherer : UtilFacade, IObservable<Object>
    {
        private List<IObserver<Object>> observers;

        public Gatherer()
        {
            observers = new List<IObserver<Object>>();
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
        public IDisposable Subscribe(IObserver<object> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }
            return new Unsubscriber<Object>(observers, observer);
        }
    }
    internal class Unsubscriber<Object> : IDisposable
    {
        private List<IObserver<Object>> _observers;
        private IObserver<Object> _observer;

        internal Unsubscriber(List<IObserver<Object>> observers, IObserver<Object> observer)
        {
            this._observers = observers;
            this._observer = observer;
        }

        public void Dispose()
        {
            if (_observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }
}


