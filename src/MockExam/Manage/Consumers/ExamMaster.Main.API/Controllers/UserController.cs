using Common.Shared.Responses;
using ExamMaster.Domain.Users.Interfaces;
using ExamMaster.Domain.Users.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ExamMaster.API.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<TestManagerController> _logger;
        private readonly IUserService _service;


        public UserController(ILogger<TestManagerController> logger,
            IUserService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        public async Task<DefaultResponse> Post(UserRequest request)
        {
            return await _service.Insert(request);
        }

        [HttpPatch("{id}/name")]
        public async Task<DefaultResponse> ChangeName(Guid id, UserRequest request)
        {
            UpdUserRequest userRequest = (UpdUserRequest)request;
            userRequest.Id = id;
            return await _service.ChangeNameAsync(userRequest);
        }

        [HttpPatch("{id}/email")]
        public async Task<DefaultResponse> ChangeEmail(Guid id, UserRequest request)
        {
            UpdUserRequest userRequest = (UpdUserRequest)request;
            userRequest.Id = id;
            return await _service.ChangeEmailAsync(userRequest);
        }

        [HttpPut("{id}")]
        public async Task<DefaultResponse> Update(Guid id, UserRequest request)
        {
            UpdUserRequest userRequest = (UpdUserRequest)request;
            userRequest.Id = id;
            return await _service.UpdateAsync(userRequest);
        }

        [HttpGet("{id}")]
        public async Task<DefaultResponse> GetById(Guid id)
        {            
            return await _service.GetById(id);
        }
    }
}
