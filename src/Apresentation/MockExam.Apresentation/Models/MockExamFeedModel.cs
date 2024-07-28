namespace MockExam.Apresentation.Models
{
    public enum QuestionType
    {
        SingleOption,
        MultipleOption
    }

    public class MockExamFeedModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string KeyWord { get; set; }        


    }

    public class MockExamModel: MockExamFeedModel
    {
        public List<QuestionModel> Question { get; set; }
    }
    public class QuestionModel
    {
        public Guid Id { get; set; }
        public string Statement { get; set; }
        public QuestionType QuestionType { get; set; }

        public List<AnswerOptionModel> AnswersOptions { get; set; }
    }

    public class AnswerOptionModel
    {
        public Guid Id { get; set; }
        public string Answer { get; set ; }
        public bool IsCorrectAnswer { get; set; }
    }
}
