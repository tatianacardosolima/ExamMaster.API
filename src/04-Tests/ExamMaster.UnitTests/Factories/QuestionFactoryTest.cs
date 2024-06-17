using Bogus;
using ExamMaster.Domain.TestManager.Entities;
using ExamMaster.Domain.TestManager.Exceptions;
using ExamMaster.Domain.TestManager.Factories;
using ExamMaster.Domain.TestManager.Interfaces;
using ExamMaster.Domain.TestManager.Requests;
using ExamMaster.Domain.TestManager.ValueObjects;
using ExamMaster.Shared.Exceptions;
using ExamMaster.Shared.Extensions;
using ExamMaster.Shared.Interfaces;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            QuestionFactory factory = new(GetMockRepository(request.QuestionPrompt).Object);
            var entity = await factory.CreateAsync(request);
            entity.QuestionPrompt.Should().Be(request.QuestionPrompt);
            entity.QuestionType.Should().Be(request.QuestionType);
            
        }

        [Fact]
        [Trait("Action", "CreateQuestionAsync")]
        public async Task CreateAsync_NullPrompt_ShouldError()
        {
            var request = Get();
            request.QuestionPrompt = null;

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
            request.QuestionPrompt = _faker.Lorem.Sentence(501);

            QuestionFactory factory = new(GetMockRepository(request.QuestionPrompt).Object);
            QuestionException exception = await Assert.ThrowsAsync<QuestionException>(() => factory.CreateAsync(request));
            exception.Message.Should().NotBeNullOrEmpty();
            exception.Code.Should().Be("ERROR_QUESTION_PROMPT_002");
        }

        
        private Mock<IQuestionRepository> GetMockRepository(string QuestionPrompt)
        {
            Mock<IQuestionRepository> repository = new();
            repository.Setup(c => c.ExistsAsync(x => x.QuestionPrompt == QuestionPrompt)).ReturnsAsync(false);
            return repository;
        }
        private QuestionRequest Get()
        {
            return new QuestionRequest()
            {
                QuestionPrompt = _faker.Lorem.Sentence(50).Truncate(200),
                QuestionType = QuestionType.SingleOption
            }; 
        }

    }
}
