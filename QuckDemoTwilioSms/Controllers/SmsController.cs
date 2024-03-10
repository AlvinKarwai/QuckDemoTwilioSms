using Microsoft.AspNetCore.Mvc;
using QuckDemoTwilioSms.Models;
using QuckDemoTwilioSms.Wrapper.Interfaces;
using System.Diagnostics;

namespace QuckDemoTwilioSms.Controllers
{
    public class SmsController : Controller
    {
        private readonly ILogger<SmsController> _logger;
        private ITwilioClientWrapper _clientWrapper;

        public SmsController(ILogger<SmsController> logger,ITwilioClientWrapper clientWrapper)
        {
            _logger = logger;
            _clientWrapper = clientWrapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SendSms(Detail detail)
        {

            _clientWrapper.Send(detail);

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
