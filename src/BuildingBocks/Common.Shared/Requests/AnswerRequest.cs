using Common.Shared.Interfaces;

namespace Common.Shared.Requests
{

    public class AnswerRequest
    {
        public string Answer { get; set; }
        public bool IsCorrect { get; set; }

    }

    public class UpdAnswerRequest: AnswerRequest, IRequest
    {
        public string Answer { get; set; }
        public bool IsCorrect { get; set; }

    }

}
