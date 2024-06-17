using Bogus;
using ExamMaster.Domain.TakingTest.Entities;
using ExamMaster.Domain.TakingTest.Exceptions;
using ExamMaster.Domain.TakingTest.Factories;
using ExamMaster.Domain.TakingTest.Interfaces;
using ExamMaster.Domain.TakingTest.Requests;
using ExamMaster.Domain.TestManager.Entities;
using ExamMaster.Domain.TestManager.Exceptions;
using ExamMaster.Domain.TestManager.Factories;
using ExamMaster.Domain.TestManager.Interfaces;
using ExamMaster.Domain.TestManager.Requests;
using ExamMaster.Domain.TestManager.ValueObjects;
using ExamMaster.Domain.Users;
using ExamMaster.Domain.Users.Interfaces;
using ExamMaster.Shared.Exceptions;
using ExamMaster.Shared.Extensions;
using FluentAssertions;
using Microsoft.VisualBasic;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.UnitTests.Factories
{
    public class TestResultFactoryTest
    {
        private readonly Faker _faker = new("pt_BR");
        [Fact]
        [Trait("Action", "CreateTestResultAsync")]
        public async Task CreateAsync_TestResultr_ShouldCreate()
        {
            var request = Get();
            TestResultFactory factory = new(GetTestManagerRepository(request.TestManagerId).Object,
                GetUserRepository(request.UserId).Object);

            var entity = await factory.CreateAsync(request);

            entity.Should().NotBeNull();
            entity.TestManager.Should().NotBeNull();
            entity.User.Should().NotBeNull();
            entity.TestStatus.Should().Be(TestStatus.NotStarted);
        }

        [Fact]
        [Trait("Action", "CreateTestResultAsync")]
        public async Task CreateAsync_NotFoundTestManager_ShouldError()
        {
            var request = Get();
            TestResultFactory factory = new(GetTestManagerRepository(Guid.NewGuid()).Object,
                GetUserRepository(request.UserId).Object);

            
            TestResultException exception = await Assert.ThrowsAsync<TestResultException>(() => factory.CreateAsync(request));
            exception.Message.Should().NotBeNullOrEmpty();
            exception.Code.Should().Be("ERROR_TESTRESULTFACTORY_001");
        }

        [Fact]
        [Trait("Action", "CreateTestResultAsync")]
        public async Task CreateAsync_NotFoundUser_ShouldError()
        {
            var request = Get();


            TestResultFactory factory = new(GetTestManagerRepository(request.TestManagerId).Object,
               GetUserRepository(Guid.NewGuid()).Object);


            TestResultException exception = await Assert.ThrowsAsync<TestResultException>(() => factory.CreateAsync(request));
            exception.Message.Should().NotBeNullOrEmpty();
            exception.Code.Should().Be("ERROR_TESTRESULTFACTORY_002");
        }

        private Mock<ITestManagerRepository> GetTestManagerRepository(Guid uniqueid)
        {
            Mock<ITestManagerRepository> repository = new();
            repository.Setup(c => c.GetByUniqueIdAsync(uniqueid)).ReturnsAsync(
                    new TestManagerEntity(_faker.Lorem.Sentence(10).Truncate(200),
                    _faker.Lorem.Sentence(10).Truncate(500),
                    new EffectivePeriodValueObject(DateTime.UtcNow)
                    ));
            return repository;
        }

        private Mock<IUserRepository> GetUserRepository(Guid uniqueid)
        {
            Mock<IUserRepository> repository = new();
            repository.Setup(c => c.GetByUniqueIdAsync(uniqueid)).ReturnsAsync(
                    new UserEntity(_faker.Name.FullName()));
            return repository;
        }

        private TestResultRequest Get()
        {
            return new TestResultRequest()
            {
              UserId = Guid.NewGuid(),
              TestManagerId = Guid.NewGuid()

            };
        }
    }
}
