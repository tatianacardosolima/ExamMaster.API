using ExamMaster.Domain.TakingTest.Entities;
using ExamMaster.Domain.TakingTest.Requests;

namespace ExamMaster.Domain.TakingTest.Interfaces
{
    public interface ITestResultFactory
    {
        Task<TakeExamEntity> CreateAsync(TestResultRequest request);
    }

   
   
}
