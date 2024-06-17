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
    public interface IQuestionFactory
    {
        Task<QuestionEntity> CreateAsync(QuestionRequest request);
    }

    public interface IQuestionRepository: IRepository<QuestionEntity, int>
    {        
    }

    public interface IQuestionService  
    {
        Task<DefaultResponse> Update(QuestionRequest request);
    }
}
