using Bogus;
using FluentAssertions;
using MockExam.Manage.Domain.Answers.Entities;
using MockExam.Manage.Domain.Answers.Exceptions;
using MockExam.Manage.Domain.Answers.Factories;
using MockExam.Manage.Domain.Answers.Interfaces;
using MockExam.Manage.Domain.Answers.Requests;
using static Common.Shared.Extensions.StringExtension;
using Moq;
using MockExam.Manage.Domain.Questions.Entities;

namespace ExamMaster.UnitTests.Factories
{
    public class QuestionFactoryTest
    {
        private readonly Faker _faker = new("pt_BR");
        [Fact]
        [Trait("Action", "CreateQuestionAsync")]
        public async Task CreateAsync_Question_ShouldCreate()
        {
            var request = Get();
            QuestionFactory factory = new(GetMockRepository(request.Statement).Object);
            var entity = await factory.CreateAsync(request);
            entity.Statement.Should().Be(request.Statement);
            entity.QuestionType.Should().Be(request.QuestionType);
            
        }

        [Fact]
        [Trait("Action", "CreateQuestionAsync")]
        public async Task CreateAsync_NullPrompt_ShouldError()
        {
            var request = Get();
            request.Statement = null;

            QuestionFactory factory = new(GetMockRepository(null).Object);
            QuestionException exception = await Assert.ThrowsAsync<QuestionException>(() => factory.CreateAsync(request));
            exception.Message.Should().NotBeNullOrEmpty();
            exception.Code.Should().Be("ERROR_QUESTION_PROMPT_001");
        }

        [Fact]
        [Trait("Action", "CreateQuestionAsync")]
        public async Task CreateAsync_PromptMoreThan300_ShouldError()
        {
            var request = Get();
            request.Statement = _faker.Lorem.Sentence(501);

            QuestionFactory factory = new(GetMockRepository(request.Statement).Object);
            QuestionException exception = await Assert.ThrowsAsync<QuestionException>(() => factory.CreateAsync(request));
            exception.Message.Should().NotBeNullOrEmpty();
            exception.Code.Should().Be("ERROR_QUESTION_PROMPT_002");
        }

        
        private Mock<IQuestionRepository> GetMockRepository(string QuestionPrompt)
        {
            Mock<IQuestionRepository> repository = new();
            repository.Setup(c => c.ExistsAsync(x => x.Statement == QuestionPrompt)).ReturnsAsync(false);
            return repository;
        }
        private QuestionRequest Get()
        {
            return new QuestionRequest()
            {
                Statement = _faker.Lorem.Sentence(50).Truncate(200),
                QuestionType = QuestionType.SingleOption
            }; 
        }

    }
}
