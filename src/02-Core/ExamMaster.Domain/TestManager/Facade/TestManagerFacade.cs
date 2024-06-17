using ExamMaster.Domain.TestManager.Exceptions;
using ExamMaster.Domain.TestManager.Factories;
using ExamMaster.Domain.TestManager.Interfaces;
using ExamMaster.Domain.TestManager.Requests;
using ExamMaster.Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Domain.TestManager.Facade
{
    internal class TestManagerFacade : ITestManagerFacade
    {
        private readonly ITestManagerRepository _repository;
        private readonly ITestManagerFactory _factory;
        private readonly IQuestionFactory _questionFactory;
        private readonly IAnswerFactory _answerFactory;

        public TestManagerFacade(ITestManagerRepository repository, 
            ITestManagerFactory factory, IQuestionFactory questionFactory,
            IAnswerFactory answerFactory)
        {
            _repository = repository;
            _factory = factory;
            _questionFactory = questionFactory;
            _answerFactory = answerFactory;
        }
        public async Task<DefaultResponse> Create(TestManagerRequest request)
        {
            TestManagerException.ThrowWhen(request == null, 
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
