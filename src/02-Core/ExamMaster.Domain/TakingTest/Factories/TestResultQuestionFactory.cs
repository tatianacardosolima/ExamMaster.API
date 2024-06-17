using ExamMaster.Domain.TakingTest.Entities;
using ExamMaster.Domain.TakingTest.Exceptions;
using ExamMaster.Domain.TakingTest.Interfaces;
using ExamMaster.Domain.TakingTest.Requests;
using ExamMaster.Domain.TestManager.Entities;
using ExamMaster.Domain.TestManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Domain.TakingTest.Factories
{
    public class TestResultQuestionFactory : ITestResultQuestionFactory
    {
        private readonly ITestResultRepository _testResultRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;

        public TestResultQuestionFactory(ITestResultRepository testResultRepository,
            IQuestionRepository questionRepository,
            IAnswerRepository answerRepository)
        {
            _testResultRepository = testResultRepository;
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;

        }
        public async Task<TestResultQuestionEntity> CreateAsync(TestResultQuestionRequest requests)
        {

            TestResultEntity testResultEntity = await _testResultRepository.GetByUniqueIdAsync(requests.TestResultId);
            TestResultQuestionException.ThrowWhen(testResultEntity == null, "ERROR_TESTRESULTQUESTIONFACTORY_TESTRESULT_001", "Teste não encontrado.");

            QuestionEntity questionEntity = await _questionRepository.GetByIdAsync(requests.QuestionId);
            TestResultQuestionException.ThrowWhen(questionEntity == null, "ERROR_TESTRESULTQUESTIONFACTORY_QUERY_002", "Questão não encontrado.");

            AnswerOptionEntity answerOptionEntity = await _answerRepository.GetByIdAsync(requests.AnswerId);
            TestResultQuestionException.ThrowWhen(answerOptionEntity == null, "ERROR_TESTRESULTQUESTIONFACTORY_ANSWER_003", "Resposta não encontrado.");

            var entity = new TestResultQuestionEntity(
                testResultEntity, questionEntity, answerOptionEntity);

            return entity;
        }
    }
}
