using ExamMaster.Domain.TestManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Domain.TestManager.Requests
{
    public class QuestionRequest
    {
        public string QuestionPrompt { get ;set ; }
        public QuestionType QuestionType { get; set; }

        public List<AnswerRequest> Answers{ get; set; }

    }
    public class AnswerRequest
    {
        public string Answer{ get; set; }
        public bool IsCorrect { get; set; }

    }

}
