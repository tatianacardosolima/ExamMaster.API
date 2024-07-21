using Bogus;
using ExamMaster.Domain.Users.Entities;
using FluentAssertions;

namespace ExamMaster.UnitTests.Entities
{
    public class UserTest
    {
        private readonly Faker _faker = new("pt_BR");


        [Fact]
        [Trait("Action", "CreateUser")]
        public void Create_ShouldConstructEntity()
        {
            // Arrange
            var name = _faker.Name.FullName();
            var email = _faker.Internet.Email();
            var entity = new UserEntity(name, email);

            // Act
            var validated = entity.Validate();

            // Assert            
            DefaultShouldBe(validated, entity,
                    name,
                    email,
                    null,
                    true);
        }

        [Fact]
        [Trait("Action", "CreateUser")]
        public void Create_WithBornDate_ShouldConstructEntity()
        {
            // Arrange
            var name = _faker.Name.FullName();
            var email = _faker.Internet.Email();
            var dateOfBirth = _faker.Person.DateOfBirth.Date;
            var password = _faker.Random.AlphaNumeric(6);
            var entity = new UserEntity(name, email, dateOfBirth, password);

            // Act
            var validated = entity.Validate();

            // Assert            
            DefaultShouldBe(validated, entity,
                    name,
                    email,
                    dateOfBirth,
                    true);
        }

        [Fact]
        [Trait("Action", "UpdateUser")]
        public void Update_ChangeName_ShouldConstructEntity()
        {
            // Arrange
            var name = _faker.Name.FullName();
            var email = _faker.Internet.Email();
            var dateOfBirth = _faker.Person.DateOfBirth.Date;
            var entity = new UserEntity(name, email, dateOfBirth, _faker.Internet.Password(6));
            var newName = _faker.Name.FullName(); 
            // Act
            var validated = entity.Validate();
            entity.ChangeName(newName);
            validated = entity.Validate();

            // Assert            
            DefaultShouldBe(validated, entity,
                    newName,
                    email,
                    dateOfBirth,
                    true);
        }

        [Fact]
        [Trait("Action", "UpdateUser")]
        public void Update_ChangeEmail_ShouldConstructEntity()
        {
            // Arrange
            var name = _faker.Name.FullName();
            var email = _faker.Internet.Email();
            var dateOfBirth = _faker.Person.DateOfBirth.Date;
            var entity = new UserEntity(name, email, dateOfBirth, _faker.Internet.Password(6));
            var newEmail = _faker.Internet.Email(); 
            // Act
            var validated = entity.Validate();
            entity.ChangeEmail(newEmail);
            validated = entity.Validate();

            // Assert            
            DefaultShouldBe(validated, entity,
                    name,
                    newEmail,
                    dateOfBirth,
                    true);
        }

        [Fact]
        [Trait("Action", "UpdateUser")]
        public void Update_ChangeDateOfBirth_ShouldConstructEntity()
        {
            // Arrange
            var name = _faker.Name.FullName();
            var email = _faker.Internet.Email();
            var dateOfBirth = _faker.Person.DateOfBirth.Date;
            var entity = new UserEntity(name, email, dateOfBirth, _faker.Internet.Password(6));
            var newDateOfBirth = _faker.Person.DateOfBirth.Date;
            // Act
            var validated = entity.Validate();
            entity.ChangeDateOfBirth(newDateOfBirth);
            validated = entity.Validate();

            // Assert            
            DefaultShouldBe(validated, entity,
                    name,
                    email,
                    newDateOfBirth,
                    true);
        }

        [Fact]
        [Trait("Action", "UpdateUser")]
        public void Update_ChangeNameAndEmailAndDateOfBirth_ShouldConstructEntity()
        {
            // Arrange
            var name = _faker.Name.FullName();
            var email = _faker.Internet.Email();
            var dateOfBirth = _faker.Person.DateOfBirth.Date;
            var entity = new UserEntity(name, email, dateOfBirth, _faker.Internet.Password(6));
            var newDateOfBirth = _faker.Person.DateOfBirth.Date;
            var newName = _faker.Name.FullName();
            var newEmail = _faker.Internet.Email();
            // Act
            var validated = entity.Validate();
            entity.Change(newName, newEmail, newDateOfBirth);
            validated = entity.Validate();

            // Assert            
            DefaultShouldBe(validated, entity,
                    newName,
                    newEmail,
                    newDateOfBirth,
                    true);
        }

        private void DefaultShouldBe(bool validated, UserEntity entity,
                string name, string email, 
                DateTime? bornDate, bool IsActive)
        {
            Assert.True(validated);
            entity.Should().NotBeNull();
            entity.CreatedAt.Should().BeOnOrBefore(DateTime.UtcNow);
            entity.Name.Should().Be(name);
            entity.Email.Should().Be(email);
            entity.DateOfBirth.Should().Be(bornDate);
            entity.IsActive().Should().Be(IsActive);
        }
    }
}
