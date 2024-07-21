using MockExam.Manage.Domain.Answers.Entities;
using MockExam.Manage.Domain.Answers.Interfaces;
using MockExam.Manage.Domain.Answers.Requests;

namespace MockExam.Manage.Domain.Answers.Services
{

    public class TestManagerService : IMockService
    {
        private readonly IMockFactory _factory;

        public TestManagerService(IMockFactory factory, ITestManagerRepository repository)
        {
            _factory = factory;

        }
        public Task<MockEntity> ChangeDescriptionAsync(MockRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<MockEntity> ChangeTitleAsync(MockRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<MockEntity> InsertAsync(MockRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
