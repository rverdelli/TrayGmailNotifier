namespace TrayGmailNotifier
{
    partial class TrayGmailNotifier
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrayGmailNotifier));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsClose = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.NotificationTitle = new System.Windows.Forms.Label();
            this.NotificationBody = new System.Windows.Forms.RichTextBox();
            this.contextMenuStripTray.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStripTray;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "TrayGmailNotifier";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // contextMenuStripTray
            // 
            this.contextMenuStripTray.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsClose});
            this.contextMenuStripTray.Name = "contextMenuStripTray";
            this.contextMenuStripTray.Size = new System.Drawing.Size(115, 28);
            // 
            // cmsClose
            // 
            this.cmsClose.Name = "cmsClose";
            this.cmsClose.Size = new System.Drawing.Size(114, 24);
            this.cmsClose.Text = "Close";
            this.cmsClose.Click += new System.EventHandler(this.cmsClose_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.NotificationTitle);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(380, 28);
            this.panel1.TabIndex = 0;
            // 
            // NotificationTitle
            // 
            this.NotificationTitle.AutoEllipsis = true;
            this.NotificationTitle.AutoSize = true;
            this.NotificationTitle.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NotificationTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.NotificationTitle.Location = new System.Drawing.Point(3, 4);
            this.NotificationTitle.MaximumSize = new System.Drawing.Size(452, 0);
            this.NotificationTitle.Name = "NotificationTitle";
            this.NotificationTitle.Size = new System.Drawing.Size(96, 21);
            this.NotificationTitle.TabIndex = 0;
            this.NotificationTitle.Text = "Sample Text";
            // 
            // NotificationBody
            // 
            this.NotificationBody.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.NotificationBody.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NotificationBody.Font = new System.Drawing.Font("Calibri", 10F);
            this.NotificationBody.Location = new System.Drawing.Point(0, 29);
            this.NotificationBody.Name = "NotificationBody";
            this.NotificationBody.ReadOnly = true;
            this.NotificationBody.Size = new System.Drawing.Size(380, 88);
            this.NotificationBody.TabIndex = 1;
            this.NotificationBody.Text = "Sample Text";
            // 
            // TrayGmailNotifier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 115);
            this.Controls.Add(this.NotificationBody);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TrayGmailNotifier";
            this.ShowInTaskbar = false;
            this.Text = "TrayGmailNotifier";
            this.TopMost = true;
            this.contextMenuStripTray.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label NotificationTitle;
        private System.Windows.Forms.RichTextBox NotificationBody;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTray;
        private System.Windows.Forms.ToolStripMenuItem cmsClose;
    }
}

