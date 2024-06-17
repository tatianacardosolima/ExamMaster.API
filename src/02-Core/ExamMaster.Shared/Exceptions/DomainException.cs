using ExamMaster.Shared.Records;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Shared.Exceptions
{
    public class DomainException : Exception
    {
        
        public IReadOnlyCollection<ErrorRecord> Errors;

        public DomainException(string code, string message) : base(message)
        {
            Code = code;            
        }

        public DomainException(List<ErrorRecord> _errors) : base(_errors.FirstOrDefault()?.Message)
        {
            Errors = _errors;            
            Code = _errors.ElementAt(0).Code;
            //Message = _errors.ElementAt(0).Message;
        }

        public string Code{ get; init; }
        public static void ThrowWhen(bool invalidRule, string code, string message)
        {
            if (invalidRule) throw new DomainException(code, message);
        }
        
        
    }
}
