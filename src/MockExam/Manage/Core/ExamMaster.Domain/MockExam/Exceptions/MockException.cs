using Common.Shared.Exceptions;
using Common.Shared.Records;

namespace MockExam.Manage.Domain.Answers.Exceptions
{
    public class MockException : DomainException
    {
        public MockException(string code, string message) : base(code, message) { }

        public MockException(List<ErrorRecord> _errors) : base(_errors) { }

    }
   
}
