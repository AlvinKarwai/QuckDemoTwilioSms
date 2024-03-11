using QuckDemoTwilioSms.Models;
using System.Text.RegularExpressions;

namespace QuckDemoTwilioSms.Validator
{
    public class SmsValidate : ISmsValidate
    {
        public bool IsValid(Detail detail)
        {
            if (string.IsNullOrEmpty(detail.Message))
            {

                return false;
            }
            if (string.IsNullOrEmpty(detail.PhoneNumber))
            {

                return false;
            }

            var isValidPhoneNumber =ValidPhoneNumber(detail.PhoneNumber);

            if (isValidPhoneNumber == false)
            {
                return false;
            }

            return true;
        }

        public bool ValidPhoneNumber(string number)
        {
            return Regex.Match(number, "^(((\\+44\\s?\\d{4}|\\(?0\\d{4}\\)?)\\s?\\d{3}\\s?\\d{3})|((\\+44\\s?\\d{3}|\\(?0\\d{3}\\)?)\\s?\\d{3}\\s?\\d{4})|((\\+44\\s?\\d{2}|\\(?0\\d{2}\\)?)\\s?\\d{4}\\s?\\d{4}))(\\s?\\#(\\d{4}|\\d{3}))?$").Success;
        }
    }
}
