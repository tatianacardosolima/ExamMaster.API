using Bogus;
using ExamMaster.Domain.TakingTest.Entities;
using ExamMaster.Domain.TestManager.Entities;
using ExamMaster.Domain.TestManager.ValueObjects;
using ExamMaster.Domain.Users;
using ExamMaster.Shared.Extensions;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.UnitTests.Entities
{
    public class TestResultQuestionTest
    {
        private readonly Faker _faker = new("pt_BR");


        [Fact]
        [Trait("Action", "CreateTestResultQuestion")]
        public void Create_TestResultQuestion_ShouldConstructEntity()
        {
            // Arrange
            var testResult = GetTestResult();
            var question = GetQuestion();
            var answer = GetAnswerOption();
            
            var entity = new TestResultQuestionEntity(testResult, question, answer);

            // Act
            var validated = entity.Validate();

            // Assert            
            DefaultShouldBe(validated, entity,testResult,question, answer,true);
        }

        private void DefaultShouldBe(bool validated, TestResultQuestionEntity entity,
            TestResultEntity testResult,            
            QuestionEntity resultQuestion,
            AnswerOptionEntity answer,
            bool IsActive)
        {
            Assert.True(validated);
            entity.Should().NotBeNull();
            entity.CreatedAt.Should().BeOnOrBefore(DateTime.UtcNow);
            entity.TestResult.Should().Be(testResult);
            entity.Question.Should().Be(resultQuestion);
            entity.Answer.Should().Be(answer);
            entity.IsActive().Should().Be(IsActive);
        }

        
        private UserEntity GetUser()
        {
            return new UserEntity(_faker.Name.FullName());
        }

        private TestManagerEntity GetTestManager()
        {
            var title = _faker.Lorem.Sentence(50).Truncate(200);
            var description = _faker.Lorem.Sentence(50).Truncate(500);
            var effectivePeriod = new EffectivePeriodValueObject(DateTime.Now, DateTime.Now.AddDays(30));
            return new TestManagerEntity(title, description, effectivePeriod);

        }

        private TestResultEntity GetTestResult()
        {
            var testManagerEntity = GetTestManager();
            var userEntity = GetUser();
            return new TestResultEntity(testManagerEntity, userEntity);
        }

        private QuestionEntity GetQuestion()
        {
            var testManagerEntity = GetTestManager();
            var userEntity = GetUser();
            return new QuestionEntity(_faker.Lorem.Sentence(10).Truncate(200), QuestionType.SingleOption );
        }

        private AnswerOptionEntity GetAnswerOption()
        {
            var testManagerEntity = GetTestManager();
            var userEntity = GetUser();
            return new AnswerOptionEntity(_faker.Lorem.Sentence(10).Truncate(200), false);
        }
    }
}
