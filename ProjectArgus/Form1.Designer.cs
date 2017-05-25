namespace ProjectArgus
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.txtKeywordInput = new System.Windows.Forms.TextBox();
            this.addKeywordBtn = new System.Windows.Forms.Button();
            this.adminGrp = new System.Windows.Forms.GroupBox();
            this.deleteKeywordBtn = new System.Windows.Forms.Button();
            this.keywordLstbox = new System.Windows.Forms.ListBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.linkGrp = new System.Windows.Forms.GroupBox();
            this.linkLstview = new System.Windows.Forms.ListView();
            this.title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.subreddit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.deleteSubredditBtn = new System.Windows.Forms.Button();
            this.txtSubredditInput = new System.Windows.Forms.TextBox();
            this.addSubredditbtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.subredditLstbox = new System.Windows.Forms.ListBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.adminGrp.SuspendLayout();
            this.linkGrp.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter keyword:";
            // 
            // txtKeywordInput
            // 
            this.txtKeywordInput.Location = new System.Drawing.Point(8, 44);
            this.txtKeywordInput.Name = "txtKeywordInput";
            this.txtKeywordInput.Size = new System.Drawing.Size(196, 20);
            this.txtKeywordInput.TabIndex = 1;
            // 
            // addKeywordBtn
            // 
            this.addKeywordBtn.Location = new System.Drawing.Point(8, 70);
            this.addKeywordBtn.Name = "addKeywordBtn";
            this.addKeywordBtn.Size = new System.Drawing.Size(93, 23);
            this.addKeywordBtn.TabIndex = 2;
            this.addKeywordBtn.Text = "Add";
            this.addKeywordBtn.UseVisualStyleBackColor = true;
            this.addKeywordBtn.Click += new System.EventHandler(this.addKeywordBtn_Click);
            // 
            // adminGrp
            // 
            this.adminGrp.Controls.Add(this.deleteKeywordBtn);
            this.adminGrp.Controls.Add(this.txtKeywordInput);
            this.adminGrp.Controls.Add(this.keywordLstbox);
            this.adminGrp.Controls.Add(this.addKeywordBtn);
            this.adminGrp.Controls.Add(this.label1);
            this.adminGrp.Location = new System.Drawing.Point(16, 12);
            this.adminGrp.Name = "adminGrp";
            this.adminGrp.Size = new System.Drawing.Size(212, 280);
            this.adminGrp.TabIndex = 3;
            this.adminGrp.TabStop = false;
            this.adminGrp.Text = "Keyword Controls";
            // 
            // deleteKeywordBtn
            // 
            this.deleteKeywordBtn.Location = new System.Drawing.Point(111, 70);
            this.deleteKeywordBtn.Name = "deleteKeywordBtn";
            this.deleteKeywordBtn.Size = new System.Drawing.Size(93, 23);
            this.deleteKeywordBtn.TabIndex = 3;
            this.deleteKeywordBtn.Text = "Delete";
            this.deleteKeywordBtn.UseVisualStyleBackColor = true;
            this.deleteKeywordBtn.Click += new System.EventHandler(this.deleteKeywordBtn_Click);
            // 
            // keywordLstbox
            // 
            this.keywordLstbox.FormattingEnabled = true;
            this.keywordLstbox.Location = new System.Drawing.Point(8, 100);
            this.keywordLstbox.Name = "keywordLstbox";
            this.keywordLstbox.Size = new System.Drawing.Size(196, 173);
            this.keywordLstbox.TabIndex = 5;
            // 
            // linkGrp
            // 
            this.linkGrp.Controls.Add(this.linkLstview);
            this.linkGrp.Location = new System.Drawing.Point(234, 12);
            this.linkGrp.Name = "linkGrp";
            this.linkGrp.Size = new System.Drawing.Size(760, 516);
            this.linkGrp.TabIndex = 6;
            this.linkGrp.TabStop = false;
            this.linkGrp.Text = "Reddit";
            // 
            // linkLstview
            // 
            this.linkLstview.AllowColumnReorder = true;
            this.linkLstview.BackColor = System.Drawing.SystemColors.Window;
            this.linkLstview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.title,
            this.date,
            this.subreddit});
            this.linkLstview.Location = new System.Drawing.Point(7, 19);
            this.linkLstview.MultiSelect = false;
            this.linkLstview.Name = "linkLstview";
            this.linkLstview.Size = new System.Drawing.Size(747, 485);
            this.linkLstview.TabIndex = 12;
            this.linkLstview.UseCompatibleStateImageBehavior = false;
            this.linkLstview.View = System.Windows.Forms.View.Details;
            this.linkLstview.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.linkLstview_MouseDoubleClick);
            // 
            // title
            // 
            this.title.Text = "Title";
            this.title.Width = 400;
            // 
            // date
            // 
            this.date.Text = "Date";
            this.date.Width = 143;
            // 
            // subreddit
            // 
            this.subreddit.Text = "Subreddit";
            this.subreddit.Width = 200;
            // 
            // deleteSubredditBtn
            // 
            this.deleteSubredditBtn.Location = new System.Drawing.Point(111, 68);
            this.deleteSubredditBtn.Name = "deleteSubredditBtn";
            this.deleteSubredditBtn.Size = new System.Drawing.Size(93, 23);
            this.deleteSubredditBtn.TabIndex = 8;
            this.deleteSubredditBtn.Text = "Delete";
            this.deleteSubredditBtn.UseVisualStyleBackColor = true;
            this.deleteSubredditBtn.Click += new System.EventHandler(this.deleteSubredditBtn_Click);
            // 
            // txtSubredditInput
            // 
            this.txtSubredditInput.Location = new System.Drawing.Point(8, 42);
            this.txtSubredditInput.Name = "txtSubredditInput";
            this.txtSubredditInput.Size = new System.Drawing.Size(196, 20);
            this.txtSubredditInput.TabIndex = 6;
            // 
            // addSubredditbtn
            // 
            this.addSubredditbtn.Location = new System.Drawing.Point(8, 68);
            this.addSubredditbtn.Name = "addSubredditbtn";
            this.addSubredditbtn.Size = new System.Drawing.Size(93, 23);
            this.addSubredditbtn.TabIndex = 7;
            this.addSubredditbtn.Text = "Add";
            this.addSubredditbtn.UseVisualStyleBackColor = true;
            this.addSubredditbtn.Click += new System.EventHandler(this.addSubredditbtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Enter subreddit:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.subredditLstbox);
            this.groupBox1.Controls.Add(this.addSubredditbtn);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.deleteSubredditBtn);
            this.groupBox1.Controls.Add(this.txtSubredditInput);
            this.groupBox1.Location = new System.Drawing.Point(16, 298);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(212, 230);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Subreddit Controls";
            // 
            // subredditLstbox
            // 
            this.subredditLstbox.FormattingEnabled = true;
            this.subredditLstbox.Location = new System.Drawing.Point(8, 97);
            this.subredditLstbox.Name = "subredditLstbox";
            this.subredditLstbox.Size = new System.Drawing.Size(196, 121);
            this.subredditLstbox.TabIndex = 9;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Argus";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.BalloonTipClicked += new System.EventHandler(this.notifyIcon1_BalloonTipClicked);
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 545);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.linkGrp);
            this.Controls.Add(this.adminGrp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Project Argus";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.adminGrp.ResumeLayout(false);
            this.adminGrp.PerformLayout();
            this.linkGrp.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKeywordInput;
        private System.Windows.Forms.Button addKeywordBtn;
        private System.Windows.Forms.GroupBox adminGrp;
        private System.Windows.Forms.Button deleteKeywordBtn;
        private System.Windows.Forms.ListBox keywordLstbox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox linkGrp;
        private System.Windows.Forms.Button deleteSubredditBtn;
        private System.Windows.Forms.TextBox txtSubredditInput;
        private System.Windows.Forms.Button addSubredditbtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox subredditLstbox;
        private System.Windows.Forms.ListView linkLstview;
        private System.Windows.Forms.ColumnHeader title;
        private System.Windows.Forms.ColumnHeader date;
        private System.Windows.Forms.ColumnHeader subreddit;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

