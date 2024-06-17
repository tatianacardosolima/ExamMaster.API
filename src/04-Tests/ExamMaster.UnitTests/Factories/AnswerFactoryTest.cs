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
