namespace Train
{
    partial class MarkControl
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
            this.tblInfo = new System.Windows.Forms.TableLayoutPanel();
            this.pnlColor = new System.Windows.Forms.Panel();
            this.lbText = new System.Windows.Forms.Label();
            this.tblInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblInfo
            // 
            this.tblInfo.AutoSize = true;
            this.tblInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tblInfo.ColumnCount = 2;
            this.tblInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblInfo.Controls.Add(this.pnlColor, 0, 0);
            this.tblInfo.Controls.Add(this.lbText, 1, 0);
            this.tblInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.tblInfo.Location = new System.Drawing.Point(0, 0);
            this.tblInfo.Name = "tblInfo";
            this.tblInfo.RowCount = 1;
            this.tblInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblInfo.Size = new System.Drawing.Size(165, 22);
            this.tblInfo.TabIndex = 0;
            this.tblInfo.MouseEnter += new System.EventHandler(this.ControlMouseEnter);
            this.tblInfo.MouseLeave += new System.EventHandler(this.ControlMouseLeave);
            // 
            // pnlColor
            // 
            this.pnlColor.Location = new System.Drawing.Point(3, 3);
            this.pnlColor.Name = "pnlColor";
            this.pnlColor.Size = new System.Drawing.Size(16, 16);
            this.pnlColor.TabIndex = 0;
            this.pnlColor.MouseEnter += new System.EventHandler(this.ControlMouseEnter);
            this.pnlColor.MouseLeave += new System.EventHandler(this.ControlMouseLeave);
            // 
            // lbText
            // 
            this.lbText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbText.AutoSize = true;
            this.lbText.Location = new System.Drawing.Point(25, 0);
            this.lbText.Name = "lbText";
            this.lbText.Size = new System.Drawing.Size(38, 22);
            this.lbText.TabIndex = 1;
            this.lbText.Text = "label1";
            this.lbText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbText.MouseEnter += new System.EventHandler(this.ControlMouseEnter);
            this.lbText.MouseLeave += new System.EventHandler(this.ControlMouseLeave);
            // 
            // MarkControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tblInfo);
            this.Name = "MarkControl";
            this.Size = new System.Drawing.Size(165, 35);
            this.MouseEnter += new System.EventHandler(this.MarkControl_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.MarkControl_MouseLeave);
            this.tblInfo.ResumeLayout(false);
            this.tblInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblInfo;
        private System.Windows.Forms.Panel pnlColor;
        private System.Windows.Forms.Label lbText;
    }
}
