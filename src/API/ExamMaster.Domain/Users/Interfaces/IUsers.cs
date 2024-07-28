using Common.Shared.Interfaces;
using Common.Shared.Responses;
using ExamMaster.Domain.Users.Entities;
using ExamMaster.Domain.Users.Requests;

namespace ExamMaster.Domain.Users.Interfaces
{
    public interface IUserFactory
    {
        Task<UserEntity> CreateAsync(UserRequest request);
    }

    public interface IUserRepository : IRepository<UserEntity, Guid>
    {
        Task<UserEntity> GetByUniqueIdAsync(Guid testManagerId);
    }

    public interface IUserService
    {
        Task<DefaultResponse> Insert(UserRequest request);
        Task<DefaultResponse> UpdateAsync(UpdUserRequest request);
        Task<DefaultResponse> ChangeNameAsync(UpdUserRequest request);
        Task<DefaultResponse> ChangeEmailAsync(UpdUserRequest request);
        Task<DefaultResponse> GetById(Guid uniqueId);


    }
}
