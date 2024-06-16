using Bogus;
using Bogus.DataSets;
using ExamMaster.Domain.TestManager;
using ExamMaster.Domain.TestManager.Entities;
using ExamMaster.Domain.TestManager.Exceptions;
using ExamMaster.Shared.Extensions;
using FluentAssertions;

namespace ExamMaster.UnitTests.Entities
{
    
    public class TestManagerTest
    {
        private readonly Faker _faker = new ("pt_BR");
        public TestManagerTest() { 
        
        }

        [Fact]
        [Trait("Action", "CreateTestManager")]
        public void CreateTestManager_ShouldConstructTestManagerEntity()
        {            
            // Arrange
            var title = _faker.Lorem.Sentence(50).Truncate(200);
            var description = _faker.Lorem.Sentence(50).Truncate(500);
            var effectivePeriod = new EffectivePeriodValueObject(DateTime.Now, DateTime.Now.AddDays(30));
            var entity = new TestManagerEntity(title, description, effectivePeriod);

            // Act
            var validated = entity.Validate();

            // Assert
            Assert.True(validated);
            entity.Should().NotBeNull();            
            entity.IsActive().Should().BeTrue();
            entity.CreatedAt.Should().BeOnOrBefore(DateTime.UtcNow);            
            entity.Title.Should().Be(title);
            entity.Description.Should().Be(description);
            entity.EffectivePeriod.Should().Be(effectivePeriod);

        }

        
        [Trait("Action", "CreateTestManager")]
        [Fact]
        public void CreateTestManager_WithoutEndDate_ShouldConstructTestManagerEntity()
        {
            // Arrange
            var title = _faker.Lorem.Sentence(50).Truncate(200);
            var description = _faker.Lorem.Sentence(50).Truncate(500);
            var effectivePeriod = new EffectivePeriodValueObject(DateTime.Now, null);
            var entity = new TestManagerEntity(title, description, effectivePeriod);

            // Act
            var validated = entity.Validate();

            // Assert
            Assert.True(validated);
            entity.Should().NotBeNull();
            entity.IsActive().Should().BeTrue();
            entity.CreatedAt.Should().BeOnOrBefore(DateTime.UtcNow);
            entity.Title.Should().Be(title);
            entity.Description.Should().Be(description);
            entity.EffectivePeriod.Should().Be(effectivePeriod);

        }

        [Trait("Action", "UpdateTestManager")]
        [Fact]
        public void UpdateTestManager_ChangeTitleAndDescription_ShouldConstructEntity()
        {
            // Arrange
            var title = _faker.Lorem.Sentence(50).Truncate(200);
            var description = _faker.Lorem.Sentence(50).Truncate(500);
            var effectivePeriod = new EffectivePeriodValueObject(DateTime.Now, null);
            var entity = new TestManagerEntity(title, description, effectivePeriod);

            var newTitle = _faker.Lorem.Sentence(50).Truncate(200);
            var newDescription = _faker.Lorem.Sentence(50).Truncate(500);

            // Act            
            var validated = entity.Validate();
            entity.ChangeTitleAndDescription(newTitle, newDescription);

            // Assert
            Assert.True(validated);
            entity.Should().NotBeNull();
            entity.IsActive().Should().BeTrue();
            entity.CreatedAt.Should().BeOnOrBefore(DateTime.UtcNow);
            entity.ModifiedAt.Should().BeOnOrBefore(DateTime.UtcNow);
            entity.Title.Should().Be(newTitle);
            entity.Description.Should().Be(newDescription);
            entity.EffectivePeriod.Should().Be(effectivePeriod);

        }

        [Trait("Action", "UpdateTestManager")]
        [Fact]
        public void UpdateTestManager_ChangeEffectivePeriod_ShouldConstructEntity()
        {
            // Arrange
            var title = _faker.Lorem.Sentence(50).Truncate(200);
            var description = _faker.Lorem.Sentence(50).Truncate(500);
            var effectivePeriod = new EffectivePeriodValueObject(DateTime.Now, null);
            var entity = new TestManagerEntity(title, description, effectivePeriod);

            var newEffectivePeriod = new EffectivePeriodValueObject(DateTime.Now.AddDays(1), DateTime.Now.AddDays(10));
            
            // Act            
            var validated = entity.Validate();
            entity.ChangeEffectivePeriod(newEffectivePeriod);

            // Assert
            Assert.True(validated);
            entity.Should().NotBeNull();
            entity.IsActive().Should().BeTrue();
            entity.CreatedAt.Should().BeOnOrBefore(DateTime.UtcNow);
            entity.ModifiedAt.Should().BeOnOrBefore(DateTime.UtcNow);
            entity.Title.Should().Be(title);
            entity.Description.Should().Be(description);
            entity.EffectivePeriod.Should().Be(newEffectivePeriod);

        }

        [Trait("Action", "UpdateTestManager")]
        [Fact]
        public void UpdateTestManager_Inactiveted_ShouldConstructEntity()
        {
            // Arrange
            var title = _faker.Lorem.Sentence(50).Truncate(200);
            var description = _faker.Lorem.Sentence(50).Truncate(500);
            var effectivePeriod = new EffectivePeriodValueObject(DateTime.Now, null);
            var entity = new TestManagerEntity(title, description, effectivePeriod);
            
            // Act            
            var validated = entity.Validate();
            entity.Inactivate();

            // Assert
            Assert.True(validated);
            entity.Should().NotBeNull();            
            entity.CreatedAt.Should().BeOnOrBefore(DateTime.UtcNow);
            entity.ModifiedAt.Should().BeOnOrBefore(DateTime.UtcNow);
            entity.Title.Should().Be(title);
            entity.Description.Should().Be(description);
            entity.EffectivePeriod.Should().Be(effectivePeriod);
            entity.Active.Should().BeFalse();

        }
    }
}
