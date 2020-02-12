using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpeedTestApi.Models;

namespace SpeedTestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpeedTestController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ISpeedTestEvents _eventHub;

        public SpeedTestController(ILogger<SpeedTestController> logger, ISpeedTestEvents eventHub)
        {
            _logger = logger;
            _eventHub = eventHub;
        }

        [Route("ping")]
        [HttpGet]
        public string Ping()
        {
            return "PONG";
        }

        [HttpPost]
        public string UploadSpeedTest([FromBody] TestResult speedTest)
        {
            _eventHub.PublishSpeedTestEvents(speedTest);

            var response = $"Got a TestResult from { speedTest.User } with download { speedTest.Data.Speeds.Download } Mbps.";
            _logger.LogInformation(response);

            return response;
        }
    }
}