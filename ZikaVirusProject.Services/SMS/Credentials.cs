using System.Configuration;

namespace ZikaVirusProject.Services.SMS
{
    public class Credentials
    {
        public static string TwilioAccountSid = ConfigurationManager.AppSettings["TwilioAccountSid"];
        public static string TwilioAuthToken = ConfigurationManager.AppSettings["TwilioAuthToken"];
        public static string TwilioPhoneNumber = ConfigurationManager.AppSettings["TwilioPhoneNumber"];
    }
}
