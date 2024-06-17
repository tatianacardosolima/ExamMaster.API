using ExamMaster.Domain.TakingTest.Entities;
using ExamMaster.Domain.TestManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Domain.TakingTest.Requests
{
    public class TestResultRequest
    {
        public Guid TestManagerId { get; set; }
        public Guid UserId { get; set; }
    }

    public class TestResultQuestionRequest
    {
        public Guid TestResultId { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
    }
}
