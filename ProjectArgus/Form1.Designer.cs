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
            this.keywordTxt = new System.Windows.Forms.TextBox();
            this.addBtn = new System.Windows.Forms.Button();
            this.adminGrp = new System.Windows.Forms.GroupBox();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.keywordLstbox = new System.Windows.Forms.ListBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.keywordGrp = new System.Windows.Forms.GroupBox();
            this.adminGrp.SuspendLayout();
            this.keywordGrp.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter keyword(s)";
            // 
            // keywordTxt
            // 
            this.keywordTxt.Location = new System.Drawing.Point(16, 50);
            this.keywordTxt.Name = "keywordTxt";
            this.keywordTxt.Size = new System.Drawing.Size(156, 20);
            this.keywordTxt.TabIndex = 1;
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(16, 76);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 23);
            this.addBtn.TabIndex = 2;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
            // 
            // adminGrp
            // 
            this.adminGrp.Controls.Add(this.deleteBtn);
            this.adminGrp.Controls.Add(this.keywordTxt);
            this.adminGrp.Controls.Add(this.addBtn);
            this.adminGrp.Controls.Add(this.label1);
            this.adminGrp.Location = new System.Drawing.Point(12, 12);
            this.adminGrp.Name = "adminGrp";
            this.adminGrp.Size = new System.Drawing.Size(190, 129);
            this.adminGrp.TabIndex = 3;
            this.adminGrp.TabStop = false;
            this.adminGrp.Text = "Controls";
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(97, 76);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteBtn.TabIndex = 3;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            // 
            // keywordLstbox
            // 
            this.keywordLstbox.FormattingEnabled = true;
            this.keywordLstbox.Location = new System.Drawing.Point(18, 34);
            this.keywordLstbox.Name = "keywordLstbox";
            this.keywordLstbox.Size = new System.Drawing.Size(316, 147);
            this.keywordLstbox.TabIndex = 4;
            // 
            // keywordGrp
            // 
            this.keywordGrp.Controls.Add(this.keywordLstbox);
            this.keywordGrp.Location = new System.Drawing.Point(208, 12);
            this.keywordGrp.Name = "keywordGrp";
            this.keywordGrp.Size = new System.Drawing.Size(352, 211);
            this.keywordGrp.TabIndex = 5;
            this.keywordGrp.TabStop = false;
            this.keywordGrp.Text = "Keywords";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 242);
            this.Controls.Add(this.keywordGrp);
            this.Controls.Add(this.adminGrp);
            this.Name = "Form1";
            this.Text = "Form1";
            this.adminGrp.ResumeLayout(false);
            this.adminGrp.PerformLayout();
            this.keywordGrp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox keywordTxt;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.GroupBox adminGrp;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.ListBox keywordLstbox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox keywordGrp;
    }
}

