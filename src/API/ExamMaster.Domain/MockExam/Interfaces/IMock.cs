using Common.Shared.Interfaces;
using Common.Shared.Records.Requests;
using Common.Shared.Responses;
using MockExam.Manage.Domain.MockExam.Response;
using MockExam.Manage.Domain.Mocks.Entities;

namespace MockExam.Manage.Domain.MockExam.Interfaces
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
    }

    public interface IMockFacade
    {
        Task<DefaultResponse> CreateAsync(MockRequest request);
    }
}
