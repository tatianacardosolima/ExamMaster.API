using ExamMaster.Domain.TestManager.Entities;
using ExamMaster.Domain.TestManager.Requests;
using ExamMaster.Shared.Interfaces;
using ExamMaster.Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Domain.TestManager.Interfaces
{
    public interface IAnswerFactory
    {
        Task<AnswerOptionEntity> CreateAsync(AnswerRequest request);
    }

    public interface IAnswerRepository : IRepository<AnswerOptionEntity, int>
    {
    }

    public interface IAnswerService
    {
        Task<DefaultResponse> Update(QuestionRequest request);
    }
}
