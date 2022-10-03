using LoadBusiness.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LoadApiTransient.Controllers
{
    public class LoadTransientController : ControllerBase
    {
        private readonly IDelayBusiness _delayBusiness;

        public LoadTransientController(IDelayBusiness delayBusiness)
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