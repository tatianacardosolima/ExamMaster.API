using Common.Shared.Records.Requests;
using Common.Shared.Responses;
using Microsoft.AspNetCore.Mvc;
using MockExam.Manage.Domain.Answers.Interfaces;
using MockExam.Manage.Domain.MockExam.Interfaces;

namespace MockExam.Manage.API.Manage.Controllers
{
    [ApiController]
    [Route("mocks-manager")]
    public class MockController : ControllerBase
    {
        private readonly ILogger<MockController> _logger;
        private readonly IMockService _service;

        public MockController(ILogger<MockController> logger, IMockService _service)
        {
            _logger = logger;
            _service = _service;
        }

        [HttpPost]
        public async Task<DefaultResponse> Post(MockRequest request)
        {
            return await _service.InsertAsync(request);
        }

        [HttpPatch("{id}/title")]
        public async Task<DefaultResponse> PatchTitle(Guid id, MockRequest request)
        {
            return await _service.ChangeTitleAsync(id, request.Title);
        }

        [HttpPatch("{id}/description")]
        public async Task<DefaultResponse> PatchDescription(Guid id, MockRequest request)
        {
            return await _service.ChangeDescriptionAsync(id, request.Title);
        }

        [HttpGet]
        public async Task<DefaultResponse> GetById(Guid id)
        {
            return await _service.GetByIdAsync(id);
        }
    }
}
