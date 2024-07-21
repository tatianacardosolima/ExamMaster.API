using Common.Shared.ValueObjects;

namespace MockExam.Manage.Domain.Answers.Requests
{
    public class MockRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public EffectivePeriodValueObject EffectivePeriod { get; set; }

        public List<QuestionRequest> Questions { get; set; }
    }
}
