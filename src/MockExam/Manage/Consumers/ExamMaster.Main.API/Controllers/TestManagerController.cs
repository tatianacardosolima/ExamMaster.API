using Common.Shared.Responses;
using Microsoft.AspNetCore.Mvc;
using MockExam.Manage.Domain.Answers.Interfaces;
using MockExam.Manage.Domain.Answers.Requests;

namespace ExamMaster.API.Controllers
{
    [ApiController]
    [Route("test-manager")]
    public class TestManagerController : ControllerBase
    {        
        private readonly ILogger<TestManagerController> _logger;
        private readonly ITestManagerFacade _facade;

        public TestManagerController(ILogger<TestManagerController> logger,ITestManagerFacade facade)
        {
            _logger = logger;
            _facade = facade;
        }

        [HttpPost]
        public async Task<DefaultResponse> Post(MockRequest request)
        {
            return await _facade.CreateAsync(request);
        }
    }
}
