using MockExam.Manage.Domain.Answers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockExam.Manage.Domain.Answers.Requests
{
   
    public class AnswerRequest
    {
        public string Answer { get; set; }
        public bool IsCorrect { get; set; }

    }

}
