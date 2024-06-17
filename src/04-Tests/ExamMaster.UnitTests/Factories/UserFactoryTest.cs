using Bogus;
using ExamMaster.Domain.TakingTest.Exceptions;
using ExamMaster.Domain.TakingTest.Requests;
using ExamMaster.Domain.TestManager.Factories;
using ExamMaster.Domain.Users.Exceptions;
using ExamMaster.Domain.Users.Factories;
using ExamMaster.Domain.Users.Interfaces;
using ExamMaster.Domain.Users.Requests;
using ExamMaster.Shared.Extensions;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace ExamMaster.UnitTests.Factories
{
    public class UserFactoryTest
    {
        private readonly Faker _faker = new("pt_BR");
        [Fact]
        [Trait("Action", "CreateUserAsync")]
        public async Task CreateAsync_User_ShouldCreate()
        {
            var request = Get();
            UserFactory factory = new(GetMockRepository(request.Email).Object);
            var entity = await factory.CreateAsync(request);
            entity.Should().NotBeNull();
            entity.Name.Should().Be(request.Name);
            entity.Email.Should().Be(request.Email);
            entity.DateOfBirth.Should().Be(request.DateOfBirth);
            entity.CreatedAt.Should().BeOnOrBefore(DateTime.UtcNow);

        }

        [Fact]
        [Trait("Action", "CreateUserAsync")]
        public async Task CreateAsync_NullName_ShouldError()
        {
            var request = Get();
            request.Name = null;
            UserFactory factory = new(GetMockRepository(request.Email).Object);

            UserException exception = await Assert.ThrowsAsync<UserException>(() => factory.CreateAsync(request));

            exception.Should().NotBeNull();
            exception.Code.Should().Be("ERROR_USER_NAME_001");
            exception.Message.Should().NotBeNull();
        }

        [Fact]
        [Trait("Action", "CreateUserAsync")]
        public async Task CreateAsync_NameMore200_ShouldError()
        {
            var request = Get();
            request.Name = _faker.Lorem.Sentence(500).Truncate(201);
                
            UserFactory factory = new(GetMockRepository(request.Email).Object);

            UserException exception = await Assert.ThrowsAsync<UserException>(() => factory.CreateAsync(request));

            exception.Should().NotBeNull();
            exception.Code.Should().Be("ERROR_USER_NAME_002");
            exception.Message.Should().NotBeNull();
        }

        [Fact]
        [Trait("Action", "CreateUserAsync")]
        public async Task CreateAsync_NullEmail_ShouldError()
        {
            var request = Get();
            request.Email= null;

            UserFactory factory = new(GetMockRepository(request.Email).Object);

            UserException exception = await Assert.ThrowsAsync<UserException>(() => factory.CreateAsync(request));

            exception.Should().NotBeNull();
            exception.Code.Should().Be("ERROR_USER_EMAIL_003");
            exception.Message.Should().NotBeNull();
        }

        [Fact]
        [Trait("Action", "CreateUserAsync")]
        public async Task CreateAsync_EmailMore200_ShouldError()
        {
            var request = Get();
            request.Email = _faker.Lorem.Sentence(500).Truncate(201);

            UserFactory factory = new(GetMockRepository(request.Email).Object);

            UserException exception = await Assert.ThrowsAsync<UserException>(() => factory.CreateAsync(request));

            exception.Should().NotBeNull();
            exception.Code.Should().Be("ERROR_USER_EMAIL_004");
            exception.Message.Should().NotBeNull();
        }

        [Theory(DisplayName = "Validar se o email é inválido")]
        [InlineData("@g")]
        [InlineData("t@g")]
        [InlineData("t@g.")]
        [InlineData("tatiana&*@gmail.com")]
        [InlineData("tatiana.com")]
        [InlineData("tatiana")]
        [Trait("Action", "Create")]
        public async Task Create_InvalidEmail_ShouldError(string email)
        {
            var request = Get();
            request.Email = email;

            UserFactory factory = new(GetMockRepository(request.Email).Object);

            UserException exception = await Assert.ThrowsAsync<UserException>(() => factory.CreateAsync(request));

            exception.Should().NotBeNull();
            exception.Code.Should().Be("ERROR_USER_EMAIL_005");
            exception.Message.Should().NotBeNull();

        }

        private Mock<IUserRepository> GetMockRepository(string email)
        {
            Mock<IUserRepository> repository = new();
            repository.Setup(c => c.ExistsAsync(x=> x.Email.Equals(email)))
                        .ReturnsAsync(false);
            return repository;
        }

        private UserRequest Get()
        {
            return new UserRequest()
            {
                Name = _faker.Name.FullName(),
                DateOfBirth = _faker.Person.DateOfBirth,
                Email = _faker.Person.Email,
            };
        }
    }
}
