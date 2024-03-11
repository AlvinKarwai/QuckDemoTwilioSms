using Microsoft.AspNetCore.Mvc;
using QuckDemoTwilioSms.Models;
using QuckDemoTwilioSms.Validator;
using QuckDemoTwilioSms.Wrapper.Interfaces;
using System.Diagnostics;

namespace QuckDemoTwilioSms.Controllers
{
    public class SmsController : Controller
    {
        private readonly ILogger<SmsController> _logger;
        private ITwilioClientWrapper _clientWrapper;
        private ISmsValidate _smsValidate;

        public SmsController(ILogger<SmsController> logger, ITwilioClientWrapper clientWrapper, ISmsValidate smsValidate)
        {
            _logger = logger;
            _clientWrapper = clientWrapper;
            _smsValidate = smsValidate;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendSms([FromBody] Detail detail)
        {
            var valid=_smsValidate.IsValid(detail);
            _logger.LogInformation("Request sending...");

            if (valid.Equals(true))
            {
                _clientWrapper.Send(detail);
                _logger.LogInformation("Request sent...");
                return View();
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
