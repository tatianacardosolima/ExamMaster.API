using Common.Shared.Interfaces;
using Common.Shared.Records.Requests;
using Common.Shared.Responses;
using MockExam.Manage.Domain.Answers.Entities;

namespace MockExam.Manage.Domain.Answers.Interfaces
{
    public interface IAnswerFactory
    {
        Task<AnswerOptionEntity> CreateAsync(AnswerRequest request);
    }

    public interface IAnswerRepository : IRepository<AnswerOptionEntity, int>
    {
    }

    public interface IAnswerService
    {
        Task<DefaultResponse> Update(QuestionRequest request);
    }
}
