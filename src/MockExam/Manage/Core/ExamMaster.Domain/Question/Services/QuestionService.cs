using Common.Shared.Abstractions;
using Common.Shared.Exceptions;
using Common.Shared.Responses;
using MockExam.Manage.Domain.Answers.Interfaces;
using MockExam.Manage.Domain.Answers.Requests;
using MockExam.Manage.Domain.Question.Response;
using MockExam.Manage.Domain.Questions.Entities;

namespace MockExam.Manage.Domain.Question.Services
{
    public class QuestionService: ServiceBase<QuestionEntity,
            QuestionRequest, QuestionResponse, long>, IQuestionService
    {

        public QuestionService(IQuestionFactory factory, IQuestionRepository repository) : base(repository, factory)
        {
     
        }

        public async Task<DefaultResponse> ChangeStatementAsync(long id, string statement)
        {
            var entity = await base._repository.GetByIdAsync(id);
            DomainException.ThrowWhen(entity == null, "Questão não encontrada");
            entity.ChangeStatement(statement);
            entity.Validate();
            await _repository.SaveChangesAsync();
            return new DefaultResponse(true, "Enunciado alterado com sucesso");
        }
    }
}
