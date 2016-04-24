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
        public static readonly string xmlFileUri = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TrayGmailNotifier\\config.xml";
        public static IParameter<int> NotificationsFadeInDelay = new XmlPersistentParameter<int>("NotificationsFadeInDelay", 250, xmlFileUri);
        public static IParameter<int> NotificationsFadeInSteps = new XmlPersistentParameter<int>("NotificationsFadeInSteps", 20, xmlFileUri);
        public static IParameter<int> NotificationsPersistDelay = new XmlPersistentParameter<int>("NotificationsPersistDelay", 5000, xmlFileUri);
        public static IParameter<int> DelayBetweenChecks = new XmlPersistentParameter<int>("DelayBetweenChecks", 15000, xmlFileUri);
        public static IParameter<string> UserName = new XmlPersistentParameter<string>("Username", "", xmlFileUri);

        public static IParameter<string> NoNewMailIconPath = new Parameter<string>(@"Icons\NoNewMail.ico");
        public static IParameter<string> NewMailIconPath = new Parameter<string>(@"Icons\NewMail.ico");
        public static IParameter<string> NotWorking = new Parameter<string>(@"Icons\NotWorking.ico");
    }
}
