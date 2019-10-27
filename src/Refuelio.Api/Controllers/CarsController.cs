using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;
using Refuelio.Common.Commands;

namespace Refuelio.Api.Controllers
{
    [Route("api/[controller]")]
    public class CarsController : Controller
    {
        private readonly IBusClient _busClient;
        public CarsController(IBusClient busClient)
        {
            _busClient = busClient;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCar command)
        {
            await _busClient.PublishAsync(command);
            return Accepted($"cars/{command.Id}");
        }
    }
}