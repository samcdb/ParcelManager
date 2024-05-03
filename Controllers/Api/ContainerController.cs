using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParcelManager.Models;
using ParcelManager.Models.DataTransfer;
using ParcelManager.Services.Interfaces;

namespace ParcelManager.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainerController : ControllerBase
    {
        private readonly IDistributionService _distributionService;

        public ContainerController(IDistributionService distributionService)
        {
            _distributionService = distributionService;
        }

        [HttpPost("process")]
        [Consumes("application/xml")]
        public async Task<IActionResult> ProcessContainer([FromBody] ContainerDto container)
        {
            await _distributionService.ProcessContainer(container);

            return Ok();
        }
    }
}
