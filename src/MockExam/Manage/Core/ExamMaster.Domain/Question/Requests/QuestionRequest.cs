using Common.Shared.Interfaces;
using MockExam.Manage.Domain.Questions.Entities;

namespace MockExam.Manage.Domain.Answers.Requests
{
    public class QuestionRequest: IRequest
    {
        public Guid MockId { get; set; }
        public string Statement { get; set; }
        public QuestionType QuestionType { get; set; }

        public List<AnswerRequest> Answers { get; set; }

    }    

}
