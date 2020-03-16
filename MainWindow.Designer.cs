namespace DeJargonizerOnPremise
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.addFilesBtn = new System.Windows.Forms.Button();
            this.filesListBox = new System.Windows.Forms.ListBox();
            this.clearFilesBtn = new System.Windows.Forms.Button();
            this.removeFilesBtn = new System.Windows.Forms.Button();
            this.deJargonizeBtn = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.amountOfFilesLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // addFilesBtn
            // 
            this.addFilesBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addFilesBtn.Location = new System.Drawing.Point(12, 158);
            this.addFilesBtn.Name = "addFilesBtn";
            this.addFilesBtn.Size = new System.Drawing.Size(75, 23);
            this.addFilesBtn.TabIndex = 0;
            this.addFilesBtn.Text = "Add Files";
            this.addFilesBtn.UseVisualStyleBackColor = true;
            this.addFilesBtn.Click += new System.EventHandler(this.addFilesBtn_Click);
            // 
            // filesListBox
            // 
            this.filesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filesListBox.FormattingEnabled = true;
            this.filesListBox.HorizontalScrollbar = true;
            this.filesListBox.ItemHeight = 15;
            this.filesListBox.Location = new System.Drawing.Point(12, 12);
            this.filesListBox.Name = "filesListBox";
            this.filesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.filesListBox.Size = new System.Drawing.Size(493, 124);
            this.filesListBox.Sorted = true;
            this.filesListBox.TabIndex = 2;
            // 
            // clearFilesBtn
            // 
            this.clearFilesBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.clearFilesBtn.Location = new System.Drawing.Point(236, 158);
            this.clearFilesBtn.Name = "clearFilesBtn";
            this.clearFilesBtn.Size = new System.Drawing.Size(75, 23);
            this.clearFilesBtn.TabIndex = 0;
            this.clearFilesBtn.Text = "Clear Files";
            this.clearFilesBtn.UseVisualStyleBackColor = true;
            this.clearFilesBtn.Click += new System.EventHandler(this.clearFilesBtn_Click);
            // 
            // removeFilesBtn
            // 
            this.removeFilesBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removeFilesBtn.Location = new System.Drawing.Point(93, 158);
            this.removeFilesBtn.Name = "removeFilesBtn";
            this.removeFilesBtn.Size = new System.Drawing.Size(137, 23);
            this.removeFilesBtn.TabIndex = 3;
            this.removeFilesBtn.Text = "Remove Selected Files";
            this.removeFilesBtn.UseVisualStyleBackColor = true;
            this.removeFilesBtn.Click += new System.EventHandler(this.removeFilesBtn_Click);
            // 
            // deJargonizeBtn
            // 
            this.deJargonizeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.deJargonizeBtn.Location = new System.Drawing.Point(420, 158);
            this.deJargonizeBtn.Name = "deJargonizeBtn";
            this.deJargonizeBtn.Size = new System.Drawing.Size(85, 23);
            this.deJargonizeBtn.TabIndex = 4;
            this.deJargonizeBtn.Text = "DeJargonize";
            this.deJargonizeBtn.UseVisualStyleBackColor = true;
            this.deJargonizeBtn.Click += new System.EventHandler(this.deJargonizeBtn_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(12, 187);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(493, 23);
            this.progressBar.Step = 1;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 6;
            this.progressBar.Visible = false;
            // 
            // amountOfFilesLbl
            // 
            this.amountOfFilesLbl.AutoSize = true;
            this.amountOfFilesLbl.Location = new System.Drawing.Point(467, 139);
            this.amountOfFilesLbl.Name = "amountOfFilesLbl";
            this.amountOfFilesLbl.Size = new System.Drawing.Size(39, 15);
            this.amountOfFilesLbl.TabIndex = 7;
            this.amountOfFilesLbl.Text = "0 Files";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 213);
            this.Controls.Add(this.amountOfFilesLbl);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.deJargonizeBtn);
            this.Controls.Add(this.clearFilesBtn);
            this.Controls.Add(this.removeFilesBtn);
            this.Controls.Add(this.addFilesBtn);
            this.Controls.Add(this.filesListBox);
            this.Name = "MainWindow";
            this.Text = "DeJargonizer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addFilesBtn;
        private System.Windows.Forms.ListBox filesListBox;
        private System.Windows.Forms.Button clearFilesBtn;
        private System.Windows.Forms.Button removeFilesBtn;
        private System.Windows.Forms.Button deJargonizeBtn;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label amountOfFilesLbl;
    }
}

