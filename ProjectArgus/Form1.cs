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
    // Implements the observer pattern, so we can get results from the analyzer.
    public partial class Form1 : Form, IObserver<Object>
    {
        private Core core = new Core();
        private Analyzer analyzer = Analyzer.Instance;
        private KeywordManager keywordMgr = KeywordManager.Instance;
        public Form1()
        {
            InitializeComponent();
            analyzer.Subscribe(this); // Subscribes this form to the analyzer so it can get results as they are found.
            core.Start();
            RefreshLists();
        }
        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }
        // This method is triggered when the analyzer gets a result. 
        public void OnNext(object value)
        {
            // Typecast the input data to a list of reddit posts.
            var data = (List<ArgusChild>)value;
            // Refresh GUI on new result from analyzer.
            RefreshResultList(data);
            // Show Balloon tip.
            ShowBalloonTip(data.Count);
        }
        // Show balloon tip for 4 secs.
        private void ShowBalloonTip(int nrOfPosts)
        {
            if (!this.Visible)
            {
                string formattedStr = nrOfPosts + " new posts found.";
                notifyIcon1.ShowBalloonTip(4000, "New Argus data!", formattedStr, ToolTipIcon.None);
            }
        }
        // Sets up list of results with input.
        private void RefreshResultList(List<ArgusChild> input)
        {
            linkLstview.BeginInvoke(new Action(() =>
            {
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
        // Format UnixTime to DateTime.
        private DateTime FromUnixTime(double unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime);
        }
        // Refreshes the lists of keywords and subreddits.
        private void RefreshLists()
        {
            keywordLstbox.DataSource = null;
            keywordLstbox.DataSource = keywordMgr.ReadAll();

            subredditLstbox.DataSource = null;
            subredditLstbox.DataSource = core.redditGatherer.ReadAllSubReddits();
        }
        // Add keyword to keyword manager.
        private void addKeywordBtn_Click(object sender, EventArgs e)
        {
            if (txtKeywordInput.Text != "")
            {
                keywordMgr.AddToList(txtKeywordInput.Text);
            }
            txtKeywordInput.Text = "";
            RefreshLists();
        }
        // Delete keyword in keyword manager.
        private void deleteKeywordBtn_Click(object sender, EventArgs e)
        {
            var selectedKeyword = keywordLstbox.SelectedItem as string;
            keywordMgr.Delete(selectedKeyword);
            txtKeywordInput.Text = "";
            RefreshLists();
        }
        // Add subreddit to subreddit manager.
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
        // Delete subreddit from subreddit manager.
        private void deleteSubredditBtn_Click(object sender, EventArgs e)
        {
            // Selected index from list?
            var selectedSubreddit = subredditLstbox.SelectedItem as string;
            core.redditGatherer.DeleteSubreddit(selectedSubreddit);
            txtSubredditInput.Text = "";
            RefreshLists();
        }
        // Opens selected reddit post in browser.
        private void linkLstview_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem selectedItem = linkLstview.SelectedItems[0];
            var child = analyzer.GetChildByTitle(selectedItem.Text);
            if (child != null)
            {
                GotoThread("https://reddit.com" + child.data.permalink);
            }
        }
        // Opens url in default browser.
        private void GotoThread(string threadUrl)
        {
            System.Diagnostics.Process.Start(threadUrl);
        }
        // Instead of closing the form it is hidden away instead.
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            if (e.CloseReason == CloseReason.WindowsShutDown) return;
        }
        // If form is minimized it's hidden to tray.
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                this.Hide();
            }

            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;
            }
        }
        // If the tray icon is double clicked the form is opened.
        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            //this.Show();
            this.Visible = true;
        }
        // If balloon tip is clicked the form is opened.
        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            this.Visible = true;
        }
    }
}
