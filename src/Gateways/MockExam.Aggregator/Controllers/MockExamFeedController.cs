using Common.Shared.Interfaces;
using Common.Shared.Responses;
using Microsoft.AspNetCore.Mvc;
using MockExam.Aggregator.Services;
using System;

namespace MockExam.Aggregator.Controllers
{
    [ApiController]
    [Route("mockexams")]
    public class MockExamFeedController : ControllerBase
    {
        private readonly IMockExamService _service;
        private readonly ILogger<MockExamFeedController> _logger;

        public MockExamFeedController(ILogger<MockExamFeedController> logger, IMockExamService service)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string filter)
        {
            return Ok(await _service.GetByFilter(filter));
        }
        [HttpPost]
        public async Task<IActionResult> Post(string filter)
        {
            return Ok(await _service.GetByFilter(filter));
        }
    }
}
