using Microsoft.AspNetCore.Mvc;
using QuckDemoTwilioSms.Models;
using QuckDemoTwilioSms.Wrapper.Classes;
using QuckDemoTwilioSms.Wrapper.Interfaces;
using System.Diagnostics;
using Twilio.TwiML.Messaging;

namespace QuckDemoTwilioSms.Controllers
{
    public class SmsController : Controller
    {
        private readonly ILogger<SmsController> _logger;
        private ITwilioClientWrapper _clientWrapper;

        public SmsController(ILogger<SmsController> logger, ITwilioClientWrapper clientWrapper)
        {
            _logger = logger;
            _clientWrapper = clientWrapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult SendSms([FromBody] Detail detail)
        {
            //validation all handled in the client side js!
            _logger.LogInformation("Request sending...");
            var messageResource =_clientWrapper.Send(detail);
            _logger.LogInformation("Request sent...");

            if (messageResource == null)
            {
                return BadRequest();
            }

            return Ok();
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
