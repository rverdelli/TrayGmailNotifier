using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoundationII.AppConfig.ConfigParam;

namespace TrayGmailNotifier
{
    public static class AppConfig
    {
        private static readonly string xmlFileUri = "config.xml";
        public static Parameter<int> NotificationsFadeInDelay = new XmlPersistentParameter<int>("NotificationsFadeInDelay", 250, xmlFileUri);
        public static Parameter<int> NotificationsFadeInSteps = new XmlPersistentParameter<int>("NotificationsFadeInSteps", 20, xmlFileUri);
        public static Parameter<int> NotificationsPersistDelay = new XmlPersistentParameter<int>("NotificationsPersistDelay", 5000, xmlFileUri);
        public static Parameter<int> DelayBetweenChecks = new XmlPersistentParameter<int>("DelayBetweenChecks", 15000, xmlFileUri);
        public static Parameter<string> UserName = new XmlPersistentParameter<string>("Username", "", xmlFileUri);

        public static Parameter<string> NoNewMailIconPath = new Parameter<string>(@"Icons\NoNewMail.ico");
        public static Parameter<string> NewMailIconPath = new Parameter<string>(@"Icons\NewMail.ico");
        public static Parameter<string> NotWorking = new Parameter<string>(@"Icons\NotWorking.ico");
    }
}
