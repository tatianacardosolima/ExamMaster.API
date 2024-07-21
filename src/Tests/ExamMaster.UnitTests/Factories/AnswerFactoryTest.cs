using Bogus;
using FluentAssertions;
using MockExam.Manage.Domain.Answers.Exceptions;
using MockExam.Manage.Domain.Answers.Factories;
using MockExam.Manage.Domain.Answers.Interfaces;
using MockExam.Manage.Domain.Answers.Requests;
using Moq;
using Common.Shared.Extensions;

namespace ExamMaster.UnitTests.Factories
{
    public class AnswerFactoryTest
    {
        private readonly Faker _faker = new("pt_BR");
        [Fact]
        [Trait("Action", "CreateAnswerAsync")]
        public async Task CreateAsync_Answer_ShouldCreate()
        {
            var request = Get();
            AnswerFactory factory = new(GetMockRepository(request.Answer).Object);
            var entity = await factory.CreateAsync(request);
            entity.Answer.Should().Be(request.Answer);
            entity.IsCorrectAnswer.Should().Be(request.IsCorrect);
            
        }

        [Fact]
        [Trait("Action", "CreateAnswerAsync")]
        public async Task CreateAsync_NullAnswer_ShouldError()
        {
            var request = Get();
            request.Answer = null;

            AnswerFactory factory = new(GetMockRepository(null).Object);
            AnswerOptionException exception = await Assert.ThrowsAsync<AnswerOptionException>(() => factory.CreateAsync(request));
            exception.Message.Should().NotBeNullOrEmpty();
            exception.Code.Should().Be("ERROR_ANSWEROPTION_DESCRIPTION_001");
        }

        [Fact]
        [Trait("Action", "CreateAnswerAsync")]
        public async Task CreateAsync_AnswerMoreThan300_ShouldError()
        {
            var request = Get();
            request.Answer = _faker.Lorem.Sentence(501);

            AnswerFactory factory = new(GetMockRepository(request.Answer).Object);
            AnswerOptionException exception = await Assert.ThrowsAsync<AnswerOptionException>(() => factory.CreateAsync(request));
            exception.Message.Should().NotBeNullOrEmpty();
            exception.Code.Should().Be("ERROR_ANSWEROPTION_DESCRIPTION_002");
        }

        
        private Mock<IAnswerRepository> GetMockRepository(string answer)
        {
            Mock<IAnswerRepository> repository = new();
            repository.Setup(c => c.ExistsAsync(x => x.Answer  == answer)).ReturnsAsync(false);
            return repository;
        }
        private AnswerRequest Get()
        {
            return new AnswerRequest()
            {
                Answer = _faker.Lorem.Sentence(50).Truncate(200),
                IsCorrect = true
            }; 
        }

    }
}
