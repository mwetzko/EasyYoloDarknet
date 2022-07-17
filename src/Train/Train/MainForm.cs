using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Train
{
    public partial class MainForm : Form
    {
        const string FORM_NAME = "Train";

        string mCurrentProjectFile;
        ProjectData mCurrentProject;
        bool mUnsavedChanges;

        public MainForm()
        {
            InitializeComponent();

            btnSave.Visible = false;
            btnClose.Visible = false;
            pnlDiffer.Visible = false;

            pnlImages.Visible = false;
            pnlClasses.Visible = false;

            MainForm_Resize(this, EventArgs.Empty);
        }

        void EnsureFormName()
        {
            if (mUnsavedChanges)
            {
                this.Text = $"{FORM_NAME} | {mCurrentProjectFile} * (Unsaved Changes)";
            }
            else
            {
                this.Text = $"{FORM_NAME} | {mCurrentProjectFile}";
            }
        }

        void EnsureLoadedProject(string filename)
        {
            mCurrentProjectFile = filename;

            lbProjectName.Text = Path.GetFileNameWithoutExtension(filename);

            EnsureFormName();

            mCurrentProject = JsonConvert.DeserializeObject<ProjectData>(File.ReadAllText(filename));

            if (mCurrentProject == null)
            {
                mCurrentProject = new ProjectData();
            }

            if (mCurrentProject.Classes != null)
            {
                foreach (var item in mCurrentProject.Classes)
                {
                    var cc = new ClassControl(item.Name, item.Color) { Dock = DockStyle.Top };
                    cc.UnsavedChanges += OnUnsavedChanges;
                    cc.DeleteClass += OnDeleteClass;
                    cc.BeforeRename += OnBeforeRenameClass;
                    pnlClassesList.Controls.Add(cc);
                }
            }

            btnSave.Visible = true;
            btnSave.Enabled = false;
            btnClose.Visible = true;
            pnlDiffer.Visible = true;
            pnlImages.Visible = true;
            pnlClasses.Visible = true;
        }

        void btnProjectOpen_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Open project...";
                openFileDialog.Multiselect = false;
                openFileDialog.AddExtension = true;
                openFileDialog.CheckFileExists = true;
                openFileDialog.CheckPathExists = true;
                openFileDialog.Filter = "Project files (*.ytrain)|*.ytrain";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    EnsureLoadedProject(openFileDialog.FileName);
                }
            }
        }

        void btnProjectCreate_Click(object sender, EventArgs e)
        {
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Create project...";
                saveFileDialog.AddExtension = true;
                saveFileDialog.CheckPathExists = true;
                saveFileDialog.Filter = "Project files (*.ytrain)|*.ytrain";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string dir = Path.GetDirectoryName(saveFileDialog.FileName);

                    if (Directory.EnumerateFileSystemEntries(dir).Any())
                    {
                        if (MessageBox.Show("The folder is not empty! This is not recommended for new projects. Do you want to continue?", FORM_NAME, MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            return;
                        }
                    }

                    try
                    {
                        File.Create(saveFileDialog.FileName).Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Cannot create project file: {ex.Message}", FORM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    EnsureLoadedProject(saveFileDialog.FileName);
                }
            }
        }

        void MainForm_Resize(object sender, EventArgs e)
        {
            pnlControls.Height = flowProject.Height;
        }

        void txtNewClass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtNewClass.Text))
                {
                    MessageBox.Show("Please fill in a class name!", FORM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (CheckHasClassNameOrMessageBox(txtNewClass.Text))
                {
                    return;
                }

                var cc = new ClassControl(txtNewClass.Text, Color.Black.ToArgb()) { Dock = DockStyle.Top };
                cc.UnsavedChanges += OnUnsavedChanges;
                cc.DeleteClass += OnDeleteClass;
                cc.BeforeRename += OnBeforeRenameClass;
                pnlClassesList.Controls.Add(cc);

                txtNewClass.Text = string.Empty;

                EnsureUnsavedInfo();
            }
        }

        void pnlClassNamePadding_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.Gray, 0, pnlClassNamePadding.Height - 1, pnlClassNamePadding.Width - 1, pnlClassNamePadding.Height - 1);
        }

        void OnUnsavedChanges(object sender, EventArgs e)
        {
            EnsureUnsavedInfo();
        }

        void EnsureUnsavedInfo()
        {
            mUnsavedChanges = true;

            EnsureFormName();

            btnSave.Enabled = true;
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            SaveChanges();
        }

        bool CheckHasClassNameOrMessageBox(string newname)
        {
            if (pnlClassesList.Controls.Cast<ClassControl>().Any(x => string.Equals(newname, x.ClassName, StringComparison.InvariantCultureIgnoreCase)))
            {
                MessageBox.Show("This class name already exist!", FORM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                return false;
            }
        }

        bool CheckClassNameEditingOrMessageBox()
        {
            if (pnlClassesList.Controls.Cast<ClassControl>().Any(x => x.Editing))
            {
                if (MessageBox.Show("You are currently editing classes. Do you want to discard all class changes?", FORM_NAME, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                {
                    return true;
                }

                foreach (var item in pnlClassesList.Controls.Cast<ClassControl>())
                {
                    item.CancelChanges();
                }
            }

            return false;
        }

        bool SaveChanges()
        {
            if (CheckClassNameEditingOrMessageBox())
            {
                return false;
            }

            ProjectData pd = new ProjectData();

            pd.Classes = pnlClassesList.Controls.Cast<ClassControl>().Select(x => new ClassName() { Name = x.ClassName, Color = x.ClassColor }).ToArray();

            try
            {
                File.WriteAllText(mCurrentProjectFile, JsonConvert.SerializeObject(pd, Formatting.Indented));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cannot save project file: {ex.Message}", FORM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            mCurrentProject = pd;

            mUnsavedChanges = false;

            EnsureFormName();

            btnSave.Enabled = false;

            return true;
        }

        void OnDeleteClass(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deleting a class will remove all marks of that class from all pictures! Are you really sure?", FORM_NAME, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                pnlClassesList.Controls.Remove((Control)sender);
                EnsureUnsavedInfo();
            }
        }

        void OnBeforeRenameClass(object sender, BeforeRenameEventArgs e)
        {
            e.Cancel = CheckHasClassNameOrMessageBox(e.Name);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (CheckClassNameEditingOrMessageBox())
            {
                e.Cancel = true;
                return;
            }

            if (mUnsavedChanges)
            {
                var ans = MessageBox.Show("You have unsaved changes! Do you want to save the changes before exit?", FORM_NAME, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (ans == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }

                if (ans == DialogResult.Yes)
                {
                    if (!SaveChanges())
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }
        }
    }
}