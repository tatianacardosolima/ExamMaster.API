using Common.Shared.Responses;
using Microsoft.AspNetCore.Mvc;
using MockExam.Manage.Domain.Answers.Interfaces;
using MockExam.Manage.Domain.Answers.Requests;

namespace MockExam.Manage.API.Controllers
{
    [ApiController]
    [Route("mocks-manager")]
    public class QuestionsController : ControllerBase
    {
        private readonly ILogger<QuestionsController> _logger;
        private readonly IQuestionService _service;

        public QuestionsController(ILogger<QuestionsController> logger, IQuestionService _service)
        {
            _logger = logger;
            _service = _service;
        }

        [HttpPost("questions")]
        public async Task<DefaultResponse> Post(QuestionRequest request)
        {
            return await _service.InsertAsync(request);
        }

        [HttpPatch("questions/{id}/title")]
        public async Task<DefaultResponse> PatchStatement(long id, QuestionRequest request)
        {
            return await _service.ChangeStatementAsync(id, request.Statement);
        }


        [HttpGet("questions/{id}")]
        public async Task<DefaultResponse> GetById(long id)
        {
            return await _service.GetByIdAsync(id);
        }
    }
}
