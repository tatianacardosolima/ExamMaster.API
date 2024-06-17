using Bogus;
using ExamMaster.Domain.TestManager.Entities;
using ExamMaster.Domain.TestManager.ValueObjects;
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
            DefaultShouldBe(validated, entity, title, description, effectivePeriod);            
            entity.IsActive().Should().BeTrue();            

        }
        [Trait("Action", "CreateTestManager")]
        [Fact]
        public void Create_WithQuestions_ShouldConstructEntity()
        {
            // Arrange
            var title = _faker.Lorem.Sentence(50).Truncate(200);
            var description = _faker.Lorem.Sentence(50).Truncate(500);
            var effectivePeriod = new EffectivePeriodValueObject(DateTime.Now, null);
            var entity = new TestManagerEntity(title, description, effectivePeriod);
            entity.AddQuestions(new QuestionEntity(_faker.Lorem.Text(), QuestionType.SingleOption));
            entity.AddQuestions(new QuestionEntity(_faker.Lorem.Text(), QuestionType.MultipleOption));

            // Act            
            var validated = entity.Validate();

            // Assert
            DefaultShouldBe(validated, entity, title, description, effectivePeriod);
            entity.IsActive().Should().BeTrue();
            entity.Questions.Should().HaveCount(2);
            entity.Questions.Where(x => x.QuestionType == QuestionType.MultipleOption).Should().HaveCount(1);
            entity.Questions.Where(x => x.QuestionType == QuestionType.SingleOption).Should().HaveCount(1);

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
            DefaultShouldBe(validated, entity, newTitle, newDescription, effectivePeriod);                        
            entity.IsActive().Should().BeTrue();            
            entity.ModifiedAt.Should().BeOnOrBefore(DateTime.UtcNow);
            

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
            DefaultShouldBe(validated, entity, title, description, newEffectivePeriod);            
            entity.IsActive().Should().BeTrue();            
            entity.ModifiedAt.Should().BeOnOrBefore(DateTime.UtcNow);            

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
            DefaultShouldBe(validated, entity, title, description, effectivePeriod);            
            entity.ModifiedAt.Should().BeOnOrBefore(DateTime.UtcNow);                        
            entity.Active.Should().BeFalse();

        }


        [Trait("Action", "UpdateTestManager")]
        [Fact]
        public void Update_WithQuestions_ShouldConstructEntity()
        {
            // Arrange
            var title = _faker.Lorem.Sentence(50).Truncate(200);
            var description = _faker.Lorem.Sentence(50).Truncate(500);
            var effectivePeriod = new EffectivePeriodValueObject(DateTime.Now, null);
            var entity = new TestManagerEntity(title, description, effectivePeriod);
            entity.AddQuestions(new QuestionEntity(_faker.Lorem.Text(), QuestionType.SingleOption));
            entity.AddQuestions(new QuestionEntity(_faker.Lorem.Text(), QuestionType.MultipleOption));

            // Act            
            var validated = entity.Validate();
            
            entity.AddQuestions(new QuestionEntity(_faker.Lorem.Text(), QuestionType.MultipleOption));

            // Assert
            DefaultShouldBe(validated, entity, title, description, effectivePeriod);
            entity.IsActive().Should().BeTrue();
            entity.Questions.Should().HaveCount(3);
            entity.Questions.Where(x => x.QuestionType == QuestionType.MultipleOption).Should().HaveCount(2);
            entity.Questions.Where(x => x.QuestionType == QuestionType.SingleOption).Should().HaveCount(1);

        }

        public void DefaultShouldBe(bool validated, TestManagerEntity entity, string title, string description, EffectivePeriodValueObject effectivePeriod)
        {
            Assert.True(validated);
            entity.Should().NotBeNull();
            entity.CreatedAt.Should().BeOnOrBefore(DateTime.UtcNow);
            entity.Title.Should().Be(title);
            entity.Description.Should().Be(description);
            entity.EffectivePeriod.Should().Be(effectivePeriod);
        }
    }
}
