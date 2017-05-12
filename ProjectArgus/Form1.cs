using ArgusCore;
using ArgusEntities.Entities.Reddit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectArgus
{
    public partial class Form1 : Form, IObserver<Object>
    {
        private Core core = new Core();
        private Analyzer analyzer = Analyzer.Instance;
        private KeywordManager keywordMgr = KeywordManager.Instance;
        private PopupBox popBox;
        public Form1()
        {
            InitializeComponent();         
            Thread popBoxThread = new Thread(new ThreadStart(InitPopbox));
            popBoxThread.Start();
            analyzer.Subscribe(this);            
            core.Start();
            RefreshLists();
        }
        private void CreateAndShowForm()
        {
            popBox = new PopupBox();
            analyzer.Subscribe(popBox);
            popBox.ShowDialog();
        }
        private void InitPopbox()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(() => CreateAndShowForm()));
                
                return;
            }
            CreateAndShowForm();
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
            RefreshResultList((List<ArgusChild>)value);
            // Call popupDialog and show latest results.
            popBox.DisplayResults((List<ArgusChild>)value);
        }


        private void RefreshResultList(List<ArgusChild> input)
        {
            linkLstview.BeginInvoke(new Action(() =>
            {
                //linkLstview.Items.Clear();
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
        private void RefreshLists()
        {
            keywordLstbox.DataSource = null;
            keywordLstbox.DataSource = keywordMgr.ReadAll();

            subredditLstbox.DataSource = null;
            subredditLstbox.DataSource = core.redditGatherer.ReadAllSubReddits();
        }
        private void addKeywordBtn_Click(object sender, EventArgs e)
        {
            if (txtKeywordInput.Text != "")
            {
                keywordMgr.AddToList(txtKeywordInput.Text);
            }
            txtKeywordInput.Text = "";
            RefreshLists();
        }

        private void deleteKeywordBtn_Click(object sender, EventArgs e)
        {
            var selectedKeyword = keywordLstbox.SelectedItem as string;
            keywordMgr.Delete(selectedKeyword);
            txtKeywordInput.Text = "";
            RefreshLists();
        }

        private void addSubredditbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSubredditInput.Text != "")
                {
                    if (core.redditGatherer.IsSubredditValid(txtSubredditInput.Text))
                    {
                        core.redditGatherer.AddSubReddit(txtSubredditInput.Text);
                    }
                    else
                    {
                        MessageBox.Show("Subreddit does not exist!");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Private subreddit!");
            }
            txtSubredditInput.Text = "";
            RefreshLists();
        }

        private void deleteSubredditBtn_Click(object sender, EventArgs e)
        {
            // Selected index from list?
            var selectedSubreddit = subredditLstbox.SelectedItem as string;
            core.redditGatherer.DeleteSubreddit(selectedSubreddit);
            txtSubredditInput.Text = "";
            RefreshLists();
        }

        private void linkLstview_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem selectedItem = linkLstview.SelectedItems[0];
            var child = analyzer.GetChildByTitle(selectedItem.Text);
            if (child != null)
            {
                GotoThread("https://reddit.com" + child.data.permalink);
            }

            Console.WriteLine();
        }
        private void GotoThread(string threadUrl)
        {
            System.Diagnostics.Process.Start(threadUrl);
        }
    }
}
