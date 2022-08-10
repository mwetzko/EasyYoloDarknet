namespace Train
{
    partial class DownloadForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbDownload = new System.Windows.Forms.ProgressBar();
            this.lbBytesDownloaded = new System.Windows.Forms.Label();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // pbDownload
            // 
            this.pbDownload.Location = new System.Drawing.Point(12, 12);
            this.pbDownload.Name = "pbDownload";
            this.pbDownload.Size = new System.Drawing.Size(250, 23);
            this.pbDownload.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbDownload.TabIndex = 0;
            // 
            // lbBytesDownloaded
            // 
            this.lbBytesDownloaded.Location = new System.Drawing.Point(12, 38);
            this.lbBytesDownloaded.Name = "lbBytesDownloaded";
            this.lbBytesDownloaded.Size = new System.Drawing.Size(250, 34);
            this.lbBytesDownloaded.TabIndex = 1;
            this.lbBytesDownloaded.Text = "Size";
            this.lbBytesDownloaded.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // updateTimer
            // 
            this.updateTimer.Interval = 500;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // DownloadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 81);
            this.Controls.Add(this.lbBytesDownloaded);
            this.Controls.Add(this.pbDownload);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DownloadForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Train | Download";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbDownload;
        private System.Windows.Forms.Label lbBytesDownloaded;
        private System.Windows.Forms.Timer updateTimer;
    }
}