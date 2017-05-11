using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectArgus
{
    public partial class Form1 : Form, IObserver<Object>
    {
        public Form1()
        {
            InitializeComponent();
        }

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
            // Refresh GUI on new result from analyzer.
        }
    }
}
