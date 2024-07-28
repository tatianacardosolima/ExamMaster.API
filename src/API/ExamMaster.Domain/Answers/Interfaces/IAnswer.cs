using Common.Shared.Interfaces;
using Common.Shared.Records.Requests;
using Common.Shared.Requests;
using Common.Shared.Responses;
using MockExam.Manage.Domain.Answers.Entities;
using MockExam.Manage.Domain.MockExam.Response;
using MockExam.Manage.Domain.Mocks.Entities;

namespace MockExam.Manage.Domain.Answers.Interfaces
{
    public interface IAnswerFactory: IFactory<UpdAnswerRequest, AnswerOptionEntity, long>
    {
        Task<AnswerOptionEntity> CreateAsync(UpdAnswerRequest request);
    }

    public interface IAnswerRepository : IRepository<AnswerOptionEntity, long>
    {
    }

    public interface IAnswerService: IService<AnswerOptionEntity,
            UpdAnswerRequest,AnswerResponse, long>
    {
        
    }
}
