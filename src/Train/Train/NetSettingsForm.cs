using System;
using System.Windows.Forms;

namespace Train
{
    public partial class NetSettingsForm : Form
    {
        public NetSettingsForm()
        {
            InitializeComponent();
        }

        public int Batch => (int)numBatch.Value;
        public int Subdivisions => (int)numSubdivisions.Value;
        public int NetWidth => (int)numWidth.Value;
        public int NetHeight => (int)numHeight.Value;

        void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
