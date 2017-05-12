namespace ProjectArgus
{
    partial class PopupBox
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
            this.lstChildren = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstChildren
            // 
            this.lstChildren.FormattingEnabled = true;
            this.lstChildren.Location = new System.Drawing.Point(12, 8);
            this.lstChildren.Name = "lstChildren";
            this.lstChildren.Size = new System.Drawing.Size(260, 511);
            this.lstChildren.TabIndex = 0;
            // 
            // PopupBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 531);
            this.Controls.Add(this.lstChildren);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PopupBox";
            this.Text = "PopupBox";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstChildren;
    }
}