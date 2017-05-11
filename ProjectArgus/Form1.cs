using ArgusCore;
using ArgusEntities.Entities.Reddit;
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
        private Core core = new Core();
        private Analyzer analyzer = Analyzer.Instance;
        public Form1()
        {
            InitializeComponent();
            analyzer.Subscribe(this);
            core.Start();
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
            RefreshLists((List<ArgusChild>)value);
            // Call popupDialog and show latest results.
        }
        private void RefreshLists(List<ArgusChild> input)
        {
            linkLstview.BeginInvoke(new Action(() =>
            {
                linkLstview.Items.Clear();
                foreach (var child in input)
                {
                    ListViewItem row = new ListViewItem();
                    row.Text = child.data.title.ToString();

                    string dateStr = FromUnixTime(child.data.created_utc).ToString();

                    row.SubItems.Add(dateStr);
                    row.SubItems.Add(child.data.subreddit);
                    linkLstview.Items.Add(row);

                }

            }));
        }

        private DateTime FromUnixTime(double unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime);
        }
    }
}
