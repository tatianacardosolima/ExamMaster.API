using Common.Shared.Records.Requests;
using Microsoft.AspNetCore.Mvc;
using MockExam.Aggregator.Services;

namespace MockExam.Aggregator.Controllers
{
    [ApiController]
    [Route("manage/mocks-exams")]
    public class ManageMockController : ControllerBase
    {
        private readonly IMockExamService _service;
        private readonly ILogger<ManageMockController> _logger;

        public ManageMockController(ILogger<ManageMockController> logger, IMockExamService service)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Post(MockRequest request)
        {
            return Ok(await _service.PostAsync(request));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, MockRequest request)
        {
            return Ok(await _service.PutAsync(request));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Put(Guid id)
        {
            return Ok(await _service.DeleteByIdAsync(id));
        }
    }
}
