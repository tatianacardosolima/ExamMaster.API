using Bogus;
using Bogus.DataSets;
using ExamMaster.Domain.TestManager;
using ExamMaster.Domain.TestManager.Entities;
using ExamMaster.Domain.TestManager.Exceptions;
using ExamMaster.Shared.Extensions;
using FluentAssertions;

namespace ExamMaster.UnitTests.Entities
{
    
    public class QuestionTest
    {
        private readonly Faker _faker = new ("pt_BR");
        public QuestionTest() { 
        
        }

        [Fact]
        [Trait("Action", "CreateQuestion")]
        public void Create_SingleOption_ShouldConstructEntity()
        {            
            // Arrange
            var prompt = _faker.Lorem.Sentence(50).Truncate(200);
            var type = QuestionType.SingleOption;            
            var entity = new QuestionEntity(prompt, type);

            // Act
            var validated = entity.Validate();

            // Assert            
            DefaultShouldBe(validated, entity, prompt, QuestionType.SingleOption, true);            
        }

        [Fact]
        [Trait("Action", "CreateQuestion")]
        public void Create_MultipleOption_ShouldConstructEntity()
        {
            // Arrange
            var prompt = _faker.Lorem.Sentence(50).Truncate(200);
            var type = QuestionType.MultipleOption;
            var entity = new QuestionEntity(prompt, type);

            // Act
            var validated = entity.Validate();

            // Assert            
            DefaultShouldBe(validated, entity, prompt, QuestionType.MultipleOption, true);
            

        }

        [Fact]
        [Trait("Action", "CreateQuestion")]
        public void Create_WithAnsewrs_ShouldConstructEntity()
        {
            // Arrange
            var prompt = _faker.Lorem.Sentence(50).Truncate(200);
            var type = QuestionType.SingleOption;
            var entity = new QuestionEntity(prompt, type);
            entity.AddAnswer(new AnswerOptionEntity("Opção 1", true));
            entity.AddAnswer(new AnswerOptionEntity("Opção 2", false));
            entity.AddAnswer(new AnswerOptionEntity("Opção 3", false));
            // Act
            var validated = entity.Validate();

            // Assert            
            DefaultShouldBe(validated, entity, prompt, QuestionType.SingleOption, true);
            entity.Answers.Should().HaveCount(3);
            entity.Answers.Where(x => x.IsCorrectAnswer).Should().HaveCount(1);
            entity.Answers.Where(x => !x.IsCorrectAnswer).Should().HaveCount(2);
        }

        [Fact]
        [Trait("Action", "UpdateQuestion")]
        public void Update_Prompt_ShouldConstructEntity()
        {
            // Arrange
            var prompt = _faker.Lorem.Sentence(50).Truncate(200);
            var type = QuestionType.SingleOption;
            var entity = new QuestionEntity(prompt, type);            
            entity.AddAnswer(new AnswerOptionEntity("Opção 1", true));
            entity.AddAnswer(new AnswerOptionEntity("Opção 2", false));            

            var newprompt = _faker.Lorem.Sentence(50).Truncate(200);
                
            // Act
            var validated = entity.Validate();
            entity.ChangePrompt(newprompt);
            // Assert            
            DefaultShouldBe(validated, entity, newprompt, QuestionType.SingleOption, true);
            entity.Answers.Should().HaveCount(2);
        }

        [Fact]
        [Trait("Action", "UpdateQuestion")]
        public void Update_TypeFromSingleToMulti_ShouldConstructEntity()
        {
            // Arrange
            var prompt = _faker.Lorem.Sentence(50).Truncate(200);
            var type = QuestionType.SingleOption;
            var entity = new QuestionEntity(prompt, type);
            entity.AddAnswer(new AnswerOptionEntity("Opção 1", true));
            entity.AddAnswer(new AnswerOptionEntity("Opção 2", false));

            
            // Act
            var validated = entity.Validate();
            entity.ChangeType(QuestionType.MultipleOption);
            // Assert            
            DefaultShouldBe(validated, entity, prompt, QuestionType.MultipleOption, true);
            entity.Answers.Should().HaveCount(2);
            entity.ModifiedAt.Should().BeOnOrBefore(DateTime.UtcNow);
        }

        [Fact]
        [Trait("Action", "UpdateQuestion")]
        public void Update_TypeFromMulitToSingle_ShouldConstructEntity()
        {
            // Arrange
            var prompt = _faker.Lorem.Sentence(50).Truncate(200);
            var type = QuestionType.MultipleOption;
            var entity = new QuestionEntity(prompt, type);
            entity.AddAnswer(new AnswerOptionEntity("Opção 1", true));
            entity.AddAnswer(new AnswerOptionEntity("Opção 2", false));


            // Act
            var validated = entity.Validate();
            entity.ChangeType(QuestionType.SingleOption);
            validated = entity.Validate();
            // Assert            
            DefaultShouldBe(validated, entity, prompt, QuestionType.SingleOption, true);
            entity.Answers.Should().HaveCount(2);
            entity.ModifiedAt.Should().BeOnOrBefore(DateTime.UtcNow);
        }

        [Fact]
        [Trait("Action", "UpdateQuestion")]
        public void Update_Answers_ShouldConstructEntity()
        {
            // Arrange
            var prompt = _faker.Lorem.Sentence(50).Truncate(200);
            var type = QuestionType.MultipleOption;
            var entity = new QuestionEntity(prompt, type);
            entity.AddAnswer(new AnswerOptionEntity("Opção 1", true));
            entity.AddAnswer(new AnswerOptionEntity("Opção 2", false));


            // Act
            var validated = entity.Validate();
            entity.AddAnswer(new AnswerOptionEntity("Opção 3", true));
            validated = entity.Validate();

            // Assert            
            DefaultShouldBe(validated, entity, prompt, QuestionType.MultipleOption, true);
            entity.Answers.Should().HaveCount(3);
            entity.ModifiedAt.Should().BeOnOrBefore(DateTime.UtcNow);
            entity.Answers.Where(x => x.IsCorrectAnswer).Should().HaveCount(2);
            entity.Answers.Where(x => !x.IsCorrectAnswer).Should().HaveCount(1);
        }

        public void DefaultShouldBe(bool validated, QuestionEntity entity, string prompt, QuestionType type, bool IsActive)
        {
            Assert.True(validated);
            entity.Should().NotBeNull();
            entity.CreatedAt.Should().BeOnOrBefore(DateTime.UtcNow);            
            entity.QuestionPrompt.Should().Be(prompt);
            entity.QuestionType.Should().Be(type);
            entity.IsActive().Should().Be(IsActive);
        }
    }
}
