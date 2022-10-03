using LoadBusiness.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LoadApiScoped.Controllers
{
    public class LoadScopedController : ControllerBase
    {
        private readonly IDelayBusiness _delayBusiness;

        public LoadScopedController(IDelayBusiness delayBusiness)
        {
            _delayBusiness = delayBusiness;
        }

        [HttpGet("async")]
        public async Task<IActionResult> GetAsync()
        {
            await _delayBusiness.DelayAsync();
            return NoContent();
        }

        [HttpGet("sync")]
        public IActionResult GetSync()
        {
            _delayBusiness.DelayAsync().Wait();
            return NoContent();
        }
    }
}