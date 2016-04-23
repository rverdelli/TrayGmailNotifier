namespace TrayGmailNotifier
{
    partial class PasswordEncryptionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GmailPasswordLabel = new System.Windows.Forms.Label();
            this.GmailPasswordTextField = new System.Windows.Forms.TextBox();
            this.PasswordEncryptionOkButton = new System.Windows.Forms.Button();
            this.GmailAccountLabel = new System.Windows.Forms.Label();
            this.GmailAccountTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // GmailPasswordLabel
            // 
            this.GmailPasswordLabel.AutoSize = true;
            this.GmailPasswordLabel.Location = new System.Drawing.Point(9, 28);
            this.GmailPasswordLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.GmailPasswordLabel.Name = "GmailPasswordLabel";
            this.GmailPasswordLabel.Size = new System.Drawing.Size(84, 13);
            this.GmailPasswordLabel.TabIndex = 0;
            this.GmailPasswordLabel.Text = "Gmail password:";
            // 
            // GmailPasswordTextField
            // 
            this.GmailPasswordTextField.Location = new System.Drawing.Point(98, 26);
            this.GmailPasswordTextField.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.GmailPasswordTextField.Name = "GmailPasswordTextField";
            this.GmailPasswordTextField.Size = new System.Drawing.Size(150, 20);
            this.GmailPasswordTextField.TabIndex = 2;
            this.GmailPasswordTextField.UseSystemPasswordChar = true;
            this.GmailPasswordTextField.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GmailTextBox_KeyDown);
            // 
            // PasswordEncryptionOkButton
            // 
            this.PasswordEncryptionOkButton.Location = new System.Drawing.Point(179, 52);
            this.PasswordEncryptionOkButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PasswordEncryptionOkButton.Name = "PasswordEncryptionOkButton";
            this.PasswordEncryptionOkButton.Size = new System.Drawing.Size(68, 21);
            this.PasswordEncryptionOkButton.TabIndex = 4;
            this.PasswordEncryptionOkButton.Text = "OK";
            this.PasswordEncryptionOkButton.UseVisualStyleBackColor = true;
            this.PasswordEncryptionOkButton.Click += new System.EventHandler(this.PasswordEncryptionOkButton_Click);
            // 
            // GmailAccountLabel
            // 
            this.GmailAccountLabel.AutoSize = true;
            this.GmailAccountLabel.Location = new System.Drawing.Point(9, 7);
            this.GmailAccountLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.GmailAccountLabel.Name = "GmailAccountLabel";
            this.GmailAccountLabel.Size = new System.Drawing.Size(78, 13);
            this.GmailAccountLabel.TabIndex = 5;
            this.GmailAccountLabel.Text = "Gmail account:";
            // 
            // GmailAccountTextBox
            // 
            this.GmailAccountTextBox.Location = new System.Drawing.Point(98, 5);
            this.GmailAccountTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.GmailAccountTextBox.Name = "GmailAccountTextBox";
            this.GmailAccountTextBox.Size = new System.Drawing.Size(150, 20);
            this.GmailAccountTextBox.TabIndex = 1;
            this.GmailAccountTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GmailTextBox_KeyDown);
            // 
            // PasswordEncryptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 80);
            this.Controls.Add(this.GmailAccountTextBox);
            this.Controls.Add(this.GmailAccountLabel);
            this.Controls.Add(this.PasswordEncryptionOkButton);
            this.Controls.Add(this.GmailPasswordTextField);
            this.Controls.Add(this.GmailPasswordLabel);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "PasswordEncryptionForm";
            this.Text = "PasswordEncryptionForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PasswordEncryptionForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label GmailPasswordLabel;
        private System.Windows.Forms.TextBox GmailPasswordTextField;
        private System.Windows.Forms.Button PasswordEncryptionOkButton;
        private System.Windows.Forms.Label GmailAccountLabel;
        private System.Windows.Forms.TextBox GmailAccountTextBox;
    }
}