using System.Threading;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FakeWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DelayController : ControllerBase
    {

        private readonly ILogger<DelayController> _logger;

        public DelayController(ILogger<DelayController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{delay}")]
        public string Get(int delay)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            
            Thread.Sleep(delay);

            sw.Stop();
            return "Elapsed time: " + sw.Elapsed;
        }
    }
}
