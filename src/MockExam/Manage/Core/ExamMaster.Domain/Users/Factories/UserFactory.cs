using ExamMaster.Domain.Users.Entities;
using ExamMaster.Domain.Users.Exceptions;
using ExamMaster.Domain.Users.Interfaces;
using ExamMaster.Domain.Users.Requests;

namespace ExamMaster.Domain.Users.Factories
{
    public class UserFactory : IUserFactory
    {
        private readonly IUserRepository _repository;

        public UserFactory(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<UserEntity> CreateAsync(UserRequest request)
        {
            bool exists = await _repository.ExistsAsync(x => x.Email.Equals(request.Email));
            UserException.ThrowWhen(exists, "ERROR_USERFACTORY_001", "E-mail já cadastrado no sistema");

            var entity = new UserEntity(request.Name, request.Email, request.DateOfBirth, request.Password);
            entity.Validate();

            return entity;
        }
    }
}
