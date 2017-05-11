using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgusCore
{
    public class Analyzer : IObserver<Object>
    {
        public void OnCompleted()
        {
            //throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            //throw new NotImplementedException();
        }

        public void OnNext(object value)
        {
            //throw new NotImplementedException();
        }
    }
}
