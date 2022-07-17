using System;
using System.Globalization;
using System.Windows.Forms;

namespace Detect
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select an image to detect objects on...";
                openFileDialog.Multiselect = false;
                openFileDialog.AddExtension = true;
                openFileDialog.CheckFileExists = true;
                openFileDialog.CheckPathExists = true;
                openFileDialog.Filter = "Image files (*.jpeg;*.jpg;*.png)|*.jpeg;*.jpg;*.png";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new MainForm(openFileDialog.FileName));
                }
            }
        }
    }
}