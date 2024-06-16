using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace ExamMaster.API.Controllers
{
    [ApiController]
    [Route("test-manager")]
    public class TestManagerController : ControllerBase
    {        
        private readonly ILogger<TestManagerController> _logger;

        public TestManagerController(ILogger<TestManagerController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<List<string>> GetAllTestsAsync()
        {
            return null;
        }
    }
}
