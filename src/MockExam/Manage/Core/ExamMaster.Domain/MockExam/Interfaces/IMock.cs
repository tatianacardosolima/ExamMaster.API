using Common.Shared.Interfaces;
using Common.Shared.Responses;
using MockExam.Manage.Domain.Answers.Requests;
using MockExam.Manage.Domain.MockExam.Response;
using MockExam.Manage.Domain.Mocks.Entities;

namespace MockExam.Manage.Domain.Answers.Interfaces
{
    public interface IMockFactory: IFactory<MockRequest,MockEntity, Guid>
    {    
        
    }

    public interface IMockService: IService<MockEntity, 
            MockRequest, MockResponse, Guid>
    {        
        Task<DefaultResponse> ChangeTitleAsync(Guid id, string title);
        Task<DefaultResponse> ChangeDescriptionAsync(Guid id, string description);
    }
    public interface IMockRepository : IRepository<MockEntity, Guid>
    {
        Task<MockEntity> GetByUniqueIdAsync(Guid testManagerId);
    }

    public interface IMockFacade
    {
        Task<DefaultResponse> CreateAsync(MockRequest request);
    }
}
