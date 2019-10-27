using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;
using Refuelio.Common.Commands;

namespace Refuelio.Api.Controllers
{
    [Route("api/[controller]")]
    public class RefuelsController : Controller
    {
        private readonly IBusClient _busClient;
        public RefuelsController(IBusClient busClient)
        {
            _busClient = busClient;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateRefuel command)
        {
            await _busClient.PublishAsync(command);
            return Accepted($"refuels/{command.Id}");
        }
    }
}