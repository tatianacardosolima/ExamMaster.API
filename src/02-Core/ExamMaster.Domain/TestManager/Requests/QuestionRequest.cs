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

    }
}
