using ExamMaster.Domain.TestManager.Interfaces;
using ExamMaster.Domain.TestManager.Requests;
using ExamMaster.Shared.Response;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

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
        public async Task<DefaultResponse> SaveAll(TestManagerRequest request)
        {
            return await _facade.CreateAsync(request);
        }
    }
}
