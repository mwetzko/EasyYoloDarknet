namespace Train
{
    partial class TrainForm
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
            this.txtOut = new System.Windows.Forms.TextBox();
            this.txtErr = new System.Windows.Forms.TextBox();
            this.tblLayout = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbStatus = new System.Windows.Forms.Label();
            this.tblLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtOut
            // 
            this.txtOut.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtOut.Location = new System.Drawing.Point(12, 12);
            this.txtOut.MaxLength = 2147483647;
            this.txtOut.Multiline = true;
            this.txtOut.Name = "txtOut";
            this.txtOut.ReadOnly = true;
            this.txtOut.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOut.Size = new System.Drawing.Size(760, 153);
            this.txtOut.TabIndex = 0;
            // 
            // txtErr
            // 
            this.txtErr.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtErr.ForeColor = System.Drawing.Color.DarkRed;
            this.txtErr.Location = new System.Drawing.Point(12, 171);
            this.txtErr.MaxLength = 2147483647;
            this.txtErr.Multiline = true;
            this.txtErr.Name = "txtErr";
            this.txtErr.ReadOnly = true;
            this.txtErr.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtErr.Size = new System.Drawing.Size(760, 153);
            this.txtErr.TabIndex = 1;
            // 
            // tblLayout
            // 
            this.tblLayout.ColumnCount = 3;
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLayout.Controls.Add(this.btnCancel, 1, 1);
            this.tblLayout.Controls.Add(this.lbStatus, 0, 0);
            this.tblLayout.Location = new System.Drawing.Point(12, 330);
            this.tblLayout.Name = "tblLayout";
            this.tblLayout.RowCount = 2;
            this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblLayout.Size = new System.Drawing.Size(760, 64);
            this.tblLayout.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(342, 41);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lbStatus
            // 
            this.tblLayout.SetColumnSpan(this.lbStatus, 3);
            this.lbStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbStatus.Location = new System.Drawing.Point(3, 0);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(754, 41);
            this.lbStatus.TabIndex = 1;
            this.lbStatus.Text = "Training...";
            this.lbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TrainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 406);
            this.Controls.Add(this.tblLayout);
            this.Controls.Add(this.txtErr);
            this.Controls.Add(this.txtOut);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TrainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Train | Training";
            this.tblLayout.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtOut;
        private System.Windows.Forms.TextBox txtErr;
        private System.Windows.Forms.TableLayoutPanel tblLayout;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbStatus;
    }
}