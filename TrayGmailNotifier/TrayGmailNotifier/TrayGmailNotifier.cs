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

        public TrayGmailNotifier()
        {
            InitializeComponent();
            this.Icon = new Icon(AppConfig.NoNewMailIconPath.Value);

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
            int y = Screen.PrimaryScreen.Bounds.Height - this.Height - bottomMargin - 70;
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
                    string summary; 
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
                            summary = node.SelectSingleNode("title").InnerText + System.Environment.NewLine + node.SelectSingleNode("summary").InnerText;
                            TS_showNotification(from, summary);
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

        public static byte[] FromBase64ForUrlString(string base64ForUrlInput)
        {
            int padChars = (base64ForUrlInput.Length % 4) == 0 ? 0 : (4 - (base64ForUrlInput.Length % 4));
            StringBuilder result = new StringBuilder(base64ForUrlInput, base64ForUrlInput.Length + padChars);
            result.Append(String.Empty.PadRight(padChars, '='));
            result.Replace('-', '+');
            result.Replace('_', '/');
            return Convert.FromBase64String(result.ToString());
        }

        delegate void showNotificationDelegate(string title, string body);
        public void TS_showNotification(string title, string body)
        {
            if (this.InvokeRequired)
            {
                object[] parameters = new object[2];
                parameters[0] = title;
                parameters[1] = body;
                showNotificationDelegate snd = new showNotificationDelegate(TS_showNotification);
                this.Invoke(snd, parameters);
            }
            else
            {
                showNotification(title, body);
            }
        }

        public void showNotification(string title, string body)
        {
            NotificationTitle.Text = "from: " + title;

            NotificationBody.Clear();

            NotificationBody.SelectionFont = new Font(NotificationBody.SelectionFont, FontStyle.Bold);
            NotificationBody.AppendText(body.Substring(0, body.IndexOf(System.Environment.NewLine)));

            NotificationBody.SelectionFont = new Font(NotificationBody.SelectionFont, FontStyle.Regular);
            NotificationBody.AppendText(body.Substring(body.IndexOf(System.Environment.NewLine)));

            showMessageForm = true;
            this.Show();
            this.TopMost = true;
            
            TS_fadeInAndOut();

            this.Hide();
            showMessageForm = false;
        }

        delegate void raiseOpacityDelegate();
        public void TS_fadeInAndOut()
        {
            if (this.InvokeRequired)
            {
                raiseOpacityDelegate snd = new raiseOpacityDelegate(TS_fadeInAndOut);
                this.Invoke(snd);
            }
            else
            {
                fadeInAndOut();
            }
        }

        private void fadeInAndOut()
        {
            this.Opacity = 0;
            double opacityPercentage = 0;
            while (this.Opacity < 1)
            {
                opacityPercentage += notificationsFadeInStepIncrement; 
                this.Opacity += (Math.Cos((opacityPercentage*Math.PI) + Math.PI)/2.0) + 0.5;
                Application.DoEvents();
                Thread.Sleep(notificationsFadeInStepDelay);
            }

            Thread.Sleep(notificationsPersistDelay);
            
            while (this.Opacity > 0)
            {
                this.Opacity -= notificationsFadeInStepIncrement;
                Application.DoEvents();
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
