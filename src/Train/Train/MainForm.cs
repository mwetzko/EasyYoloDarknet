using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
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
        ClassName mSelectedClassName;

        public MainForm()
        {
            InitializeComponent();

            EnsureDefaultProjectNameText();

            btnSave.Visible = false;
            btnClose.Visible = false;
            pnlDiffer.Visible = false;

            pnlImages.Visible = false;
            pnlClasses.Visible = false;

            OnResize(EventArgs.Empty);
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

        void EnsureDefaultProjectNameText()
        {
            lbProjectName.Text = "<Open project or create one>";
        }

        void LoadMarks(ImageMark[] marks)
        {
            if (marks == null)
            {
                return;
            }

            foreach (var item in marks)
            {
                item.ClassName = mCurrentProject.Classes.First(x => string.Equals(x.ID, item.ClassId));
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
                    ProjectState.AddClass(item);

                    var cc = new ClassControl(item);
                    cc.Dock = DockStyle.Top;
                    cc.UnsavedChanges += OnClassNameUnsavedChanges;
                    cc.DeleteClass += OnDeleteClass;
                    cc.BeforeRename += OnBeforeRenameClass;
                    cc.Selected += OnClassSelection;
                    pnlClassesList.Controls.Add(cc);
                }

                if (pnlClassesList.Controls.Count > 0)
                {
                    pnlClassesList.Controls.Cast<ClassControl>().Last().Select();
                }
            }

            if (mCurrentProject.Images != null)
            {
                var pd = Path.GetDirectoryName(mCurrentProjectFile);

                var path = Path.Combine(pd, "Images");

                foreach (var item in mCurrentProject.Images)
                {
                    LoadMarks(item.Marks);

                    ProjectState.AddMarks(item.Marks);

                    var ic = new ImageControl(Path.Combine(path, item.Name), item.Marks);
                    ic.Dock = DockStyle.Top;
                    ic.UnsavedChanges += OnUnsavedChanges;
                    ic.DeleteImage += OnDeleteImage;
                    ic.Selected += OnImageSelection;
                    pnlImagesList.Controls.Add(ic);
                }

                if (pnlImagesList.Controls.Count > 0)
                {
                    pnlImagesList.Controls.Cast<ImageControl>().Last().Select();
                }
            }

            btnSave.Visible = true;
            btnSave.Enabled = false;
            btnClose.Visible = true;
            pnlDiffer.Visible = true;
            pnlImages.Visible = true;
            pnlImagesList.AutoSize = true;
            pnlImagesList.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnlClasses.Visible = true;
            pnlClassesList.AutoSize = true;
            pnlClassesList.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            txtNewClass.Text = string.Empty;
        }

        void DeleteUnusedFile(string filename)
        {
            try
            {
                File.Delete(filename);
            }
            catch (Exception)
            {
                // nothing
            }
        }

        void EnsureClosedProject()
        {
            var pd = Path.GetDirectoryName(mCurrentProjectFile);

            var path = Path.Combine(pd, "Images");

            foreach (var image in Directory.EnumerateFiles(path))
            {
                if (mCurrentProject.Images != null)
                {
                    var name = Path.GetFileName(image);

                    if (!mCurrentProject.Images.Contains(x => string.Equals(x.Name, name, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        DeleteUnusedFile(image);
                    }
                }
                else
                {
                    DeleteUnusedFile(image);
                }
            }

            EnsureDefaultProjectNameText();

            mCurrentProjectFile = null;
            mCurrentProject = null;

            ClearImageEditor();

            pnlImagesList.Controls.Clear();
            pnlClassesList.Controls.Clear();

            btnSave.Visible = false;
            btnClose.Visible = false;
            pnlDiffer.Visible = false;
            pnlImages.Visible = false;
            pnlClasses.Visible = false;

            ProjectState.Clear();
        }

        void ClearImageEditor()
        {
            imageEditor.ImageControl = null;
            imageEditor.Invalidate(true);
        }

        void btnProjectOpen_Click(object sender, EventArgs e)
        {
            if (!CloseProject())
            {
                return;
            }

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
            if (!CloseProject())
            {
                return;
            }

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

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

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

                var cn = new ClassName() { ID = Guid.NewGuid().ToString("N"), Name = txtNewClass.Text, Color = Color.Black.ToArgb() };

                ProjectState.AddClass(cn);

                var cc = new ClassControl(cn);
                cc.Dock = DockStyle.Top;
                cc.UnsavedChanges += OnClassNameUnsavedChanges;
                cc.DeleteClass += OnDeleteClass;
                cc.BeforeRename += OnBeforeRenameClass;
                cc.Selected += OnClassSelection;
                pnlClassesList.Controls.Add(cc);

                cc.Select();

                txtNewClass.Text = string.Empty;

                EnsureUnsavedInfo();
            }
        }

        void PaintBottomLine(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawBottomLine((Control)sender);
        }

        void OnClassNameUnsavedChanges(object sender, EventArgs e)
        {
            imageEditor.OnClassNameChange();

            EnsureUnsavedInfo();
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
            if (pnlClassesList.Controls.Cast<ClassControl>().Any(x => string.Equals(newname, x.CurrentClassName, StringComparison.InvariantCultureIgnoreCase)))
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

            pd.Classes = pnlClassesList.Controls.Cast<ClassControl>().Select(x => x.ClassName).ToArray();
            pd.Images = pnlImagesList.Controls.Cast<ImageControl>().Select(x => new ImageInfo() { Name = x.ImageName, Marks = x.Marks.ToArray() }).ToArray();

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
                ClassControl cc = (ClassControl)sender;
                ProjectState.RemoveClass(cc.ClassName.ID);
                pnlClassesList.Controls.Remove(cc);
                EnsureUnsavedInfo();
            }
        }

        void OnBeforeRenameClass(object sender, BeforeRenameEventArgs e)
        {
            e.Cancel = CheckHasClassNameOrMessageBox(e.Name);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = !CloseProject();
        }

        void btnClose_Click(object sender, EventArgs e)
        {
            CloseProject();
        }

        bool CloseProject()
        {
            if (mCurrentProject == null)
            {
                return true;
            }

            if (CheckClassNameEditingOrMessageBox())
            {
                return false;
            }

            if (mUnsavedChanges)
            {
                var ans = MessageBox.Show("You have unsaved changes! Do you want to save the changes before exit?", FORM_NAME, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (ans == DialogResult.Cancel)
                {
                    return false;
                }

                if (ans == DialogResult.Yes)
                {
                    if (!SaveChanges())
                    {
                        return false;
                    }
                }
            }

            EnsureClosedProject();

            return true;
        }

        void OnClassSelection(object sender, EventArgs e)
        {
            foreach (var item in pnlClassesList.Controls.Cast<ClassControl>())
            {
                if (item == sender)
                {
                    item.Select();
                    mSelectedClassName = item.ClassName;
                }
                else
                {
                    item.Deselect();
                }
            }
        }

        void btnImageFromFile_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Open image(s)...";
                openFileDialog.Multiselect = true;
                openFileDialog.CheckFileExists = true;
                openFileDialog.CheckPathExists = true;

                string ext = "*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                openFileDialog.Filter = $"Image files ({ext})|{ext}";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ImageControl ic = null;

                    foreach (var item in openFileDialog.FileNames)
                    {
                        using (Image img = Image.FromFile(item))
                        {
                            ic = AddImage(img);
                        }
                    }

                    ic?.Select();
                }
            }
        }

        void btnImageFromClipboard_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsImage())
            {
                AddImage(Clipboard.GetImage());
            }
        }

        ImageControl AddImage(Image img)
        {
            var pd = Path.GetDirectoryName(mCurrentProjectFile);

            var path = Path.Combine(pd, "Images");

            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cannot create image directory: {ex.Message}", FORM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            var name = Guid.NewGuid().ToString("N") + ".png";

            path = Path.Combine(path, name);

            try
            {
                img.Save(path, ImageFormat.Png);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cannot save image copy: {ex.Message}", FORM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            var ic = new ImageControl(path, null);
            ic.Dock = DockStyle.Top;
            ic.UnsavedChanges += OnUnsavedChanges;
            ic.DeleteImage += OnDeleteImage;
            ic.Selected += OnImageSelection;
            pnlImagesList.Controls.Add(ic);

            EnsureUnsavedInfo();

            return ic;
        }

        void OnDeleteImage(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deleting an image will remove all marks of that image! Are you really sure?", FORM_NAME, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                ImageControl ic = (ImageControl)sender;

                if (imageEditor.ImageControl == ic)
                {
                    ClearImageEditor();
                }

                ProjectState.RemoveMarks(ic.Marks.ToArray());
                pnlImagesList.Controls.Remove(ic);
                EnsureUnsavedInfo();
            }
        }

        void OnImageSelection(object sender, EventArgs e)
        {
            foreach (var item in pnlImagesList.Controls.Cast<ImageControl>())
            {
                if (item == sender)
                {
                    item.Select();
                    imageEditor.ImageControl = item;
                }
                else
                {
                    item.Deselect();
                }
            }
        }

        void imageEditor_GetImageClassName(object sender, GetImageClassNameArgs e)
        {
            if (mSelectedClassName == null)
            {
                MessageBox.Show("You must select a class to draw marks!", FORM_NAME, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            e.ClassName = mSelectedClassName;
        }

        void imageEditor_DeleteMarks(object sender, EventArgs e)
        {
            EnsureUnsavedInfo();
        }

        void ClassesListControlsChanged(object sender, ControlEventArgs e)
        {
            if (pnlClassesList.Controls.Count == 0)
            {
                lbClasses.Text = "Classes";
            }
            else
            {
                lbClasses.Text = $"Classes ({pnlClassesList.Controls.Count})";
            }
        }

        void ImageListControlsChanged(object sender, ControlEventArgs e)
        {
            if (pnlImagesList.Controls.Count == 0)
            {
                lbImages.Text = "Images";
            }
            else
            {
                lbImages.Text = $"Images ({pnlImagesList.Controls.Count})";
            }
        }

        protected override void OnHelpRequested(HelpEventArgs e)
        {
            base.OnHelpRequested(e);

            e.Handled = true;

            using (var h = new HelpForm())
            {
                h.ShowDialog();
            }
        }

        void imageEditor_ResizeMarks(object sender, EventArgs e)
        {
            EnsureUnsavedInfo();
        }
    }
}