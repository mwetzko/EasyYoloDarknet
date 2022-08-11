using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Train
{
    public partial class TrainForm : Form
    {
        ProcessStartInfo mPsi;
        bool mCancel;
        Task mProcessTask;

        public TrainForm()
        {
            InitializeComponent();
        }

        public TrainForm(ProcessStartInfo psi)
        {
            InitializeComponent();

            mPsi = psi;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            mProcessTask = Task.Run(() => WaitForProcess());
        }

        void WaitForProcess()
        {
            using (Process darknet = new Process())
            {
                darknet.StartInfo = mPsi;
                darknet.Start();

                ProcessStreamReader outReader = new ProcessStreamReader(darknet.StandardOutput);
                ProcessStreamReader errReader = new ProcessStreamReader(darknet.StandardError);

                while (!darknet.WaitForExit(100))
                {
                    if (mCancel)
                    {
                        try
                        {
                            darknet.Kill();
                        }
                        catch (Exception)
                        {
                            // nothing
                        }

                        break;
                    }

                    DoOutput(outReader, errReader);
                }

                DoOutputFinal(outReader, errReader);
            }

            AfterTraining();
        }

        void DoOutput(ProcessStreamReader outReader, ProcessStreamReader errReader)
        {
            string str = outReader.ReadStringIfAvailable();

            if (str != null)
            {
                AddOutputData(str);
            }

            str = errReader.ReadStringIfAvailable();

            if (str != null)
            {
                AddErrorData(str);
            }
        }

        void DoOutputFinal(ProcessStreamReader outReader, ProcessStreamReader errReader)
        {
            string str = outReader.FinalReadString();

            if (str != null)
            {
                AddOutputData(str);
            }

            str = errReader.FinalReadString();

            if (str != null)
            {
                AddErrorData(str);
            }
        }

        void AddOutputData(string data)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<string>(AddOutputData), data);
            }
            else
            {
                txtOut.AppendText(data?.Replace("\n", "\r\n"));
            }
        }

        void AddErrorData(string data)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<string>(AddErrorData), data);
            }
            else
            {
                txtErr.AppendText(data?.Replace("\n", "\r\n"));
            }
        }

        void AfterTraining()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(AfterTraining));
            }
            else if (!this.IsDisposed)
            {
                if (txtErr.TextLength > 0)
                {
                    lbStatus.Text = "Training finished with errors!";
                }
                else
                {
                    lbStatus.Text = "Training finished!";
                }

                btnCancel.Text = "OK";
            }
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            mCancel = true;

            mProcessTask.Wait();

            this.Close();
        }
    }
}
