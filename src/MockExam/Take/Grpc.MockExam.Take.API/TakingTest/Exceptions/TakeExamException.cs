using Common.Shared.Exceptions;
using Common.Shared.Records;

namespace ExamMaster.Domain.TakingTest.Exceptions
{
    public class TakeExamException: DomainException
    {
        public TakeExamException(string code, string message) : base(code, message) { }

        public TakeExamException(List<ErrorRecord> _errors) : base(_errors) { }

        public  static new void ThrowWhen(bool invalidRule, string code, string message)
        {
            if (invalidRule) throw new TakeExamException(code, message);
        }


    }

    public class TestResultQuestionException : DomainException
    {
        public TestResultQuestionException(string code, string message) : base(code, message) { }

        public TestResultQuestionException(List<ErrorRecord> _errors) : base(_errors) { }

    }

}
