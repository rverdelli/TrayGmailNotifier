using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace TrayGmailNotifier
{
    public partial class TrayGmailNotifier : Form
    {
        private bool showMessageForm = false;
        private int notificationsFadeInStepDelay;
        private double notificationsFadeInStepIncrement;
        private int notificationsPersistDelay;
        private int delayBetweenChecks;
        private List<string> actualUnreadMessagesIds = new List<string>();
        private string gmailPassword;
        private TransparentRichTextBox notificationBody;

        public TrayGmailNotifier()
        {
            InitializeComponent();
            this.Icon = new Icon(AppConfig.NoNewMailIconPath.Value);
            notificationBody = new TransparentRichTextBox();
            notificationBody.AutoWordSelection = true;
            notificationBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(26)))), ((int)(((byte)(72)))));
            notificationBody.BorderStyle = System.Windows.Forms.BorderStyle.None;
            notificationBody.Font = new System.Drawing.Font("Calibri", 10F);
            notificationBody.ForeColor = System.Drawing.SystemColors.ControlText;
            notificationBody.Location = new System.Drawing.Point(112, 4);
            notificationBody.Name = "NotificationBody";
            notificationBody.ReadOnly = true;
            notificationBody.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            notificationBody.Size = new System.Drawing.Size(394, 107);
            notificationBody.TabIndex = 1;
            notificationBody.Text = "Sample Text";

            this.Controls.Add(notificationBody);

            //General settings
            notificationsPersistDelay = AppConfig.NotificationsPersistDelay.Value;
            delayBetweenChecks = AppConfig.DelayBetweenChecks.Value;

            //Fade-in\out setup
            int notificationsFadeInDelay = AppConfig.NotificationsFadeInDelay.Value;
            double notificationsFadeInSteps = AppConfig.NotificationsFadeInSteps.Value;
            notificationsFadeInStepDelay = Convert.ToInt32(notificationsFadeInDelay / notificationsFadeInSteps);
            notificationsFadeInStepIncrement = 1.0 / notificationsFadeInSteps;

            //Fast show and hide to force the .NET framework to create the form in this thread, it's a workaround..
            workaroundShowNotification();
            workaroundShowNotification();

            //Setting notifications position
            int rightMargin = Convert.ToInt32(ConfigurationManager.AppSettings["NotificationsRightMargin"]);
            int bottomMargin = Convert.ToInt32(ConfigurationManager.AppSettings["NotificationsBottonMargin"]);
            int x = Screen.PrimaryScreen.Bounds.Width - this.Width - rightMargin;
            int y = Screen.PrimaryScreen.Bounds.Height - this.Height - bottomMargin - 55;
            this.Location = new Point(x, y);

            string encryptionKey = System.Environment.UserName;
            gmailPassword = PasswordEncryptionUtils.GetDecryptedPassword();
            

            //Starting applicative thread
            Thread t = new Thread(() => checkForMail());
            t.Start();
        }

        public void checkForMail()
        {
            while (true)
            {
                try
                {
                    System.Net.WebClient objClient = new System.Net.WebClient();
                    string response;
                    string from;
                    string subject;
                    string body;
                    DateTime timestamp;

                    List<string> oldUnreadMessagesIds = new List<string>();
                    oldUnreadMessagesIds.AddRange(actualUnreadMessagesIds);
                    actualUnreadMessagesIds.Clear();

                    //Creating a new xml document
                    XmlDocument doc = new XmlDocument();

                    //Logging in Gmail server to get data
                    objClient.Credentials = new System.Net.NetworkCredential(AppConfig.UserName.Value, gmailPassword);
                    //reading data and converting to string
                    response = Encoding.UTF8.GetString(objClient.DownloadData("https://mail.google.com/mail/feed/atom"));
                    response = response.Replace(@"<feed version=""0.3"" xmlns=""http://purl.org/atom/ns#"">", @"<feed>");

                    //loading into an XML so we can get information easily
                    doc.LoadXml(response);

                    notifyIcon.Icon = new Icon(AppConfig.NoNewMailIconPath.Value);
                    int newMailCount = doc.SelectNodes(@"/feed/entry").Count;
                    notifyIcon.Text = newMailCount == 0 ? "No new mail" : newMailCount + " new mail(s)!";

                    foreach (XmlNode node in doc.SelectNodes(@"/feed/entry"))
                    {
                        notifyIcon.Icon = new Icon(AppConfig.NewMailIconPath.Value);

                        string id = node.SelectSingleNode("id").InnerText;
                        actualUnreadMessagesIds.Add(id);

                        if (oldUnreadMessagesIds.Where(x => x.Equals(id)).Count() == 0)
                        {
                            from = node.SelectSingleNode("author").SelectSingleNode("email").InnerText;
                            subject = node.SelectSingleNode("title").InnerText;
                            body = node.SelectSingleNode("summary").InnerText;
                            timestamp = Convert.ToDateTime(node.SelectSingleNode("issued").InnerText);
                            showN(from, timestamp, subject, body);
                        }
                    }

                }
                catch (Exception ex)
                {
                    notifyIcon.Icon = new Icon(AppConfig.NotWorking.Value);
                    notifyIcon.Text = ex.Message.Length > 64 ? ex.Message.Substring(0,60) + "..." : ex.Message;
                }

                Thread.Sleep(delayBetweenChecks);
            }
        }

        public void showN(string from, DateTime timestamp, string subject, string body)
        {
            TS_setupNotification(from, timestamp, subject, body);
            TS_unhideNotificationForm();
            fadeInAndOut();
            TS_hideNotificationForm();
        }

        public static byte[] FromBase64ForUrlString(string base64ForUrlInput)
        {
            int padChars = (base64ForUrlInput.Length % 4) == 0 ? 0 : (4 - (base64ForUrlInput.Length % 4));
            StringBuilder result = new StringBuilder(base64ForUrlInput, base64ForUrlInput.Length + padChars);
            result.Append(String.Empty.PadRight(padChars, '='));
            result.Replace('-', '+');
            result.Replace('_', '/');
            return Convert.FromBase64String(result.ToString());
        }

        delegate void unhideNotificationFormDelegate();
        public void TS_unhideNotificationForm()
        {
            if (this.InvokeRequired)
            {
                unhideNotificationFormDelegate snd = new unhideNotificationFormDelegate(TS_unhideNotificationForm);
                this.Invoke(snd);
            }
            else
                unhideNotificationform();
        }

        public void unhideNotificationform()
        {
            showMessageForm = true;
            this.Opacity = 0;
            this.Show();
            this.TopMost = true;
        }

        delegate void hideNotificationFormDelegate();
        public void TS_hideNotificationForm()
        {
            if (this.InvokeRequired)
            {
                hideNotificationFormDelegate snd = new hideNotificationFormDelegate(TS_hideNotificationForm);
                this.Invoke(snd);
            }
            else
                hideNotificationform();
        }

        public void hideNotificationform()
        {
            this.Hide();
            showMessageForm = false;
        }

        delegate void setupNotificationDelegate(string from, DateTime timestamp, string subject, string body);
        public void TS_setupNotification(string from, DateTime timestamp, string subject, string body)
        {
            if (this.InvokeRequired)
            {
                object[] parameters = new object[4];
                parameters[0] = from;
                parameters[1] = timestamp;
                parameters[2] = subject;
                parameters[3] = body;
                setupNotificationDelegate snd = new setupNotificationDelegate(TS_setupNotification);
                this.Invoke(snd, parameters);
            }
            else
            {
                setupNotification(from, timestamp, subject, body);
            }
        }

        public void setupNotification(string from, DateTime timestamp, string subject, string body)
        {
            notificationBody.Clear();

            notificationBody.SelectionIndent = 4;
            notificationBody.SelectionRightIndent = 4;

            notificationBody.SelectionFont = new Font("Calibri", 9, FontStyle.Italic);
            notificationBody.AppendText(from + System.Environment.NewLine);

            notificationBody.SelectionFont = new Font("Calibri", 11, FontStyle.Bold);
            notificationBody.AppendText(subject + System.Environment.NewLine);

            notificationBody.SelectionFont = new Font("Calibri", 10, FontStyle.Regular);
            notificationBody.AppendText(body);
        }

        delegate void setOpacityDelegate(double opacity);
        public void TS_setOpacity(double opacity)
        {
            if (this.InvokeRequired)
            {
                object[] parameters = new object[1];
                parameters[0] = opacity;
                setOpacityDelegate snd = new setOpacityDelegate(TS_setOpacity);
                this.Invoke(snd, parameters);
            }
            else
            {
                setOpacity(opacity);
            }
        }

        private void setOpacity(double opacity)
        {
            this.Opacity = opacity;
        }

        private void fadeInAndOut()
        {
            TS_setOpacity(0);
            double opacityPercentage = 0;
            while (this.Opacity < 1)
            {
                opacityPercentage += notificationsFadeInStepIncrement; 
                TS_setOpacity((Math.Cos((opacityPercentage*Math.PI) + Math.PI)/2.0) + 0.5);
                Thread.Sleep(notificationsFadeInStepDelay);
            }

            Thread.Sleep(notificationsPersistDelay);

            TS_setOpacity(1);
            opacityPercentage = 1;
            while (this.Opacity > 0)
            {
                opacityPercentage -= notificationsFadeInStepIncrement;
                TS_setOpacity(opacityPercentage);
                Thread.Sleep(notificationsFadeInStepDelay);
            }
        }

        #region overrides

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(showMessageForm ? value : showMessageForm);
        }

        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }

        #endregion

        public void workaroundShowNotification()
        {
            showMessageForm = true;
            this.Visible = true;
            this.TopMost = true;
            this.TopMost = false;
            showMessageForm = false;
            this.Visible = false;
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start("https://mail.google.com");
        }

        private void cmsClose_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

    }
}
