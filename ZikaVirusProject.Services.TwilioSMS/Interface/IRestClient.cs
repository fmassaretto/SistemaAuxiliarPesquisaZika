﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Twilio.Rest.Api.V2010.Account;

namespace ZikaVirusProject.Services.TwilioSMS.Interface
{
    public interface IRestClient
    {
        Task<MessageResource> SendMessage(string from, string to, string body, List<Uri> mediaUrl);
    }
}