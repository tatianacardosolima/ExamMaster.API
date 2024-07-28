using Common.Shared.Abstractions;
using Common.Shared.Interfaces;
using Common.Shared.Records.Requests;
using Common.Shared.Requests;
using Common.Shared.Responses;
using MockExam.Manage.Domain.Answers.Entities;
using MockExam.Manage.Domain.Answers.Interfaces;
using MockExam.Manage.Domain.Question.Response;
using MockExam.Manage.Domain.Questions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockExam.Manage.Domain.Answers.Services
{
    public class AnswerService : ServiceBase<AnswerOptionEntity,
            UpdAnswerRequest, AnswerResponse, long>, IAnswerService
    {
        public AnswerService(IAnswerRepository repository, 
                        IAnswerFactory factory) 
                            : base(repository, factory)
        {
        }
    }
}
