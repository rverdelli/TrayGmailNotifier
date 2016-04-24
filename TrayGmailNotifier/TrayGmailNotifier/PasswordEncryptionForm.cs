using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrayGmailNotifier
{
    public partial class PasswordEncryptionForm : Form
    {
        private bool okClicked = false;

        public PasswordEncryptionForm()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.Icon = new Icon(AppConfig.NoNewMailIconPath.Value);
        }

        private void PasswordEncryptionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!okClicked)
                System.Environment.Exit(0);
        }

        private void PasswordEncryptionOkButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(GmailAccountTextBox.Text) && !String.IsNullOrWhiteSpace(GmailPasswordTextField.Text))
            {
                AppConfig.UserName.Value = GmailAccountTextBox.Text;
                string gmailPwd = GmailPasswordTextField.Text;

                PasswordEncryptionUtils.EncryptPassword(gmailPwd);

                okClicked = true;
                this.Close();
            }
        }

        private void GmailTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                PasswordEncryptionOkButton_Click(sender, e);
        }

    }
}
