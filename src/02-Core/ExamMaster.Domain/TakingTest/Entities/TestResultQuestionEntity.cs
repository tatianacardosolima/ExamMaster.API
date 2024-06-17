using ExamMaster.Domain.TakingTest.Exceptions;
using ExamMaster.Domain.TestManager.Entities;
using ExamMaster.Shared.Abstractions;
using ExamMaster.Shared.Records;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Domain.TakingTest.Entities
{
    public class TestResultQuestionEntity : EntityBase
    {
        public TestResultQuestionEntity()
        {
            
        }
        public TestResultQuestionEntity(TestResultEntity testResultEntity,
            QuestionEntity questionEntity,
            AnswerOptionEntity  answerOptionEntity)
        {
            TestResult = testResultEntity;
            Question = questionEntity;
            Answer = answerOptionEntity;
        }
        public TestResultEntity TestResult { get; set; }
        public QuestionEntity Question { get; set; }
        public AnswerOptionEntity Answer { get; set; }


        
        public override bool Validate()
        {
            var validator = new TestResultQuestionValidator();
            var validation = validator.Validate(this);
            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                    _errors.Add(new ErrorRecord(error.ErrorCode, error.ErrorMessage));
                throw new TestResultQuestionException(_errors);
            }
            return true;
        }

        private class TestResultQuestionValidator : AbstractValidator<TestResultQuestionEntity>
        {

            public TestResultQuestionValidator()
            {

                RuleFor(x => x.TestResult).NotEmpty().WithErrorCode("ERROR_TESTRESULTQUESTION_TESTRESULT_001");
                RuleFor(x => x.Question).NotEmpty().WithErrorCode("ERROR_TESTRESULTQUESTION_QUESTION_002");
                RuleFor(x => x.Answer).NotEmpty().WithErrorCode("ERROR_TESTRESULTQUESTION_ANSWER_003");

            }

        }
    }
}
