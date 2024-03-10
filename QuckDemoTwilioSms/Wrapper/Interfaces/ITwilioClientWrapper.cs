using QuckDemoTwilioSms.Models;
using Twilio.Rest.Api.V2010.Account;

namespace QuckDemoTwilioSms.Wrapper.Interfaces
{
    public interface ITwilioClientWrapper
    {
        MessageResource Send(Detail detail);
    }
}
