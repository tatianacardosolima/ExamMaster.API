namespace ExamMaster.Domain.TakingTest.Requests
{
    public class TestResultRequest
    {
        public Guid TestManagerId { get; set; }
        public Guid UserId { get; set; }
    }

    public class TestResultQuestionRequest
    {
        public Guid TestResultId { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
    }
}
