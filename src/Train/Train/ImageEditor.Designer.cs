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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbScale = new System.Windows.Forms.Label();
            this.bufferPanel = new Train.BufferPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbScale);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 278);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(548, 22);
            this.panel1.TabIndex = 0;
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
            this.bufferPanel.Size = new System.Drawing.Size(548, 278);
            this.bufferPanel.TabIndex = 1;
            this.bufferPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.bufferPanel_Paint);
            this.bufferPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bufferPanel_MouseDown);
            this.bufferPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.bufferPanel_MouseMove);
            this.bufferPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bufferPanel_MouseUp);
            this.bufferPanel.Resize += new System.EventHandler(this.bufferPanel_Resize);
            // 
            // ImageEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bufferPanel);
            this.Controls.Add(this.panel1);
            this.Name = "ImageEditor";
            this.Size = new System.Drawing.Size(548, 300);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private BufferPanel bufferPanel;
        private System.Windows.Forms.Label lbScale;
    }
}
