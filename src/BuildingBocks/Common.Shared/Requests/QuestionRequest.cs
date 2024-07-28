using Common.Shared.Enums;
using Common.Shared.Interfaces;

namespace Common.Shared.Records.Requests
{
    public class QuestionRequest: IRequest
    {
        public Guid MockId { get; set; }
        public string Statement { get; set; }
        public QuestionType QuestionType { get; set; }

        public List<AnswerRequest> Answers { get; set; }

    }
    public class UpdQuestionRequest : QuestionRequest, IRequest
    {
        public Guid Id { get; set; }

    }

}
