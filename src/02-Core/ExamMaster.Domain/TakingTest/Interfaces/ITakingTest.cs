using ExamMaster.Domain.TakingTest.Entities;
using ExamMaster.Domain.TakingTest.Requests;
using ExamMaster.Domain.TestManager.Entities;
using ExamMaster.Domain.TestManager.Requests;
using ExamMaster.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Domain.TakingTest.Interfaces
{
    public interface ITestResultFactory
    {
        Task<TestResultEntity> CreateAsync(TestResultRequest request);
    }

    public interface ITestResultQuestionFactory
    {
        Task<TestResultQuestionEntity> CreateAsync(TestResultQuestionRequest requests);
    }

    public interface ITestResultRepository : IRepository<TestResultEntity, int>
    {
        Task<TestResultEntity> GetByUniqueIdAsync(Guid testResultId);
    }

    public interface ITestResultQuestionRepository : IRepository<TestResultQuestionEntity, int>
    {
        
    }
}
