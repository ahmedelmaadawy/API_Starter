using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace RESTAPI_starter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private ILoggerManager _logger;
        public WeatherForecastController(ILoggerManager logger)
        {
            this._logger = logger;
        }

        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        [HttpGet]
        public IEnumerable<string> Get()
        {
            _logger.LogInfo("Here is info message from our values controller");
            _logger.LogDebug("Here is debug message from our values controller");
            _logger.LogWarn("Here is warn message from our values controller");
            _logger.LogError("Here is error message from our values controller");

            return new string[] { "value 1 ", "value 2" };
        }
    }
}