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
            this.GmailPasswordLabel.Location = new System.Drawing.Point(12, 35);
            this.GmailPasswordLabel.Name = "GmailPasswordLabel";
            this.GmailPasswordLabel.Size = new System.Drawing.Size(112, 17);
            this.GmailPasswordLabel.TabIndex = 0;
            this.GmailPasswordLabel.Text = "Gmail password:";
            // 
            // GmailPasswordTextField
            // 
            this.GmailPasswordTextField.Location = new System.Drawing.Point(130, 32);
            this.GmailPasswordTextField.Name = "GmailPasswordTextField";
            this.GmailPasswordTextField.Size = new System.Drawing.Size(199, 22);
            this.GmailPasswordTextField.TabIndex = 2;
            this.GmailPasswordTextField.UseSystemPasswordChar = true;
            this.GmailPasswordTextField.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GmailTextBox_KeyDown);
            // 
            // PasswordEncryptionOkButton
            // 
            this.PasswordEncryptionOkButton.Location = new System.Drawing.Point(239, 60);
            this.PasswordEncryptionOkButton.Name = "PasswordEncryptionOkButton";
            this.PasswordEncryptionOkButton.Size = new System.Drawing.Size(90, 26);
            this.PasswordEncryptionOkButton.TabIndex = 4;
            this.PasswordEncryptionOkButton.Text = "OK";
            this.PasswordEncryptionOkButton.UseVisualStyleBackColor = true;
            this.PasswordEncryptionOkButton.Click += new System.EventHandler(this.PasswordEncryptionOkButton_Click);
            // 
            // GmailAccountLabel
            // 
            this.GmailAccountLabel.AutoSize = true;
            this.GmailAccountLabel.Location = new System.Drawing.Point(12, 9);
            this.GmailAccountLabel.Name = "GmailAccountLabel";
            this.GmailAccountLabel.Size = new System.Drawing.Size(102, 17);
            this.GmailAccountLabel.TabIndex = 5;
            this.GmailAccountLabel.Text = "Gmail account:";
            // 
            // GmailAccountTextBox
            // 
            this.GmailAccountTextBox.Location = new System.Drawing.Point(130, 6);
            this.GmailAccountTextBox.Name = "GmailAccountTextBox";
            this.GmailAccountTextBox.Size = new System.Drawing.Size(199, 22);
            this.GmailAccountTextBox.TabIndex = 1;
            this.GmailAccountTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GmailTextBox_KeyDown);
            // 
            // PasswordEncryptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 99);
            this.Controls.Add(this.GmailAccountTextBox);
            this.Controls.Add(this.GmailAccountLabel);
            this.Controls.Add(this.PasswordEncryptionOkButton);
            this.Controls.Add(this.GmailPasswordTextField);
            this.Controls.Add(this.GmailPasswordLabel);
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