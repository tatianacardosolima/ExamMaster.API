using MockExam.Manage.Database.Write.Abstractions;
using MockExam.Manage.Database.Write.Context;
using MockExam.Manage.Domain.Answers.Interfaces;
using MockExam.Manage.Domain.Questions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockExam.Manage.Database.Write.Repositories
{
    public class QuestionRepository : RepositoryBase<QuestionEntity, long>, IQuestionRepository
    {
        public QuestionRepository(MockExamContext context) : base(context)
        {
        }
    }
}
