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
            this.tblActions = new System.Windows.Forms.TableLayoutPanel();
            this.txtClassname = new System.Windows.Forms.TextBox();
            this.tblPanelButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRename = new System.Windows.Forms.Button();
            this.rbSelect = new System.Windows.Forms.RadioButton();
            this.colorPicker = new System.Windows.Forms.ColorDialog();
            this.tipRename = new System.Windows.Forms.ToolTip(this.components);
            this.tipOk = new System.Windows.Forms.ToolTip(this.components);
            this.tipCancel = new System.Windows.Forms.ToolTip(this.components);
            this.tipDelete = new System.Windows.Forms.ToolTip(this.components);
            this.tipColorPicker = new System.Windows.Forms.ToolTip(this.components);
            this.tblActions.SuspendLayout();
            this.tblPanelButtons.SuspendLayout();
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
            // tblActions
            // 
            this.tblActions.AutoSize = true;
            this.tblActions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tblActions.ColumnCount = 4;
            this.tblActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblActions.Controls.Add(this.btnColorPicker, 3, 0);
            this.tblActions.Controls.Add(this.txtClassname, 1, 0);
            this.tblActions.Controls.Add(this.tblPanelButtons, 2, 0);
            this.tblActions.Controls.Add(this.rbSelect, 0, 0);
            this.tblActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.tblActions.Location = new System.Drawing.Point(0, 0);
            this.tblActions.Name = "tblActions";
            this.tblActions.RowCount = 1;
            this.tblActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblActions.Size = new System.Drawing.Size(342, 29);
            this.tblActions.TabIndex = 1;
            // 
            // txtClassname
            // 
            this.txtClassname.Location = new System.Drawing.Point(33, 3);
            this.txtClassname.Name = "txtClassname";
            this.txtClassname.Size = new System.Drawing.Size(161, 23);
            this.txtClassname.TabIndex = 2;
            this.txtClassname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtClassname_KeyDown);
            // 
            // tblPanelButtons
            // 
            this.tblPanelButtons.AutoSize = true;
            this.tblPanelButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tblPanelButtons.ColumnCount = 4;
            this.tblPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblPanelButtons.Controls.Add(this.btnOk, 1, 0);
            this.tblPanelButtons.Controls.Add(this.btnDelete, 3, 0);
            this.tblPanelButtons.Controls.Add(this.btnCancel, 2, 0);
            this.tblPanelButtons.Controls.Add(this.btnRename, 0, 0);
            this.tblPanelButtons.Location = new System.Drawing.Point(197, 0);
            this.tblPanelButtons.Margin = new System.Windows.Forms.Padding(0);
            this.tblPanelButtons.Name = "tblPanelButtons";
            this.tblPanelButtons.RowCount = 1;
            this.tblPanelButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblPanelButtons.Size = new System.Drawing.Size(116, 29);
            this.tblPanelButtons.TabIndex = 3;
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
            // rbSelect
            // 
            this.rbSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rbSelect.AutoSize = true;
            this.rbSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbSelect.Location = new System.Drawing.Point(3, 3);
            this.rbSelect.Name = "rbSelect";
            this.rbSelect.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.rbSelect.Size = new System.Drawing.Size(24, 23);
            this.rbSelect.TabIndex = 4;
            this.rbSelect.TabStop = true;
            this.rbSelect.UseVisualStyleBackColor = true;
            this.rbSelect.CheckedChanged += new System.EventHandler(this.rbSelect_CheckedChanged);
            // 
            // ClassControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tblActions);
            this.Name = "ClassControl";
            this.Size = new System.Drawing.Size(342, 106);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ClassControl_Paint);
            this.Resize += new System.EventHandler(this.ClassControl_Resize);
            this.tblActions.ResumeLayout(false);
            this.tblActions.PerformLayout();
            this.tblPanelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnColorPicker;
        private System.Windows.Forms.TableLayoutPanel tblActions;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.TextBox txtClassname;
        private System.Windows.Forms.ColorDialog colorPicker;
        private System.Windows.Forms.TableLayoutPanel tblPanelButtons;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolTip tipRename;
        private System.Windows.Forms.ToolTip tipOk;
        private System.Windows.Forms.ToolTip tipCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ToolTip tipDelete;
        private System.Windows.Forms.ToolTip tipColorPicker;
        private System.Windows.Forms.RadioButton rbSelect;
    }
}
