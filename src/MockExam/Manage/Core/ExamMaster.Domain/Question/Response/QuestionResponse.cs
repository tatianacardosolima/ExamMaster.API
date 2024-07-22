using Common.Shared.Abstractions;
using MockExam.Manage.Domain.Questions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockExam.Manage.Domain.Question.Response
{
    public class QuestionResponse: ResponseBase<long>
    {
        public Guid Id { get; set; }
        public string Statement { get; set; }

        public QuestionType QuestionType{ get; set; }

    }
}
