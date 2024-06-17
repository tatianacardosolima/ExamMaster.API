using ExamMaster.Domain.Users.Entities;
using ExamMaster.Domain.Users.Exceptions;
using ExamMaster.Domain.Users.Interfaces;
using ExamMaster.Domain.Users.Requests;
using ExamMaster.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            var entity = new UserEntity(request.Name, request.Email, request.DateOfBirth);
            entity.Validate();

            return entity;
        }
    }
}
