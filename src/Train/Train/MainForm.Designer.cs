﻿using System.Windows.Forms;

namespace Train
{
    partial class MainForm
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
            this.pnlControls = new System.Windows.Forms.Panel();
            this.flowProject = new System.Windows.Forms.FlowLayoutPanel();
            this.lbProjectName = new System.Windows.Forms.Label();
            this.btnTrain = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlDiffer = new System.Windows.Forms.Panel();
            this.btnProjectOpen = new System.Windows.Forms.Button();
            this.btnProjectCreate = new System.Windows.Forms.Button();
            this.pnlProjectLabel = new System.Windows.Forms.Panel();
            this.lbProject = new System.Windows.Forms.Label();
            this.pnlClasses = new System.Windows.Forms.Panel();
            this.pnlClassesScroll = new System.Windows.Forms.Panel();
            this.pnlClassesList = new System.Windows.Forms.Panel();
            this.pnlClassNamePadding = new System.Windows.Forms.Panel();
            this.txtNewClass = new System.Windows.Forms.TextBox();
            this.lbClasses = new System.Windows.Forms.Label();
            this.pnlImages = new System.Windows.Forms.Panel();
            this.pnlImagesScroll = new System.Windows.Forms.Panel();
            this.pnlImagesList = new System.Windows.Forms.Panel();
            this.pnlImagesAdd = new System.Windows.Forms.Panel();
            this.tblAddImage = new System.Windows.Forms.TableLayoutPanel();
            this.btnImageFromClipboard = new System.Windows.Forms.Button();
            this.btnImageFromFile = new System.Windows.Forms.Button();
            this.lbImages = new System.Windows.Forms.Label();
            this.imageEditor = new Train.ImageEditor();
            this.pnlControls.SuspendLayout();
            this.flowProject.SuspendLayout();
            this.pnlProjectLabel.SuspendLayout();
            this.pnlClasses.SuspendLayout();
            this.pnlClassesScroll.SuspendLayout();
            this.pnlClassNamePadding.SuspendLayout();
            this.pnlImages.SuspendLayout();
            this.pnlImagesScroll.SuspendLayout();
            this.pnlImagesAdd.SuspendLayout();
            this.tblAddImage.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlControls
            // 
            this.pnlControls.BackColor = System.Drawing.Color.LightGray;
            this.pnlControls.Controls.Add(this.flowProject);
            this.pnlControls.Controls.Add(this.pnlProjectLabel);
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControls.Location = new System.Drawing.Point(0, 0);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(1104, 58);
            this.pnlControls.TabIndex = 0;
            // 
            // flowProject
            // 
            this.flowProject.AutoSize = true;
            this.flowProject.Controls.Add(this.lbProjectName);
            this.flowProject.Controls.Add(this.btnTrain);
            this.flowProject.Controls.Add(this.btnSave);
            this.flowProject.Controls.Add(this.btnClose);
            this.flowProject.Controls.Add(this.pnlDiffer);
            this.flowProject.Controls.Add(this.btnProjectOpen);
            this.flowProject.Controls.Add(this.btnProjectCreate);
            this.flowProject.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowProject.Location = new System.Drawing.Point(56, 0);
            this.flowProject.Name = "flowProject";
            this.flowProject.Padding = new System.Windows.Forms.Padding(5);
            this.flowProject.Size = new System.Drawing.Size(1048, 35);
            this.flowProject.TabIndex = 1;
            // 
            // lbProjectName
            // 
            this.lbProjectName.AutoSize = true;
            this.lbProjectName.Location = new System.Drawing.Point(10, 10);
            this.lbProjectName.Margin = new System.Windows.Forms.Padding(5);
            this.lbProjectName.Name = "lbProjectName";
            this.lbProjectName.Size = new System.Drawing.Size(23, 15);
            this.lbProjectName.TabIndex = 0;
            this.lbProjectName.Text = "<>";
            // 
            // btnTrain
            // 
            this.btnTrain.Location = new System.Drawing.Point(43, 6);
            this.btnTrain.Margin = new System.Windows.Forms.Padding(5, 1, 5, 1);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(75, 23);
            this.btnTrain.TabIndex = 1;
            this.btnTrain.Text = "Train";
            this.btnTrain.UseVisualStyleBackColor = true;
            this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(128, 6);
            this.btnSave.Margin = new System.Windows.Forms.Padding(5, 1, 5, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(213, 6);
            this.btnClose.Margin = new System.Windows.Forms.Padding(5, 1, 5, 1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlDiffer
            // 
            this.pnlDiffer.BackColor = System.Drawing.Color.Gray;
            this.pnlDiffer.Location = new System.Drawing.Point(298, 6);
            this.pnlDiffer.Margin = new System.Windows.Forms.Padding(5, 1, 5, 1);
            this.pnlDiffer.Name = "pnlDiffer";
            this.pnlDiffer.Size = new System.Drawing.Size(1, 23);
            this.pnlDiffer.TabIndex = 4;
            // 
            // btnProjectOpen
            // 
            this.btnProjectOpen.Location = new System.Drawing.Point(309, 6);
            this.btnProjectOpen.Margin = new System.Windows.Forms.Padding(5, 1, 5, 1);
            this.btnProjectOpen.Name = "btnProjectOpen";
            this.btnProjectOpen.Size = new System.Drawing.Size(75, 23);
            this.btnProjectOpen.TabIndex = 5;
            this.btnProjectOpen.Text = "Open";
            this.btnProjectOpen.UseVisualStyleBackColor = true;
            this.btnProjectOpen.Click += new System.EventHandler(this.btnProjectOpen_Click);
            // 
            // btnProjectCreate
            // 
            this.btnProjectCreate.Location = new System.Drawing.Point(394, 6);
            this.btnProjectCreate.Margin = new System.Windows.Forms.Padding(5, 1, 5, 1);
            this.btnProjectCreate.Name = "btnProjectCreate";
            this.btnProjectCreate.Size = new System.Drawing.Size(75, 23);
            this.btnProjectCreate.TabIndex = 6;
            this.btnProjectCreate.Text = "Create";
            this.btnProjectCreate.UseVisualStyleBackColor = true;
            this.btnProjectCreate.Click += new System.EventHandler(this.btnProjectCreate_Click);
            // 
            // pnlProjectLabel
            // 
            this.pnlProjectLabel.AutoSize = true;
            this.pnlProjectLabel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlProjectLabel.Controls.Add(this.lbProject);
            this.pnlProjectLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlProjectLabel.Location = new System.Drawing.Point(0, 0);
            this.pnlProjectLabel.Name = "pnlProjectLabel";
            this.pnlProjectLabel.Size = new System.Drawing.Size(56, 58);
            this.pnlProjectLabel.TabIndex = 0;
            // 
            // lbProject
            // 
            this.lbProject.AutoSize = true;
            this.lbProject.Location = new System.Drawing.Point(9, 10);
            this.lbProject.Margin = new System.Windows.Forms.Padding(10, 10, 0, 10);
            this.lbProject.Name = "lbProject";
            this.lbProject.Size = new System.Drawing.Size(47, 15);
            this.lbProject.TabIndex = 0;
            this.lbProject.Text = "Project:";
            // 
            // pnlClasses
            // 
            this.pnlClasses.BackColor = System.Drawing.Color.LightGray;
            this.pnlClasses.Controls.Add(this.pnlClassesScroll);
            this.pnlClasses.Controls.Add(this.pnlClassNamePadding);
            this.pnlClasses.Controls.Add(this.lbClasses);
            this.pnlClasses.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlClasses.Location = new System.Drawing.Point(904, 58);
            this.pnlClasses.Name = "pnlClasses";
            this.pnlClasses.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.pnlClasses.Size = new System.Drawing.Size(200, 583);
            this.pnlClasses.TabIndex = 1;
            // 
            // pnlClassesScroll
            // 
            this.pnlClassesScroll.AutoScroll = true;
            this.pnlClassesScroll.Controls.Add(this.pnlClassesList);
            this.pnlClassesScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlClassesScroll.Location = new System.Drawing.Point(1, 58);
            this.pnlClassesScroll.Name = "pnlClassesScroll";
            this.pnlClassesScroll.Size = new System.Drawing.Size(198, 525);
            this.pnlClassesScroll.TabIndex = 6;
            // 
            // pnlClassesList
            // 
            this.pnlClassesList.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlClassesList.Location = new System.Drawing.Point(0, 0);
            this.pnlClassesList.Name = "pnlClassesList";
            this.pnlClassesList.Size = new System.Drawing.Size(198, 388);
            this.pnlClassesList.TabIndex = 4;
            this.pnlClassesList.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.ClassesListControlsChanged);
            this.pnlClassesList.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.ClassesListControlsChanged);
            // 
            // pnlClassNamePadding
            // 
            this.pnlClassNamePadding.AutoSize = true;
            this.pnlClassNamePadding.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlClassNamePadding.Controls.Add(this.txtNewClass);
            this.pnlClassNamePadding.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlClassNamePadding.Location = new System.Drawing.Point(1, 28);
            this.pnlClassNamePadding.Name = "pnlClassNamePadding";
            this.pnlClassNamePadding.Padding = new System.Windows.Forms.Padding(3, 3, 3, 4);
            this.pnlClassNamePadding.Size = new System.Drawing.Size(198, 30);
            this.pnlClassNamePadding.TabIndex = 5;
            this.pnlClassNamePadding.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintBottomLine);
            // 
            // txtNewClass
            // 
            this.txtNewClass.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtNewClass.Location = new System.Drawing.Point(3, 3);
            this.txtNewClass.Name = "txtNewClass";
            this.txtNewClass.Size = new System.Drawing.Size(192, 23);
            this.txtNewClass.TabIndex = 3;
            this.txtNewClass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNewClass_KeyDown);
            // 
            // lbClasses
            // 
            this.lbClasses.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbClasses.Location = new System.Drawing.Point(1, 0);
            this.lbClasses.Name = "lbClasses";
            this.lbClasses.Size = new System.Drawing.Size(198, 28);
            this.lbClasses.TabIndex = 2;
            this.lbClasses.Text = "Classes";
            this.lbClasses.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbClasses.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintBottomLine);
            // 
            // pnlImages
            // 
            this.pnlImages.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlImages.Controls.Add(this.pnlImagesScroll);
            this.pnlImages.Controls.Add(this.pnlImagesAdd);
            this.pnlImages.Controls.Add(this.lbImages);
            this.pnlImages.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlImages.Location = new System.Drawing.Point(704, 58);
            this.pnlImages.Name = "pnlImages";
            this.pnlImages.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.pnlImages.Size = new System.Drawing.Size(200, 583);
            this.pnlImages.TabIndex = 2;
            // 
            // pnlImagesScroll
            // 
            this.pnlImagesScroll.AutoScroll = true;
            this.pnlImagesScroll.Controls.Add(this.pnlImagesList);
            this.pnlImagesScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImagesScroll.Location = new System.Drawing.Point(1, 58);
            this.pnlImagesScroll.Name = "pnlImagesScroll";
            this.pnlImagesScroll.Size = new System.Drawing.Size(198, 525);
            this.pnlImagesScroll.TabIndex = 6;
            // 
            // pnlImagesList
            // 
            this.pnlImagesList.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlImagesList.Location = new System.Drawing.Point(0, 0);
            this.pnlImagesList.Name = "pnlImagesList";
            this.pnlImagesList.Size = new System.Drawing.Size(198, 388);
            this.pnlImagesList.TabIndex = 4;
            this.pnlImagesList.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.ImageListControlsChanged);
            this.pnlImagesList.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.ImageListControlsChanged);
            // 
            // pnlImagesAdd
            // 
            this.pnlImagesAdd.AutoSize = true;
            this.pnlImagesAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlImagesAdd.Controls.Add(this.tblAddImage);
            this.pnlImagesAdd.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlImagesAdd.Location = new System.Drawing.Point(1, 28);
            this.pnlImagesAdd.Name = "pnlImagesAdd";
            this.pnlImagesAdd.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.pnlImagesAdd.Size = new System.Drawing.Size(198, 30);
            this.pnlImagesAdd.TabIndex = 5;
            this.pnlImagesAdd.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintBottomLine);
            // 
            // tblAddImage
            // 
            this.tblAddImage.AutoSize = true;
            this.tblAddImage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tblAddImage.ColumnCount = 2;
            this.tblAddImage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblAddImage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblAddImage.Controls.Add(this.btnImageFromClipboard, 1, 0);
            this.tblAddImage.Controls.Add(this.btnImageFromFile, 0, 0);
            this.tblAddImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.tblAddImage.Location = new System.Drawing.Point(0, 0);
            this.tblAddImage.Margin = new System.Windows.Forms.Padding(0);
            this.tblAddImage.Name = "tblAddImage";
            this.tblAddImage.RowCount = 1;
            this.tblAddImage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblAddImage.Size = new System.Drawing.Size(198, 29);
            this.tblAddImage.TabIndex = 0;
            // 
            // btnImageFromClipboard
            // 
            this.btnImageFromClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImageFromClipboard.Location = new System.Drawing.Point(84, 3);
            this.btnImageFromClipboard.Name = "btnImageFromClipboard";
            this.btnImageFromClipboard.Size = new System.Drawing.Size(111, 23);
            this.btnImageFromClipboard.TabIndex = 1;
            this.btnImageFromClipboard.Text = "From Clipboard";
            this.btnImageFromClipboard.UseVisualStyleBackColor = true;
            this.btnImageFromClipboard.Click += new System.EventHandler(this.btnImageFromClipboard_Click);
            // 
            // btnImageFromFile
            // 
            this.btnImageFromFile.Location = new System.Drawing.Point(3, 3);
            this.btnImageFromFile.Name = "btnImageFromFile";
            this.btnImageFromFile.Size = new System.Drawing.Size(75, 23);
            this.btnImageFromFile.TabIndex = 0;
            this.btnImageFromFile.Text = "From File";
            this.btnImageFromFile.UseVisualStyleBackColor = true;
            this.btnImageFromFile.Click += new System.EventHandler(this.btnImageFromFile_Click);
            // 
            // lbImages
            // 
            this.lbImages.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbImages.Location = new System.Drawing.Point(1, 0);
            this.lbImages.Name = "lbImages";
            this.lbImages.Size = new System.Drawing.Size(198, 28);
            this.lbImages.TabIndex = 3;
            this.lbImages.Text = "Images";
            this.lbImages.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbImages.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintBottomLine);
            // 
            // imageEditor
            // 
            this.imageEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageEditor.ImageControl = null;
            this.imageEditor.Location = new System.Drawing.Point(0, 58);
            this.imageEditor.Name = "imageEditor";
            this.imageEditor.Size = new System.Drawing.Size(704, 583);
            this.imageEditor.TabIndex = 3;
            this.imageEditor.GetImageClassName += new System.EventHandler<Train.GetImageClassNameArgs>(this.imageEditor_GetImageClassName);
            this.imageEditor.DeleteMarks += new System.EventHandler(this.imageEditor_DeleteMarks);
            this.imageEditor.ResizeMarks += new System.EventHandler(this.imageEditor_ResizeMarks);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 641);
            this.Controls.Add(this.imageEditor);
            this.Controls.Add(this.pnlImages);
            this.Controls.Add(this.pnlClasses);
            this.Controls.Add(this.pnlControls);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Train";
            this.pnlControls.ResumeLayout(false);
            this.pnlControls.PerformLayout();
            this.flowProject.ResumeLayout(false);
            this.flowProject.PerformLayout();
            this.pnlProjectLabel.ResumeLayout(false);
            this.pnlProjectLabel.PerformLayout();
            this.pnlClasses.ResumeLayout(false);
            this.pnlClasses.PerformLayout();
            this.pnlClassesScroll.ResumeLayout(false);
            this.pnlClassNamePadding.ResumeLayout(false);
            this.pnlClassNamePadding.PerformLayout();
            this.pnlImages.ResumeLayout(false);
            this.pnlImages.PerformLayout();
            this.pnlImagesScroll.ResumeLayout(false);
            this.pnlImagesAdd.ResumeLayout(false);
            this.pnlImagesAdd.PerformLayout();
            this.tblAddImage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlControls;
        private Panel pnlProjectLabel;
        private Label lbProject;
        private FlowLayoutPanel flowProject;
        private Label lbProjectName;
        private Button btnProjectOpen;
        private Button btnProjectCreate;
        private Button btnSave;
        private Panel pnlDiffer;
        private Button btnClose;
        private Panel pnlClasses;
        private Panel pnlImages;
        private Label lbClasses;
        private Label lbImages;
        private TextBox txtNewClass;
        private Panel pnlImagesList;
        private Panel pnlClassesList;
        private Panel pnlClassNamePadding;
        private Panel pnlClassesScroll;
        private Panel pnlImagesScroll;
        private Panel pnlImagesAdd;
        private Button btnImageFromFile;
        private Button btnImageFromClipboard;
        private TableLayoutPanel tblAddImage;
        private ImageEditor imageEditor;
        private Button btnTrain;
    }
}