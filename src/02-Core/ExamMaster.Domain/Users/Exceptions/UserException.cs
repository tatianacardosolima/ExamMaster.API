using ExamMaster.Shared.Exceptions;
using ExamMaster.Shared.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
