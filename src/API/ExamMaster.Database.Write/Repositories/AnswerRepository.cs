using MockExam.Manage.Database.Write.Abstractions;
using MockExam.Manage.Database.Write.Context;
using MockExam.Manage.Domain.Answers.Entities;
using MockExam.Manage.Domain.Answers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockExam.Manage.Database.Write.Repositories
{
    public class AnswerRepository : RepositoryBase<AnswerOptionEntity, long>, IAnswerRepository
    {
        public AnswerRepository(MockExamContext context) : base(context)
        {
        }
    }
}
