using Bogus;
using FluentAssertions;
using MockExam.Manage.Domain.Answers.Entities;
using Common.Shared.Extensions;

namespace ExamMaster.UnitTests.Entities
{

    public class AnswerOptionTest
    {
        private readonly Faker _faker = new ("pt_BR");
        public AnswerOptionTest() { 
        
        }

        [Fact]
        [Trait("Action", "CreateAnswerOption")]
        public void Create_CorretAnswer_ShouldConstructEntity()
        {            
            // Arrange
            var description = _faker.Lorem.Sentence(50).Truncate(200);            
            var entity = new AnswerOptionEntity(description, true);

            // Act
            var validated = entity.Validate();

            // Assert            
            DefaultShouldBe(validated, entity, description, true, true);            
        }

        [Fact]
        [Trait("Action", "CreateAnswerOption")]
        public void Create_Incorrect_ShouldConstructEntity()
        {
            // Arrange
            var description = _faker.Lorem.Sentence(50).Truncate(200);
            var entity = new AnswerOptionEntity(description, false);

            // Act
            var validated = entity.Validate();

            // Assert            
            DefaultShouldBe(validated, entity, description, false, true);


        }

        

        [Fact]
        [Trait("Action", "UpdateAnswerOption")]
        public void Update_Prompt_ShouldConstructEntity()
        {
            // Arrange
            var description = _faker.Lorem.Sentence(50).Truncate(200);
            var entity = new AnswerOptionEntity(description, false);
            var newdescription = _faker.Lorem.Sentence(50).Truncate(200);
                
            // Act
            var validated = entity.Validate();
            entity.ChangeDescription(newdescription);
            validated = entity.Validate();

            // Assert            
            DefaultShouldBe(validated, entity, newdescription, false, true);
            
        }

        [Fact]
        [Trait("Action", "UpdateAnswerOption")]
        public void Update_CorrectToIncorrect_ShouldConstructEntity()
        {
            // Arrange
            // Arrange
            var description = _faker.Lorem.Sentence(50).Truncate(200);
            var entity = new AnswerOptionEntity(description, true);            

            // Act
            var validated = entity.Validate();
            entity.SetIncorrectAnswer();
            validated = entity.Validate();

            // Assert            
            DefaultShouldBe(validated, entity, description, false, true);
        }

        [Fact]
        [Trait("Action", "UpdateAnswerOption")]
        public void Update_IncorrectToCorrect_ShouldConstructEntity()
        {
            // Arrange
            // Arrange
            var description = _faker.Lorem.Sentence(50).Truncate(200);
            var entity = new AnswerOptionEntity(description, false);

            // Act
            var validated = entity.Validate();
            entity.SetCorrectAnswer();
            validated = entity.Validate();

            // Assert            
            DefaultShouldBe(validated, entity, description, true, true);
        }


        private void DefaultShouldBe(bool validated, AnswerOptionEntity entity, string description, bool isCorrect, bool IsActive)
        {
            Assert.True(validated);
            entity.Should().NotBeNull();
            entity.CreatedAt.Should().BeOnOrBefore(DateTime.UtcNow);            
            entity.Answer.Should().Be(description);
            entity.IsCorrectAnswer.Should().Be(isCorrect);
            entity.IsActive().Should().Be(IsActive);
        }
    }
}
