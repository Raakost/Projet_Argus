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
            this.label1 = new System.Windows.Forms.Label();
            this.keyInputTxt = new System.Windows.Forms.TextBox();
            this.addKeywordBtn = new System.Windows.Forms.Button();
            this.adminGrp = new System.Windows.Forms.GroupBox();
            this.searchlbl = new System.Windows.Forms.Label();
            this.keySearchTxt = new System.Windows.Forms.TextBox();
            this.deleteKeywordBtn = new System.Windows.Forms.Button();
            this.keywordLstbox = new System.Windows.Forms.ListBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.linkGrp = new System.Windows.Forms.GroupBox();
            this.linkLbl = new System.Windows.Forms.Label();
            this.linkSearchTxt = new System.Windows.Forms.TextBox();
            this.deleteSubredditBtn = new System.Windows.Forms.Button();
            this.subredditInputTxt = new System.Windows.Forms.TextBox();
            this.addSubredditbtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.subredditLstbox = new System.Windows.Forms.ListBox();
            this.linkLstview = new System.Windows.Forms.ListView();
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
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter keyword(s):";
            // 
            // keyInputTxt
            // 
            this.keyInputTxt.Location = new System.Drawing.Point(8, 44);
            this.keyInputTxt.Name = "keyInputTxt";
            this.keyInputTxt.Size = new System.Drawing.Size(196, 20);
            this.keyInputTxt.TabIndex = 1;
            // 
            // addKeywordBtn
            // 
            this.addKeywordBtn.Location = new System.Drawing.Point(8, 70);
            this.addKeywordBtn.Name = "addKeywordBtn";
            this.addKeywordBtn.Size = new System.Drawing.Size(93, 23);
            this.addKeywordBtn.TabIndex = 2;
            this.addKeywordBtn.Text = "Add";
            this.addKeywordBtn.UseVisualStyleBackColor = true;
            // 
            // adminGrp
            // 
            this.adminGrp.Controls.Add(this.searchlbl);
            this.adminGrp.Controls.Add(this.keySearchTxt);
            this.adminGrp.Controls.Add(this.deleteKeywordBtn);
            this.adminGrp.Controls.Add(this.keyInputTxt);
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
            // searchlbl
            // 
            this.searchlbl.AutoSize = true;
            this.searchlbl.Location = new System.Drawing.Point(11, 110);
            this.searchlbl.Name = "searchlbl";
            this.searchlbl.Size = new System.Drawing.Size(103, 13);
            this.searchlbl.TabIndex = 4;
            this.searchlbl.Text = "Search in keywords:";
            // 
            // keySearchTxt
            // 
            this.keySearchTxt.Location = new System.Drawing.Point(8, 126);
            this.keySearchTxt.Name = "keySearchTxt";
            this.keySearchTxt.Size = new System.Drawing.Size(196, 20);
            this.keySearchTxt.TabIndex = 4;
            // 
            // deleteKeywordBtn
            // 
            this.deleteKeywordBtn.Location = new System.Drawing.Point(111, 70);
            this.deleteKeywordBtn.Name = "deleteKeywordBtn";
            this.deleteKeywordBtn.Size = new System.Drawing.Size(93, 23);
            this.deleteKeywordBtn.TabIndex = 3;
            this.deleteKeywordBtn.Text = "Delete";
            this.deleteKeywordBtn.UseVisualStyleBackColor = true;
            // 
            // keywordLstbox
            // 
            this.keywordLstbox.FormattingEnabled = true;
            this.keywordLstbox.Location = new System.Drawing.Point(8, 152);
            this.keywordLstbox.Name = "keywordLstbox";
            this.keywordLstbox.Size = new System.Drawing.Size(196, 121);
            this.keywordLstbox.TabIndex = 5;
            // 
            // linkGrp
            // 
            this.linkGrp.Controls.Add(this.linkLstview);
            this.linkGrp.Controls.Add(this.linkLbl);
            this.linkGrp.Controls.Add(this.linkSearchTxt);
            this.linkGrp.Location = new System.Drawing.Point(234, 12);
            this.linkGrp.Name = "linkGrp";
            this.linkGrp.Size = new System.Drawing.Size(488, 516);
            this.linkGrp.TabIndex = 6;
            this.linkGrp.TabStop = false;
            this.linkGrp.Text = "Reddit";
            // 
            // linkLbl
            // 
            this.linkLbl.AutoSize = true;
            this.linkLbl.Location = new System.Drawing.Point(10, 28);
            this.linkLbl.Name = "linkLbl";
            this.linkLbl.Size = new System.Drawing.Size(79, 13);
            this.linkLbl.TabIndex = 3;
            this.linkLbl.Text = "Search in links:";
            // 
            // linkSearchTxt
            // 
            this.linkSearchTxt.Location = new System.Drawing.Point(7, 44);
            this.linkSearchTxt.Name = "linkSearchTxt";
            this.linkSearchTxt.Size = new System.Drawing.Size(196, 20);
            this.linkSearchTxt.TabIndex = 10;
            // 
            // deleteSubredditBtn
            // 
            this.deleteSubredditBtn.Location = new System.Drawing.Point(111, 68);
            this.deleteSubredditBtn.Name = "deleteSubredditBtn";
            this.deleteSubredditBtn.Size = new System.Drawing.Size(93, 23);
            this.deleteSubredditBtn.TabIndex = 8;
            this.deleteSubredditBtn.Text = "Delete";
            this.deleteSubredditBtn.UseVisualStyleBackColor = true;
            // 
            // subredditInputTxt
            // 
            this.subredditInputTxt.Location = new System.Drawing.Point(8, 42);
            this.subredditInputTxt.Name = "subredditInputTxt";
            this.subredditInputTxt.Size = new System.Drawing.Size(196, 20);
            this.subredditInputTxt.TabIndex = 6;
            // 
            // addSubredditbtn
            // 
            this.addSubredditbtn.Location = new System.Drawing.Point(8, 68);
            this.addSubredditbtn.Name = "addSubredditbtn";
            this.addSubredditbtn.Size = new System.Drawing.Size(93, 23);
            this.addSubredditbtn.TabIndex = 7;
            this.addSubredditbtn.Text = "Add";
            this.addSubredditbtn.UseVisualStyleBackColor = true;
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
            this.groupBox1.Controls.Add(this.subredditInputTxt);
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
            // linkLstview
            // 
            this.linkLstview.AllowColumnReorder = true;
            this.linkLstview.Location = new System.Drawing.Point(7, 73);
            this.linkLstview.Name = "linkLstview";
            this.linkLstview.Size = new System.Drawing.Size(475, 431);
            this.linkLstview.TabIndex = 12;
            this.linkLstview.UseCompatibleStateImageBehavior = false;
            this.linkLstview.View = System.Windows.Forms.View.Details;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 545);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.linkGrp);
            this.Controls.Add(this.adminGrp);
            this.Name = "Form1";
            this.Text = "Form1";
            this.adminGrp.ResumeLayout(false);
            this.adminGrp.PerformLayout();
            this.linkGrp.ResumeLayout(false);
            this.linkGrp.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox keyInputTxt;
        private System.Windows.Forms.Button addKeywordBtn;
        private System.Windows.Forms.GroupBox adminGrp;
        private System.Windows.Forms.Button deleteKeywordBtn;
        private System.Windows.Forms.ListBox keywordLstbox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox linkGrp;
        private System.Windows.Forms.Label searchlbl;
        private System.Windows.Forms.TextBox keySearchTxt;
        private System.Windows.Forms.Label linkLbl;
        private System.Windows.Forms.TextBox linkSearchTxt;
        private System.Windows.Forms.Button deleteSubredditBtn;
        private System.Windows.Forms.TextBox subredditInputTxt;
        private System.Windows.Forms.Button addSubredditbtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox subredditLstbox;
        private System.Windows.Forms.ListView linkLstview;
    }
}

