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
            this.keywordInputTxt = new System.Windows.Forms.TextBox();
            this.addBtn = new System.Windows.Forms.Button();
            this.adminGrp = new System.Windows.Forms.GroupBox();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.keywordLstbox = new System.Windows.Forms.ListBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.keywordGrp = new System.Windows.Forms.GroupBox();
            this.linkGrp = new System.Windows.Forms.GroupBox();
            this.linkLstbox = new System.Windows.Forms.ListBox();
            this.keySearchTxt = new System.Windows.Forms.TextBox();
            this.linkSearchTxt = new System.Windows.Forms.TextBox();
            this.linkLbl = new System.Windows.Forms.Label();
            this.searchlbl = new System.Windows.Forms.Label();
            this.adminGrp.SuspendLayout();
            this.keywordGrp.SuspendLayout();
            this.linkGrp.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter keyword(s)";
            // 
            // keywordInputTxt
            // 
            this.keywordInputTxt.Location = new System.Drawing.Point(6, 54);
            this.keywordInputTxt.Name = "keywordInputTxt";
            this.keywordInputTxt.Size = new System.Drawing.Size(196, 20);
            this.keywordInputTxt.TabIndex = 1;
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(6, 80);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(93, 23);
            this.addBtn.TabIndex = 2;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
            // 
            // adminGrp
            // 
            this.adminGrp.Controls.Add(this.deleteBtn);
            this.adminGrp.Controls.Add(this.keywordInputTxt);
            this.adminGrp.Controls.Add(this.addBtn);
            this.adminGrp.Controls.Add(this.label1);
            this.adminGrp.Location = new System.Drawing.Point(12, 12);
            this.adminGrp.Name = "adminGrp";
            this.adminGrp.Size = new System.Drawing.Size(212, 129);
            this.adminGrp.TabIndex = 3;
            this.adminGrp.TabStop = false;
            this.adminGrp.Text = "Controls";
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(109, 80);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(93, 23);
            this.deleteBtn.TabIndex = 3;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            // 
            // keywordLstbox
            // 
            this.keywordLstbox.FormattingEnabled = true;
            this.keywordLstbox.Location = new System.Drawing.Point(6, 76);
            this.keywordLstbox.Name = "keywordLstbox";
            this.keywordLstbox.Size = new System.Drawing.Size(196, 186);
            this.keywordLstbox.TabIndex = 4;
            // 
            // keywordGrp
            // 
            this.keywordGrp.Controls.Add(this.searchlbl);
            this.keywordGrp.Controls.Add(this.keySearchTxt);
            this.keywordGrp.Controls.Add(this.keywordLstbox);
            this.keywordGrp.Location = new System.Drawing.Point(12, 147);
            this.keywordGrp.Name = "keywordGrp";
            this.keywordGrp.Size = new System.Drawing.Size(212, 273);
            this.keywordGrp.TabIndex = 5;
            this.keywordGrp.TabStop = false;
            this.keywordGrp.Text = "Keywords";
            this.keywordGrp.Enter += new System.EventHandler(this.keywordGrp_Enter);
            // 
            // linkGrp
            // 
            this.linkGrp.Controls.Add(this.linkLbl);
            this.linkGrp.Controls.Add(this.linkSearchTxt);
            this.linkGrp.Controls.Add(this.linkLstbox);
            this.linkGrp.Location = new System.Drawing.Point(230, 12);
            this.linkGrp.Name = "linkGrp";
            this.linkGrp.Size = new System.Drawing.Size(337, 408);
            this.linkGrp.TabIndex = 6;
            this.linkGrp.TabStop = false;
            this.linkGrp.Text = "Reddit";
            // 
            // linkLstbox
            // 
            this.linkLstbox.FormattingEnabled = true;
            this.linkLstbox.Location = new System.Drawing.Point(7, 80);
            this.linkLstbox.Name = "linkLstbox";
            this.linkLstbox.Size = new System.Drawing.Size(321, 316);
            this.linkLstbox.TabIndex = 0;
            // 
            // keySearchTxt
            // 
            this.keySearchTxt.Location = new System.Drawing.Point(6, 50);
            this.keySearchTxt.Name = "keySearchTxt";
            this.keySearchTxt.Size = new System.Drawing.Size(196, 20);
            this.keySearchTxt.TabIndex = 5;
            // 
            // linkSearchTxt
            // 
            this.linkSearchTxt.Location = new System.Drawing.Point(7, 54);
            this.linkSearchTxt.Name = "linkSearchTxt";
            this.linkSearchTxt.Size = new System.Drawing.Size(196, 20);
            this.linkSearchTxt.TabIndex = 2;
            // 
            // linkLbl
            // 
            this.linkLbl.AutoSize = true;
            this.linkLbl.Location = new System.Drawing.Point(10, 38);
            this.linkLbl.Name = "linkLbl";
            this.linkLbl.Size = new System.Drawing.Size(41, 13);
            this.linkLbl.TabIndex = 3;
            this.linkLbl.Text = "Search";
            // 
            // searchlbl
            // 
            this.searchlbl.AutoSize = true;
            this.searchlbl.Location = new System.Drawing.Point(9, 34);
            this.searchlbl.Name = "searchlbl";
            this.searchlbl.Size = new System.Drawing.Size(41, 13);
            this.searchlbl.TabIndex = 4;
            this.searchlbl.Text = "Search";
            this.searchlbl.Click += new System.EventHandler(this.label3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 444);
            this.Controls.Add(this.linkGrp);
            this.Controls.Add(this.keywordGrp);
            this.Controls.Add(this.adminGrp);
            this.Name = "Form1";
            this.Text = "Form1";
            this.adminGrp.ResumeLayout(false);
            this.adminGrp.PerformLayout();
            this.keywordGrp.ResumeLayout(false);
            this.keywordGrp.PerformLayout();
            this.linkGrp.ResumeLayout(false);
            this.linkGrp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox keywordInputTxt;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.GroupBox adminGrp;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.ListBox keywordLstbox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox keywordGrp;
        private System.Windows.Forms.GroupBox linkGrp;
        private System.Windows.Forms.ListBox linkLstbox;
        private System.Windows.Forms.Label searchlbl;
        private System.Windows.Forms.TextBox keySearchTxt;
        private System.Windows.Forms.Label linkLbl;
        private System.Windows.Forms.TextBox linkSearchTxt;
    }
}

