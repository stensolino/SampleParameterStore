using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SampleParameterStore.Config;
using System.Collections.Generic;

namespace SampleParameterStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly SomeConfig _someConfig;

        public WeatherForecastController(IConfiguration configuration, IOptionsSnapshot<SomeConfig> options)
        {
            _configuration = configuration;
            _someConfig = options.Value;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            var config = _configuration.GetSection("SomeKey").Value;

            return new[] { config, _someConfig.FirstValue, _someConfig.SecondValue };
        }
    }
}
