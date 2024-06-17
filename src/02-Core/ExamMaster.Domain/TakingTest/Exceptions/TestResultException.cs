using ExamMaster.Domain.TestManager.Entities;
using ExamMaster.Shared.Exceptions;
using ExamMaster.Shared.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Domain.TakingTest.Exceptions
{
    public class TestResultException: DomainException
    {
        public TestResultException(string code, string message) : base(code, message) { }

        public TestResultException(List<ErrorRecord> _errors) : base(_errors) { }

        

    }

    public class TestResultQuestionException : DomainException
    {
        public TestResultQuestionException(string code, string message) : base(code, message) { }

        public TestResultQuestionException(List<ErrorRecord> _errors) : base(_errors) { }

    }

}
