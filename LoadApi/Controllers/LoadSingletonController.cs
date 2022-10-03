using LoadBusiness.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LoadApi.Controller
{
    public class LoadSingletonController : ControllerBase
    {
        private readonly IDelayBusiness _delayBusiness;
        private readonly int _times = 10;

        public LoadSingletonController(IDelayBusiness delayBusiness)
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

        [HttpGet("async-awaited")]
        public async Task<IActionResult> GetAwaitedAsync()
        {
            var sequency = new List<int>();
            for (int i = 0; i < _times; i++)
            {
                sequency.Add(await _delayBusiness.DelayAsyncInt(i));
            }
            return Ok(sequency);
        }

        [HttpGet("async-task")]
        public async Task<IActionResult> GetTaskAsync()
        {
            var sequency = new List<int>();
            for (int i = 0; i < _times; i++)
            {
                _ = _delayBusiness.DelayAsyncInt(i);
                sequency.Add(i);
            }

            return Ok(sequency);
        }

        [HttpGet("sync-whithout-task")]
        public IActionResult GetWithoutTaskSync()
        {
            var sequency = new List<int>();
            for (int i = 0; i < _times; i++)
            {
                _ = _delayBusiness.DelayAsyncInt(i);
                sequency.Add(i);
            }

            return Ok(sequency);
        }

        [HttpGet("async-when-all")]
        public async Task<IActionResult> GetWhenAllAsync()
        {
            var sequencyTask = new List<Task<int>>();
            for (int i = 0; i < _times; i++)
            {
                sequencyTask.Add(_delayBusiness.DelayAsyncInt(i));
            }
           
            await Task.WhenAll(sequencyTask);

            return Ok(sequencyTask.Select(s => s.Result));
        }

        [HttpGet("async-exception")]
        public async Task<IActionResult> GetAsyncException()
        {
            var sequency = new List<int>();
            for (int i = 0; i < _times; i++)
            {
                _ = _delayBusiness.DelayAsyncIntException(i);
                sequency.Add(i);
            }

            return Ok(sequency);
        }
    }
}