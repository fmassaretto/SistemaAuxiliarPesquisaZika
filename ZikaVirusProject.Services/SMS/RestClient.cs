﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using ZikaVirusProject.Services.SMS.Interface;

namespace ZikaVirusProject.Services.SMS
{
    public class RestClient : IRestClient
    {
        private readonly ITwilioRestClient _client;

        public RestClient()
        {
            _client = new TwilioRestClient(
                Credentials.TwilioAccountSid,
                Credentials.TwilioAuthToken
            );
        }

        public RestClient(ITwilioRestClient client)
        {
            _client = client;
        }
        public async Task<MessageResource> SendMessage(string @from, string to, string body, List<Uri> mediaUrl)
        {
            var toPhoneNumber = new PhoneNumber(to);
            return await MessageResource.CreateAsync(
                toPhoneNumber,
                @from: new PhoneNumber(from),
                body: body,
                mediaUrl: mediaUrl,
                client: _client);
        }
    }
}
