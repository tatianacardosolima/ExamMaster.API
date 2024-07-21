using Common.Shared.Exceptions;
using Common.Shared.Records;

namespace ExamMaster.Domain.Users.Exceptions
{


    public class UserException : DomainException
    {
        public UserException(string code, string message) : base(code, message) { }

        public UserException(List<ErrorRecord> _errors) : base(_errors) { }

        public static new void ThrowWhen(bool invalidRule, string code, string message)
        {
            if (invalidRule) throw new UserException(code, message);
        }


    }
}
