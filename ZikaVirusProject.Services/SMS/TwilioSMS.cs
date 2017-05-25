using System;
using System.Linq;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace ZikaVirusProject.Services.SMS
{
    public class TwilioSMS
    {
        public void SendTwilioSMS(string toPhoneNumber, string msg)
        {
            // Find your Account Sid and Auth Token at twilio.com/console
            const string accountSid = "AC1082e6eaacb6925a9eee43ef026baa90";
            const string authToken = "4cd0025239c9d495225a3fb4ea194ade";
            TwilioClient.Init(accountSid, authToken);

            string preFix = "+55";

            var to = new PhoneNumber(preFix.ToString() + toPhoneNumber.ToString());
            var message = MessageResource.Create(
                to,
                from: new PhoneNumber("+12512200873"),
                body: msg);

            Console.WriteLine(message.Sid);
        }
    }
}
