using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrayGmailNotifier
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //MyDoc folder initialization
            string myDocumentsTrayFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +  "\\TrayGmailNotifier\\";

            if (!Directory.Exists(myDocumentsTrayFolder))
                Directory.CreateDirectory(myDocumentsTrayFolder);

            if (!File.Exists(myDocumentsTrayFolder + "config.xml"))
                File.Create(myDocumentsTrayFolder + "config.xml").Close();


            if(String.IsNullOrWhiteSpace( AppConfig.UserName.Value) || !File.Exists(PasswordEncryptionUtils.EncryptedFileName))
            {
                PasswordEncryptionForm pef = new PasswordEncryptionForm();
                Application.Run(pef);
            }

            TrayGmailNotifier f1 = new TrayGmailNotifier();
            f1.WindowState = FormWindowState.Minimized;
            f1.ShowInTaskbar = false;
            f1.Visible = true;
            f1.Visible = false;

            Application.Run(f1);
        }
    }
}
