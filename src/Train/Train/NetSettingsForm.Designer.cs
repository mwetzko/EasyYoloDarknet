namespace Train
{
    partial class NetSettingsForm
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
            this.tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lbBatch = new System.Windows.Forms.Label();
            this.lbNetwork = new System.Windows.Forms.Label();
            this.lbWidth = new System.Windows.Forms.Label();
            this.lbHeight = new System.Windows.Forms.Label();
            this.lbSubdivisions = new System.Windows.Forms.Label();
            this.numBatch = new System.Windows.Forms.NumericUpDown();
            this.numSubdivisions = new System.Windows.Forms.NumericUpDown();
            this.numWidth = new System.Windows.Forms.NumericUpDown();
            this.numHeight = new System.Windows.Forms.NumericUpDown();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBatch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSubdivisions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayout
            // 
            this.tableLayout.AutoSize = true;
            this.tableLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayout.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayout.ColumnCount = 2;
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayout.Controls.Add(this.lbBatch, 0, 1);
            this.tableLayout.Controls.Add(this.lbNetwork, 0, 0);
            this.tableLayout.Controls.Add(this.lbWidth, 0, 3);
            this.tableLayout.Controls.Add(this.lbHeight, 0, 4);
            this.tableLayout.Controls.Add(this.lbSubdivisions, 0, 2);
            this.tableLayout.Controls.Add(this.numBatch, 1, 1);
            this.tableLayout.Controls.Add(this.numSubdivisions, 1, 2);
            this.tableLayout.Controls.Add(this.numWidth, 1, 3);
            this.tableLayout.Controls.Add(this.numHeight, 1, 4);
            this.tableLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayout.Location = new System.Drawing.Point(0, 0);
            this.tableLayout.Name = "tableLayout";
            this.tableLayout.RowCount = 5;
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayout.Size = new System.Drawing.Size(284, 147);
            this.tableLayout.TabIndex = 0;
            // 
            // lbBatch
            // 
            this.lbBatch.AutoSize = true;
            this.lbBatch.Location = new System.Drawing.Point(6, 32);
            this.lbBatch.Margin = new System.Windows.Forms.Padding(5);
            this.lbBatch.Name = "lbBatch";
            this.lbBatch.Size = new System.Drawing.Size(37, 15);
            this.lbBatch.TabIndex = 2;
            this.lbBatch.Text = "Batch";
            // 
            // lbNetwork
            // 
            this.lbNetwork.AutoSize = true;
            this.lbNetwork.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbNetwork.Location = new System.Drawing.Point(6, 6);
            this.lbNetwork.Margin = new System.Windows.Forms.Padding(5);
            this.lbNetwork.Name = "lbNetwork";
            this.lbNetwork.Size = new System.Drawing.Size(57, 15);
            this.lbNetwork.TabIndex = 1;
            this.lbNetwork.Text = "Network";
            // 
            // lbWidth
            // 
            this.lbWidth.AutoSize = true;
            this.lbWidth.Location = new System.Drawing.Point(6, 92);
            this.lbWidth.Margin = new System.Windows.Forms.Padding(5);
            this.lbWidth.Name = "lbWidth";
            this.lbWidth.Size = new System.Drawing.Size(39, 15);
            this.lbWidth.TabIndex = 6;
            this.lbWidth.Text = "Width";
            // 
            // lbHeight
            // 
            this.lbHeight.AutoSize = true;
            this.lbHeight.Location = new System.Drawing.Point(6, 122);
            this.lbHeight.Margin = new System.Windows.Forms.Padding(5);
            this.lbHeight.Name = "lbHeight";
            this.lbHeight.Size = new System.Drawing.Size(43, 15);
            this.lbHeight.TabIndex = 8;
            this.lbHeight.Text = "Height";
            // 
            // lbSubdivisions
            // 
            this.lbSubdivisions.AutoSize = true;
            this.lbSubdivisions.Location = new System.Drawing.Point(6, 62);
            this.lbSubdivisions.Margin = new System.Windows.Forms.Padding(5);
            this.lbSubdivisions.Name = "lbSubdivisions";
            this.lbSubdivisions.Size = new System.Drawing.Size(73, 15);
            this.lbSubdivisions.TabIndex = 4;
            this.lbSubdivisions.Text = "Subdivisions";
            // 
            // numBatch
            // 
            this.numBatch.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numBatch.Location = new System.Drawing.Point(88, 30);
            this.numBatch.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numBatch.Name = "numBatch";
            this.numBatch.Size = new System.Drawing.Size(120, 23);
            this.numBatch.TabIndex = 3;
            this.numBatch.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            // 
            // numSubdivisions
            // 
            this.numSubdivisions.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numSubdivisions.Location = new System.Drawing.Point(88, 60);
            this.numSubdivisions.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numSubdivisions.Name = "numSubdivisions";
            this.numSubdivisions.Size = new System.Drawing.Size(120, 23);
            this.numSubdivisions.TabIndex = 5;
            this.numSubdivisions.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // numWidth
            // 
            this.numWidth.Increment = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numWidth.Location = new System.Drawing.Point(88, 90);
            this.numWidth.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            this.numWidth.Name = "numWidth";
            this.numWidth.Size = new System.Drawing.Size(120, 23);
            this.numWidth.TabIndex = 7;
            this.numWidth.Value = new decimal(new int[] {
            416,
            0,
            0,
            0});
            // 
            // numHeight
            // 
            this.numHeight.Increment = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numHeight.Location = new System.Drawing.Point(88, 120);
            this.numHeight.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            this.numHeight.Name = "numHeight";
            this.numHeight.Size = new System.Drawing.Size(120, 23);
            this.numHeight.TabIndex = 9;
            this.numHeight.Value = new decimal(new int[] {
            416,
            0,
            0,
            0});
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(116, 153);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(197, 153);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // NetSettingsForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(284, 183);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.tableLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "NetSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Train | Network Settings";
            this.tableLayout.ResumeLayout(false);
            this.tableLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBatch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSubdivisions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayout;
        private System.Windows.Forms.Label lbBatch;
        private System.Windows.Forms.Label lbNetwork;
        private System.Windows.Forms.Label lbWidth;
        private System.Windows.Forms.Label lbHeight;
        private System.Windows.Forms.Label lbSubdivisions;
        private System.Windows.Forms.NumericUpDown numBatch;
        private System.Windows.Forms.NumericUpDown numSubdivisions;
        private System.Windows.Forms.NumericUpDown numWidth;
        private System.Windows.Forms.NumericUpDown numHeight;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}