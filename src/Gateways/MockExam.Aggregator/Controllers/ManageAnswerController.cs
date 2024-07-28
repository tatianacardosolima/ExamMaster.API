using Common.Shared.Records.Requests;
using Microsoft.AspNetCore.Mvc;
using MockExam.Aggregator.Services;

namespace MockExam.Aggregator.Controllers
{
    [ApiController]
    [Route("manage/mocks-exams/questions/anwsers")]
    public class ManageAnswerController : ControllerBase
    {
        private readonly IAnswerService _service;
        private readonly ILogger<ManageQuestionController> _logger;

        public ManageAnswerController(ILogger<ManageQuestionController> logger, IAnswerService service)
        {
            _service = service;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetByQuestion(Guid questionId)
        {
            return Ok(await _service.GetByQuestion(questionId));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Post(AnswerRequest request)
        {
            return Ok(await _service.PostAsync(request));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, UpdAnswerRequest request)
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
