using Common.Shared.Interfaces;
using Common.Shared.Records.Requests;
using Common.Shared.Responses;
using MockExam.Manage.Domain.Question.Response;
using MockExam.Manage.Domain.Questions.Entities;

namespace MockExam.Manage.Domain.Answers.Interfaces
{
    public interface IQuestionFactory: IFactory<QuestionRequest, QuestionEntity, long>
    {
        Task<QuestionEntity> CreateAsync(QuestionRequest request);
    }

    public interface IQuestionRepository : IRepository<QuestionEntity, long>
    {
    }

    public interface IQuestionService : IService<QuestionEntity,
            QuestionRequest, QuestionResponse, long>
    {
        Task<DefaultResponse> ChangeStatementAsync(long id, string statement);
    }
}
