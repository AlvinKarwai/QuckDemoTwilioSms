using QuckDemoTwilioSms.Models;

namespace QuckDemoTwilioSms.Validator
{
    public interface ISmsValidate
    {
        public bool IsValid(Detail detail);
    }
}