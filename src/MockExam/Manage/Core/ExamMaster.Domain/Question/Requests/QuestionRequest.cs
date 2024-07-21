using MockExam.Manage.Domain.Answers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockExam.Manage.Domain.Answers.Requests
{
    public class QuestionRequest
    {
        public string QuestionPrompt { get; set; }
        public QuestionType QuestionType { get; set; }

        public List<AnswerRequest> Answers { get; set; }

    }    

}
