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
    public interface ITestManagerFactory
    {
        Task<TestManagerEntity> CreateAsync(TestManagerRequest request);
    }

    public interface ITestManagerRepository : IRepository<TestManagerEntity, int>
    {
        Task<TestManagerEntity> GetByUniqueIdAsync(Guid testManagerId);
    }

    public interface ITestManagerFacade  
    {
        Task<DefaultResponse> CreateAsync(TestManagerRequest request);
    }
}
