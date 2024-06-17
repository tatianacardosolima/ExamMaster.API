using ExamMaster.Domain.TakingTest.Entities;
using ExamMaster.Domain.TakingTest.Requests;
using ExamMaster.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Domain.Users.Interfaces
{
    public interface IUserFactory
    {
        Task<UserEntity> CreateAsync();
    }

    public interface IUserRepository : IRepository<UserEntity, int>
    {
        Task<UserEntity> GetByUniqueIdAsync(Guid testManagerId);
    }
}
