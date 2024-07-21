using Common.Shared.Exceptions;
using Common.Shared.Records;

namespace MockExam.Manage.Domain.Answers.Exceptions
{
    public class AnswerOptionException : DomainException
    {
        public AnswerOptionException(string code, string message) : base(code, message) { }

        public AnswerOptionException(List<ErrorRecord> _errors) : base(_errors) { }

    }
}
