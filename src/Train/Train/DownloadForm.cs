using System;
using System.ComponentModel;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Train
{
    public partial class DownloadForm : Form
    {
        string mFilename;
        string mUrl;
        Stream mStream;
        Task mTask = Task.CompletedTask;
        CancellationTokenSource mSource = new CancellationTokenSource();

        public DownloadForm()
        {
            InitializeComponent();
        }

        public DownloadForm(string filename, string url)
        {
            InitializeComponent();

            lbBytesDownloaded.Text = "";

            mFilename = filename;
            mUrl = url;
            mStream = Stream.Synchronized(new FileStream(filename, FileMode.Create));
        }

        protected override void Dispose(bool disposing)
        {
            mStream?.Dispose();
            mStream = null;

            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            updateTimer.Enabled = false;

            mSource.Cancel();

            try
            {
                mTask.GetAwaiter().GetResult();
            }
            catch (OperationCanceledException)
            {
                mStream?.Dispose();

                try
                {
                    File.Delete(mFilename);
                }
                catch (Exception)
                {
                    // nothing
                }

                DialogResult = DialogResult.Cancel;
            }

            base.OnClosing(e);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            mTask = Task.Run(StartDownloadAsync);
            mTask.ContinueWith(AfterDownload, TaskContinuationOptions.ExecuteSynchronously);

            updateTimer.Enabled = true;
        }

        void AfterDownload(Task task)
        {
            if (mSource.IsCancellationRequested)
            {
                return;
            }

            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<Task>(AfterDownload), task);
            }
            else
            {
                this.Close();
            }
        }

        async Task StartDownloadAsync()
        {
            var token = mSource.Token;

            using (HttpClient hc = new HttpClient())
            {
                using (var ws = await hc.GetStreamAsync(mUrl, token))
                {
                    ws.CopyToAsync(mStream, token).Wait(token);
                }
            }
        }

        void updateTimer_Tick(object sender, EventArgs e)
        {
            lbBytesDownloaded.Text = GetBytesText();
        }

        string GetBytesText()
        {
            var bytes = mStream.Position;

            var um = bytes / 1024 / 1024;

            if (um > 0)
            {
                return $"{um} mb";
            }

            um = bytes / 1024;

            if (um > 0)
            {
                return $"{um} kb";
            }

            return $"{bytes} bytes";
        }
    }
}
