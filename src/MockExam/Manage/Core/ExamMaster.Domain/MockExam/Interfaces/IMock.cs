using Common.Shared.Interfaces;
using Common.Shared.Responses;
using MockExam.Manage.Domain.Answers.Entities;
using MockExam.Manage.Domain.Answers.Requests;

namespace MockExam.Manage.Domain.Answers.Interfaces
{
    public interface IMockFactory
    {
        Task<MockEntity> CreateAsync(MockRequest request);
    }

    public interface IMockService
    {
        Task<MockEntity> InsertAsync(MockRequest request);
        Task<MockEntity> ChangeTitleAsync(MockRequest request);
        Task<MockEntity> ChangeDescriptionAsync(MockRequest request);
    }
    public interface ITestManagerRepository : IRepository<MockEntity, Guid>
    {
        Task<MockEntity> GetByUniqueIdAsync(Guid testManagerId);
    }

    public interface ITestManagerFacade
    {
        Task<DefaultResponse> CreateAsync(MockRequest request);
    }
}
