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
        public PasswordEncryptionForm()
        {
            InitializeComponent();
            this.Icon = new Icon(AppConfig.NoNewMailIconPath.Value);
        }

        private void PasswordEncryptionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            AppConfig.UserName.Value = GmailAccountTextBox.Text;
            string gmailPwd = GmailPasswordTextField.Text;
            
            PasswordEncryptionUtils.EncryptPassword(gmailPwd);       
        }

        private void PasswordEncryptionOkButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(GmailPasswordTextField.Text))
                this.Close();
        }

        private void GmailTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.Close();
        }

    }
}
