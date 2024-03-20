using Castle.Core.Logging;
using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using QuckDemoTwilioSms.Controllers;
using QuckDemoTwilioSms.Models;
using QuckDemoTwilioSms.Wrapper.Interfaces;
using Xunit;

namespace QuickDemoTwilioSmsTests
{
    public class SmsTest
    {
        private readonly Mock<ITwilioClientWrapper> _repos;
        private readonly Mock<ILogger<SmsController>> _logger;
        
        public SmsTest()
        {
            _repos = new Mock<ITwilioClientWrapper>();
            _logger = new Mock<ILogger<SmsController>>();
        }

        [Fact]
        public void TestShouldCallSmsControllerSendMethod()
        {
            //Arrange

            var detail = new Detail()
            {
                Message = "Hi My name is Alvin Please message me about any potential Job roles",
                PhoneNumber = "+447477118817"
            };

            //Act
            var controler = new SmsController(_logger.Object,_repos.Object);

            controler.SendSms(detail);

        }
    }
}