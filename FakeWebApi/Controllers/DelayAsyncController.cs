using System.Threading;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace FakeWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DelayAsyncController : ControllerBase
    {

        private readonly ILogger<DelayAsyncController> _logger;

        public DelayAsyncController(ILogger<DelayAsyncController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{delay}")]
        public async Task<string> Get(int delay)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            
            await Task.Delay(delay);

            sw.Stop();
            return "Elapsed time: " + sw.Elapsed;
        }
    }
}
