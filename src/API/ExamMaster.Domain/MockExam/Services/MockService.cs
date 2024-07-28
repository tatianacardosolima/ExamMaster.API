using Common.Shared.Abstractions;
using Common.Shared.Records.Requests;
using Common.Shared.Responses;
using MockExam.Manage.Domain.Answers.Interfaces;
using MockExam.Manage.Domain.MockExam.Response;
using MockExam.Manage.Domain.Mocks.Entities;

namespace MockExam.Manage.Domain.Answers.Services
{

    public class MockService : ServiceBase<MockEntity,
            MockRequest, MockResponse, Guid>, IMockService
    {
        private readonly IMockFactory _factory;

        public MockService(IMockFactory factory, IMockRepository repository): base(repository, factory)
        {
            _factory = factory;

        }
        public Task<DefaultResponse> ChangeDescriptionAsync(Guid id, string description)
        {
            throw new NotImplementedException();
        }

        public Task<DefaultResponse> ChangeTitleAsync(Guid id, string title)
        {
            throw new NotImplementedException();
        }

        
    }
}
