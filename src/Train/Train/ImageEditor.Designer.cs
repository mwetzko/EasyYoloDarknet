namespace Train
{
    partial class ImageEditor
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.lbScale = new System.Windows.Forms.Label();
            this.bufferPanel = new Train.BufferPanel();
            this.pnlMarks = new System.Windows.Forms.Panel();
            this.pnlMarksScroll = new System.Windows.Forms.Panel();
            this.pnlMarksList = new System.Windows.Forms.Panel();
            this.lbMarks = new System.Windows.Forms.Label();
            this.pnlStatus.SuspendLayout();
            this.pnlMarks.SuspendLayout();
            this.pnlMarksScroll.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlStatus
            // 
            this.pnlStatus.Controls.Add(this.lbScale);
            this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlStatus.Location = new System.Drawing.Point(0, 278);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(458, 22);
            this.pnlStatus.TabIndex = 0;
            // 
            // lbScale
            // 
            this.lbScale.AutoSize = true;
            this.lbScale.Location = new System.Drawing.Point(3, 3);
            this.lbScale.Name = "lbScale";
            this.lbScale.Size = new System.Drawing.Size(34, 15);
            this.lbScale.TabIndex = 0;
            this.lbScale.Text = "Scale";
            // 
            // bufferPanel
            // 
            this.bufferPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bufferPanel.Location = new System.Drawing.Point(0, 0);
            this.bufferPanel.Name = "bufferPanel";
            this.bufferPanel.Size = new System.Drawing.Size(458, 278);
            this.bufferPanel.TabIndex = 1;
            this.bufferPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.bufferPanel_Paint);
            this.bufferPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bufferPanel_MouseDown);
            this.bufferPanel.MouseEnter += new System.EventHandler(this.bufferPanel_MouseEnter);
            this.bufferPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.bufferPanel_MouseMove);
            this.bufferPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bufferPanel_MouseUp);
            this.bufferPanel.Resize += new System.EventHandler(this.bufferPanel_Resize);
            // 
            // pnlMarks
            // 
            this.pnlMarks.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlMarks.Controls.Add(this.pnlMarksScroll);
            this.pnlMarks.Controls.Add(this.lbMarks);
            this.pnlMarks.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlMarks.Location = new System.Drawing.Point(458, 0);
            this.pnlMarks.Name = "pnlMarks";
            this.pnlMarks.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.pnlMarks.Size = new System.Drawing.Size(90, 300);
            this.pnlMarks.TabIndex = 5;
            // 
            // pnlMarksScroll
            // 
            this.pnlMarksScroll.AutoScroll = true;
            this.pnlMarksScroll.Controls.Add(this.pnlMarksList);
            this.pnlMarksScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMarksScroll.Location = new System.Drawing.Point(1, 28);
            this.pnlMarksScroll.Name = "pnlMarksScroll";
            this.pnlMarksScroll.Size = new System.Drawing.Size(88, 272);
            this.pnlMarksScroll.TabIndex = 5;
            // 
            // pnlMarksList
            // 
            this.pnlMarksList.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMarksList.Location = new System.Drawing.Point(0, 0);
            this.pnlMarksList.Name = "pnlMarksList";
            this.pnlMarksList.Size = new System.Drawing.Size(88, 134);
            this.pnlMarksList.TabIndex = 0;
            this.pnlMarksList.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.ImageListControlsChanged);
            this.pnlMarksList.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.ImageListControlsChanged);
            // 
            // lbMarks
            // 
            this.lbMarks.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbMarks.Location = new System.Drawing.Point(1, 0);
            this.lbMarks.Name = "lbMarks";
            this.lbMarks.Size = new System.Drawing.Size(88, 28);
            this.lbMarks.TabIndex = 4;
            this.lbMarks.Text = "Marks";
            this.lbMarks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbMarks.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintBottomLine);
            // 
            // ImageEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bufferPanel);
            this.Controls.Add(this.pnlStatus);
            this.Controls.Add(this.pnlMarks);
            this.Name = "ImageEditor";
            this.Size = new System.Drawing.Size(548, 300);
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.pnlMarks.ResumeLayout(false);
            this.pnlMarksScroll.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlStatus;
        private BufferPanel bufferPanel;
        private System.Windows.Forms.Label lbScale;
        private System.Windows.Forms.Panel pnlMarks;
        private System.Windows.Forms.Panel pnlMarksScroll;
        private System.Windows.Forms.Panel pnlMarksList;
        private System.Windows.Forms.Label lbMarks;
    }
}
