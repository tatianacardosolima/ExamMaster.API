using Common.Shared.Interfaces;
using Common.Shared.Responses;
using MockExam.Manage.Domain.Answers.Entities;
using MockExam.Manage.Domain.Answers.Requests;

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
