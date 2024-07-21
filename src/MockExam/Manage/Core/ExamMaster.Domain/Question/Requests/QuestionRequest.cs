using MockExam.Manage.Domain.Questions.Entities;

namespace MockExam.Manage.Domain.Answers.Requests
{
    public class QuestionRequest
    {
        public string QuestionPrompt { get; set; }
        public QuestionType QuestionType { get; set; }

        public List<AnswerRequest> Answers { get; set; }

    }    

}
