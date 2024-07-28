using Common.Shared.Records.Requests;
using Microsoft.AspNetCore.Mvc;
using MockExam.Aggregator.Services;

namespace MockExam.Aggregator.Controllers
{
    [ApiController]
    [Route("manage/mocks-exams/questions")]
    public class ManageQuestionController : ControllerBase
    {
        private readonly IQuestionService _service;
        private readonly ILogger<ManageQuestionController> _logger;

        public ManageQuestionController(ILogger<ManageQuestionController> logger, IQuestionService service)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetByMockExam(Guid mockexamid)
        {
            return Ok(await _service.GetByMockExam(mockexamid));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Post(QuestionRequest request)
        {
            return Ok(await _service.PostAsync(request));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, UpdQuestionRequest request)
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
