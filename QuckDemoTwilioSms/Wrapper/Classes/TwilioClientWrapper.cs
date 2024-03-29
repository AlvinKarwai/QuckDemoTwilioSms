﻿using Microsoft.Extensions.Options;
using QuckDemoTwilioSms.Controllers;
using QuckDemoTwilioSms.Models;
using QuckDemoTwilioSms.Options;
using QuckDemoTwilioSms.Wrapper.Interfaces;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace QuckDemoTwilioSms.Wrapper.Classes
{
    public class TwilioClientWrapper : ITwilioClientWrapper
    {

        private readonly TwilioOptions _options;
        private readonly ILogger<TwilioClientWrapper> _logger;

        public TwilioClientWrapper(IOptions<TwilioOptions> options)
        {
            _options = options.Value;
        }

        public MessageResource Send(Detail? detail)
        {
            string accountSid = _options.SID;
            string authToken = _options.TOKEN;
            string fromPhoneNumber = _options.PhoneNumber;

            try
            {
                TwilioClient.Init(accountSid, authToken);

                var message = MessageResource.Create(
                    body: detail.Message,
                    from: new Twilio.Types.PhoneNumber(fromPhoneNumber),
                    to: new Twilio.Types.PhoneNumber(detail.PhoneNumber)
                );

                return message;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message + "Couldn't execute the program"); 
            }

            return null;
        }
    }
}
