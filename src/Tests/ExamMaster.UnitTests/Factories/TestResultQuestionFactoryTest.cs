using Bogus;
using FluentAssertions;
using Moq;

namespace ExamMaster.UnitTests.Factories
{
    public class TestResultQuestionFactoryTest
    {
        //private readonly Faker _faker = new("pt_BR");
        //[Fact]
        //[Trait("Action", "TestResultQuestionAsync")]
        //public async Task CreateAsync_TestResultQuestion_ShouldCreate()
        //{
        //    var request = Get();
        //    TestResultQuestionFactory factory = new(
        //        GetTestResultQuestionRepository(request.TestResultId).Object,
        //        GetQuestionRepository(request.QuestionId).Object, 
        //        GetAnswerRepository(request.AnswerId).Object);

        //    var entity = await factory.CreateAsync(request);

        //    entity.Should().NotBeNull();
        //    entity.TestResult.Should().NotBeNull();
        //    entity.Question.Should().NotBeNull();
        //    entity.Answer.Should().NotBeNull();
        //    entity.IsActive().Should().BeTrue();
        //    entity.CreatedAt.Should().BeOnOrBefore(DateTime.UtcNow);

        //}


        //private TestResultQuestionRequest Get()
        //{
        //    return new TestResultQuestionRequest()
        //    {
        //        AnswerId = 1,
        //        QuestionId = 2,
        //        TestResultId = Guid.NewGuid()                
        //    };
        //}

        //private Mock<IQuestionRepository> GetQuestionRepository(int id)
        //{
        //    Mock<IQuestionRepository> repository = new();
        //    repository.Setup(c => c.GetByIdAsync(id)).ReturnsAsync(
        //            new QuestionEntity(_faker.Lorem.Sentence(10).Truncate(200), QuestionType.SingleOption));
        //    return repository;
        //}

        //private Mock<ITestResultRepository> GetTestResultQuestionRepository(Guid uniqueId)
        //{
        //    Mock<ITestResultRepository> repository = new();
        //    repository.Setup(c => c.GetByUniqueIdAsync(uniqueId)).ReturnsAsync(
        //            new TestResultEntity());
        //    return repository;
        //}
        //private Mock<IAnswerRepository> GetAnswerRepository(int id)
        //{
        //    Mock<IAnswerRepository> repository = new();
        //    repository.Setup(c => c.GetByIdAsync(id)).ReturnsAsync(
        //            new AnswerOptionEntity());
        //    return repository;
        //}

    }
}
