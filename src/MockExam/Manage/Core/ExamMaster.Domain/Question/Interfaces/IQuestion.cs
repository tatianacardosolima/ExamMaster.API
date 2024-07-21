using Common.Shared.Interfaces;
using Common.Shared.Responses;
using MockExam.Manage.Domain.Answers.Entities;
using MockExam.Manage.Domain.Answers.Requests;
using MockExam.Manage.Domain.Questions.Entities;

namespace MockExam.Manage.Domain.Answers.Interfaces
{
    public interface IQuestionFactory
    {
        Task<QuestionEntity> CreateAsync(QuestionRequest request);
    }

    public interface IQuestionRepository : IRepository<QuestionEntity, long>
    {
    }

    public interface IQuestionService
    {
        Task<DefaultResponse> Update(QuestionRequest request);
    }
}
