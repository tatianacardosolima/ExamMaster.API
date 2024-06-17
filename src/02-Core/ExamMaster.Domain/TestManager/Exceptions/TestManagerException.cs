using ExamMaster.Domain.TestManager.Entities;
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

    public class QuestionException : DomainException
    {
        public QuestionException(string code, string message) : base(code, message) { }

        public QuestionException(List<ErrorRecord> _errors) : base(_errors) { }

    }

    public class AnswerOptionException : DomainException
    {
        public AnswerOptionException(string code, string message) : base(code, message) { }

        public AnswerOptionException(List<ErrorRecord> _errors) : base(_errors) { }

    }
}
