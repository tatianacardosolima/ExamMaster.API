using Common.Shared.Responses;
using MockExam.Manage.Domain.Answers.Exceptions;
using MockExam.Manage.Domain.Answers.Interfaces;
using MockExam.Manage.Domain.Answers.Requests;

namespace MockExam.Manage.Domain.Answers.Facade
{
    internal class MockFacade : ITestManagerFacade
    {
        private readonly ITestManagerRepository _repository;
        private readonly IMockFactory _factory;
        private readonly IQuestionFactory _questionFactory;
        private readonly IAnswerFactory _answerFactory;

        public MockFacade(ITestManagerRepository repository,
            IMockFactory factory, IQuestionFactory questionFactory,
            IAnswerFactory answerFactory)
        {
            _repository = repository;
            _factory = factory;
            _questionFactory = questionFactory;
            _answerFactory = answerFactory;
        }
        public async Task<DefaultResponse> CreateAsync(MockRequest request)
        {
             MockException.ThrowWhen(request == null,
                    "ERROR_TESTMANAGER_REQUEST", "Os dados do testes não podem ser nulos");

            var entity = await _factory.CreateAsync(request);
            if (request.Questions != null)
            {
                foreach (var question in request.Questions)
                {
                    var entityQuestion = await _questionFactory.CreateAsync(question);
                    foreach (var answer in question.Answers)
                    {
                        var entityAnswer = await _answerFactory.CreateAsync(answer);
                        entityQuestion.AddAnswer(entityAnswer);
                    }
                    entity.AddQuestions(entityQuestion);
                }
            }
            await _repository.InsertAsync(entity);

            return new DefaultResponse(true, "Teste Manager Inserido com sucesso!", new { id = entity.Id });

        }
    }
}
