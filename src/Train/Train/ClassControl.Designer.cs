namespace Train
{
    partial class ClassControl
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
            this.components = new System.ComponentModel.Container();
            this.btnColorPicker = new System.Windows.Forms.Button();
            this.tablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.txtClassname = new System.Windows.Forms.TextBox();
            this.tablePanelButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRename = new System.Windows.Forms.Button();
            this.colorPicker = new System.Windows.Forms.ColorDialog();
            this.tipRename = new System.Windows.Forms.ToolTip(this.components);
            this.tipOk = new System.Windows.Forms.ToolTip(this.components);
            this.tipCancel = new System.Windows.Forms.ToolTip(this.components);
            this.tipDelete = new System.Windows.Forms.ToolTip(this.components);
            this.tipColorPicker = new System.Windows.Forms.ToolTip(this.components);
            this.tablePanel.SuspendLayout();
            this.tablePanelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnColorPicker
            // 
            this.btnColorPicker.Location = new System.Drawing.Point(316, 3);
            this.btnColorPicker.Name = "btnColorPicker";
            this.btnColorPicker.Size = new System.Drawing.Size(23, 23);
            this.btnColorPicker.TabIndex = 0;
            this.tipColorPicker.SetToolTip(this.btnColorPicker, "Color Picker");
            this.btnColorPicker.UseVisualStyleBackColor = true;
            this.btnColorPicker.Click += new System.EventHandler(this.btnColorPicker_Click);
            // 
            // tablePanel
            // 
            this.tablePanel.AutoSize = true;
            this.tablePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tablePanel.ColumnCount = 3;
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tablePanel.Controls.Add(this.btnColorPicker, 2, 0);
            this.tablePanel.Controls.Add(this.txtClassname, 0, 0);
            this.tablePanel.Controls.Add(this.tablePanelButtons, 1, 0);
            this.tablePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tablePanel.Location = new System.Drawing.Point(0, 0);
            this.tablePanel.Name = "tablePanel";
            this.tablePanel.RowCount = 1;
            this.tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablePanel.Size = new System.Drawing.Size(342, 29);
            this.tablePanel.TabIndex = 1;
            // 
            // txtClassname
            // 
            this.txtClassname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClassname.Location = new System.Drawing.Point(3, 3);
            this.txtClassname.Name = "txtClassname";
            this.txtClassname.Size = new System.Drawing.Size(191, 23);
            this.txtClassname.TabIndex = 2;
            this.txtClassname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtClassname_KeyDown);
            // 
            // tablePanelButtons
            // 
            this.tablePanelButtons.AutoSize = true;
            this.tablePanelButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tablePanelButtons.ColumnCount = 4;
            this.tablePanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tablePanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tablePanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tablePanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tablePanelButtons.Controls.Add(this.btnOk, 1, 0);
            this.tablePanelButtons.Controls.Add(this.btnDelete, 3, 0);
            this.tablePanelButtons.Controls.Add(this.btnCancel, 2, 0);
            this.tablePanelButtons.Controls.Add(this.btnRename, 0, 0);
            this.tablePanelButtons.Location = new System.Drawing.Point(197, 0);
            this.tablePanelButtons.Margin = new System.Windows.Forms.Padding(0);
            this.tablePanelButtons.Name = "tablePanelButtons";
            this.tablePanelButtons.RowCount = 1;
            this.tablePanelButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablePanelButtons.Size = new System.Drawing.Size(116, 29);
            this.tablePanelButtons.TabIndex = 3;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(32, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(23, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "✔";
            this.tipOk.SetToolTip(this.btnOk, "Accept name change");
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(90, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(23, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "🗑";
            this.tipDelete.SetToolTip(this.btnDelete, "Delete class");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(61, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(23, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "✖";
            this.tipCancel.SetToolTip(this.btnCancel, "Discard name change");
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRename
            // 
            this.btnRename.Location = new System.Drawing.Point(3, 3);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(23, 23);
            this.btnRename.TabIndex = 1;
            this.btnRename.Text = "✒";
            this.tipRename.SetToolTip(this.btnRename, "Rename class");
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // ClassControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tablePanel);
            this.Name = "ClassControl";
            this.Size = new System.Drawing.Size(342, 106);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ClassControl_Paint);
            this.Resize += new System.EventHandler(this.ClassControl_Resize);
            this.tablePanel.ResumeLayout(false);
            this.tablePanel.PerformLayout();
            this.tablePanelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnColorPicker;
        private System.Windows.Forms.TableLayoutPanel tablePanel;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.TextBox txtClassname;
        private System.Windows.Forms.ColorDialog colorPicker;
        private System.Windows.Forms.TableLayoutPanel tablePanelButtons;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolTip tipRename;
        private System.Windows.Forms.ToolTip tipOk;
        private System.Windows.Forms.ToolTip tipCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ToolTip tipDelete;
        private System.Windows.Forms.ToolTip tipColorPicker;
    }
}
