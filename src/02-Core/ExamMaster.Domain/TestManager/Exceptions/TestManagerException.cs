using ExamMaster.Shared.Exceptions;
using ExamMaster.Shared.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Domain.TestManager.Exceptions
{
    public class TestManagerException: DomainException
    {
        public TestManagerException(string code, string message) : base(code, message) { }

        public TestManagerException(List<ErrorRecord> _errors) : base(_errors) { }

    }
}
