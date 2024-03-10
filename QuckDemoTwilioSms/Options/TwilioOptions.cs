namespace QuckDemoTwilioSms.Options
{
    public class TwilioOptions
    {
        public const string Twilio = "TWILIO";
        public string SID { get; set; } = string.Empty;
        public string TOKEN { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
