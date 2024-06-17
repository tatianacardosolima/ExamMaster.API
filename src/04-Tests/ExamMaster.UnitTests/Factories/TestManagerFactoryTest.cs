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
    public class TestManagerFactoryTest
    {
        private readonly Faker _faker = new("pt_BR");
        [Fact]
        [Trait("Action", "CreateTestManagerAsync")]
        public async Task CreateAsync_TestManager_ShouldCreate()
        {
            var request = Get();

            TestManagerFactory factory = new(GetMockRepository(request.Title).Object);

            var entity = await factory.CreateAsync(request);
            entity.Title.Should().Be(request.Title);
            entity.Description.Should().Be(request.Description);
            entity.EffectivePeriod.StartDate.Should().Be(request.EffectivePeriod.StartDate);
            entity.EffectivePeriod.EndDate.Should().Be(request.EffectivePeriod.EndDate);
        }

        [Fact]
        [Trait("Action", "CreateTestManagerAsync")]
        public async Task CreateAsync_NullTitle_ShouldError()
        {
            var request = Get();
            request.Title = null;

            
            TestManagerFactory factory = new(GetMockRepository(null).Object);
            TestManagerException exception = await Assert.ThrowsAsync<TestManagerException>(() => factory.CreateAsync(request));
            exception.Message.Should().NotBeNullOrEmpty();
            exception.Code.Should().Be("ERROR_TESTMANAGER_TITLE_001");
        }

        [Fact]
        [Trait("Action", "CreateTestManagerAsync")]
        public async Task CreateAsync_TitleMoreThan200_ShouldError()
        {
            var request = Get();
            request.Title = _faker.Lorem.Sentence(201);

            TestManagerFactory factory = new(GetMockRepository(null).Object);
            TestManagerException exception = await Assert.ThrowsAsync<TestManagerException>(() => factory.CreateAsync(request));
            exception.Message.Should().NotBeNullOrEmpty();
            exception.Code.Should().Be("ERROR_TESTMANAGER_TITLE_002");
        }

        [Fact]
        [Trait("Action", "CreateTestManagerAsync")]
        public async Task CreateAsync_DescriptionMoreThan500_ShouldError()
        {
            var request = Get();
            request.Description = _faker.Lorem.Sentence(501);

            TestManagerFactory factory = new(GetMockRepository(request.Title).Object);
            TestManagerException exception = await Assert.ThrowsAsync<TestManagerException>(() => factory.CreateAsync(request));
            exception.Message.Should().NotBeNullOrEmpty();
            exception.Code.Should().Be("ERROR_TESTMANAGER_DESCRIPTION_003");
        }

        [Fact]
        [Trait("Action", "CreateTestManagerAsync")]
        public async Task CreateAsync_TitleAlreadyExists_ShouldError()
        {
            var request = Get();
            Mock<ITestManagerRepository> repository = new();
            repository.Setup(c => c.ExistsAsync(x => x.Title.Equals(request.Title))).ReturnsAsync(true);

            TestManagerFactory factory = new(repository.Object);
            DomainException exception = await Assert.ThrowsAsync<DomainException>(() => factory.CreateAsync(request));
            exception.Message.Should().NotBeNullOrEmpty();
            exception.Code.Should().Be("ERROR_TESTMANAGER_FACTORY_001");
        }

        private Mock<ITestManagerRepository> GetMockRepository(string Title)
        {
            Mock<ITestManagerRepository> repository = new();
            repository.Setup(c => c.ExistsAsync(x => x.Title == Title)).ReturnsAsync(false);
            return repository;
        }
        private TestManagerRequest Get()
        {
            return new TestManagerRequest()
            {
                Title = _faker.Lorem.Sentence(50).Truncate(200),
                Description = _faker.Lorem.Sentence(50).Truncate(500),
                EffectivePeriod = new EffectivePeriodValueObject(DateTime.UtcNow, DateTime.UtcNow.AddDays(10))
            }; 
        }

    }
}
