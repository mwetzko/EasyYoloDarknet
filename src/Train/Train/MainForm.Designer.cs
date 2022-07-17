using System.Windows.Forms;

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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlDiffer = new System.Windows.Forms.Panel();
            this.btnProjectOpen = new System.Windows.Forms.Button();
            this.btnProjectCreate = new System.Windows.Forms.Button();
            this.pnlProjectLabel = new System.Windows.Forms.Panel();
            this.lbProject = new System.Windows.Forms.Label();
            this.pnlClasses = new System.Windows.Forms.Panel();
            this.pnlClassesList = new System.Windows.Forms.Panel();
            this.pnlClassNamePadding = new System.Windows.Forms.Panel();
            this.txtNewClass = new System.Windows.Forms.TextBox();
            this.lbClasses = new System.Windows.Forms.Label();
            this.pnlImages = new System.Windows.Forms.Panel();
            this.pnlImagesList = new System.Windows.Forms.Panel();
            this.blImages = new System.Windows.Forms.Label();
            this.pnlPicture = new System.Windows.Forms.Panel();
            this.pnlControls.SuspendLayout();
            this.flowProject.SuspendLayout();
            this.pnlProjectLabel.SuspendLayout();
            this.pnlClasses.SuspendLayout();
            this.pnlClassNamePadding.SuspendLayout();
            this.pnlImages.SuspendLayout();
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
            this.lbProjectName.Size = new System.Drawing.Size(164, 15);
            this.lbProjectName.TabIndex = 0;
            this.lbProjectName.Text = "<Open project or create one>";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(184, 6);
            this.btnSave.Margin = new System.Windows.Forms.Padding(5, 1, 5, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(269, 6);
            this.btnClose.Margin = new System.Windows.Forms.Padding(5, 1, 5, 1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // pnlDiffer
            // 
            this.pnlDiffer.BackColor = System.Drawing.Color.Gray;
            this.pnlDiffer.Location = new System.Drawing.Point(354, 6);
            this.pnlDiffer.Margin = new System.Windows.Forms.Padding(5, 1, 5, 1);
            this.pnlDiffer.Name = "pnlDiffer";
            this.pnlDiffer.Size = new System.Drawing.Size(1, 23);
            this.pnlDiffer.TabIndex = 4;
            // 
            // btnProjectOpen
            // 
            this.btnProjectOpen.Location = new System.Drawing.Point(365, 6);
            this.btnProjectOpen.Margin = new System.Windows.Forms.Padding(5, 1, 5, 1);
            this.btnProjectOpen.Name = "btnProjectOpen";
            this.btnProjectOpen.Size = new System.Drawing.Size(75, 23);
            this.btnProjectOpen.TabIndex = 1;
            this.btnProjectOpen.Text = "Open";
            this.btnProjectOpen.UseVisualStyleBackColor = true;
            this.btnProjectOpen.Click += new System.EventHandler(this.btnProjectOpen_Click);
            // 
            // btnProjectCreate
            // 
            this.btnProjectCreate.Location = new System.Drawing.Point(450, 6);
            this.btnProjectCreate.Margin = new System.Windows.Forms.Padding(5, 1, 5, 1);
            this.btnProjectCreate.Name = "btnProjectCreate";
            this.btnProjectCreate.Size = new System.Drawing.Size(75, 23);
            this.btnProjectCreate.TabIndex = 2;
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
            this.pnlClasses.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlClasses.Controls.Add(this.pnlClassesList);
            this.pnlClasses.Controls.Add(this.pnlClassNamePadding);
            this.pnlClasses.Controls.Add(this.lbClasses);
            this.pnlClasses.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlClasses.Location = new System.Drawing.Point(904, 58);
            this.pnlClasses.Name = "pnlClasses";
            this.pnlClasses.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.pnlClasses.Size = new System.Drawing.Size(200, 583);
            this.pnlClasses.TabIndex = 1;
            // 
            // pnlClassesList
            // 
            this.pnlClassesList.AutoScroll = true;
            this.pnlClassesList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlClassesList.Location = new System.Drawing.Point(1, 58);
            this.pnlClassesList.Name = "pnlClassesList";
            this.pnlClassesList.Size = new System.Drawing.Size(198, 525);
            this.pnlClassesList.TabIndex = 4;
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
            this.pnlClassNamePadding.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlClassNamePadding_Paint);
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
            // 
            // pnlImages
            // 
            this.pnlImages.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlImages.Controls.Add(this.pnlImagesList);
            this.pnlImages.Controls.Add(this.blImages);
            this.pnlImages.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlImages.Location = new System.Drawing.Point(704, 58);
            this.pnlImages.Name = "pnlImages";
            this.pnlImages.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.pnlImages.Size = new System.Drawing.Size(200, 583);
            this.pnlImages.TabIndex = 2;
            // 
            // pnlImagesList
            // 
            this.pnlImagesList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlImagesList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImagesList.Location = new System.Drawing.Point(1, 28);
            this.pnlImagesList.Name = "pnlImagesList";
            this.pnlImagesList.Size = new System.Drawing.Size(198, 555);
            this.pnlImagesList.TabIndex = 4;
            // 
            // blImages
            // 
            this.blImages.Dock = System.Windows.Forms.DockStyle.Top;
            this.blImages.Location = new System.Drawing.Point(1, 0);
            this.blImages.Name = "blImages";
            this.blImages.Size = new System.Drawing.Size(198, 28);
            this.blImages.TabIndex = 3;
            this.blImages.Text = "Images";
            this.blImages.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlPicture
            // 
            this.pnlPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPicture.Location = new System.Drawing.Point(0, 58);
            this.pnlPicture.Name = "pnlPicture";
            this.pnlPicture.Size = new System.Drawing.Size(704, 583);
            this.pnlPicture.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 641);
            this.Controls.Add(this.pnlPicture);
            this.Controls.Add(this.pnlImages);
            this.Controls.Add(this.pnlClasses);
            this.Controls.Add(this.pnlControls);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Train";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.pnlControls.ResumeLayout(false);
            this.pnlControls.PerformLayout();
            this.flowProject.ResumeLayout(false);
            this.flowProject.PerformLayout();
            this.pnlProjectLabel.ResumeLayout(false);
            this.pnlProjectLabel.PerformLayout();
            this.pnlClasses.ResumeLayout(false);
            this.pnlClasses.PerformLayout();
            this.pnlClassNamePadding.ResumeLayout(false);
            this.pnlClassNamePadding.PerformLayout();
            this.pnlImages.ResumeLayout(false);
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
        private Panel pnlPicture;
        private Label lbClasses;
        private Label blImages;
        private TextBox txtNewClass;
        private Panel pnlImagesList;
        private Panel pnlClassesList;
        private Panel pnlClassNamePadding;
    }
}