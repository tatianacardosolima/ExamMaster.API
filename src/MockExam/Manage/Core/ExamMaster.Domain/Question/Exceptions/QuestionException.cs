using Common.Shared.Exceptions;
using Common.Shared.Records;

namespace MockExam.Manage.Domain.Answers.Exceptions
{
    public class QuestionException : DomainException
    {
        public QuestionException(string code, string message) : base(code, message) { }

        public QuestionException(List<ErrorRecord> _errors) : base(_errors) { }

    }

    
}
