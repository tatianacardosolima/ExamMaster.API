using Bogus;
using ExamMaster.Domain.Users.Entities;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace ExamMaster.UnitTests.Entities
{
    public class TestResultTest
    {
        //private readonly Faker _faker = new("pt_BR");
        

        //[Fact]
        //[Trait("Action", "CreateTestResult")]
        //public void Create_CorretAnswer_ShouldConstructEntity()
        //{
        //    // Arrange
        //    var testManagerEntity = GetTestManager();
        //    var userEntity = GetUser();            
        //    var entity = new TestResultEntity(testManagerEntity, userEntity);

        //    // Act
        //    var validated = entity.Validate();

        //    // Assert            
        //    DefaultShouldBe(validated, entity, 
        //            testManagerEntity,
        //            TestStatus.NotStarted,
        //            userEntity,                     
        //            true);
        //}

        //[Fact]
        //[Trait("Action", "UpdateTestResult")]
        //public void Create_SetStatusIncomplete_ShouldConstructEntity()
        //{
        //    // Arrange
        //    var testManagerEntity = GetTestManager();
        //    var userEntity = GetUser();
        //    var entity = new TestResultEntity(testManagerEntity, userEntity);

        //    // Act
        //    var validated = entity.Validate();
        //    entity.SetStatusIncomplete();
                
        //    // Assert            
        //    DefaultShouldBe(validated, entity,
        //            testManagerEntity,
        //            TestStatus.Incomplete,
        //            userEntity,
        //            true);


        //}

        //[Fact]
        //[Trait("Action", "UpdateTestResult")]
        //public void Create_SetStatusComplete_ShouldConstructEntity()
        //{
        //    // Arrange
        //    var testManagerEntity = GetTestManager();
        //    var userEntity = GetUser();
        //    var entity = new TestResultEntity(testManagerEntity, userEntity);

        //    // Act
        //    var validated = entity.Validate();
        //    entity.SetStatusComplete();

        //    // Assert            
        //    DefaultShouldBe(validated, entity,
        //            testManagerEntity,
        //            TestStatus.Completed,
        //            userEntity,
        //            true);


        //}




        //private void DefaultShouldBe(bool validated, TestResultEntity entity, 
        //    TestManagerEntity testManagerEntity,
        //    TestStatus testStatus,
        //    UserEntity userEntity, bool IsActive)
        //{
        //    Assert.True(validated);
        //    entity.Should().NotBeNull();
        //    entity.CreatedAt.Should().BeOnOrBefore(DateTime.UtcNow);
        //    entity.TestManager.Should().Be(testManagerEntity);
        //    entity.User.Should().Be(userEntity);
        //    entity.TestStatus.Should().Be(testStatus);
        //    entity.IsActive().Should().Be(IsActive);
        //}

        //private TestManagerEntity GetTestManager()
        //{
        //    var title = _faker.Lorem.Sentence(50).Truncate(200);
        //    var description = _faker.Lorem.Sentence(50).Truncate(500);
        //    var effectivePeriod = new EffectivePeriodValueObject(DateTime.Now, DateTime.Now.AddDays(30));
        //    return new TestManagerEntity(title, description, effectivePeriod);

        //}

        //private UserEntity GetUser()
        //{
        //    return new UserEntity(_faker.Name.FullName(), _faker.Internet.Email());
        //}
    }
}
