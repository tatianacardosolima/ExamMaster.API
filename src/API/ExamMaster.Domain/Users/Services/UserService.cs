using Common.Shared.Responses;
using ExamMaster.Domain.Users.Exceptions;
using ExamMaster.Domain.Users.Interfaces;
using ExamMaster.Domain.Users.Requests;

namespace ExamMaster.Domain.Users.Services
{
    internal class UserService : IUserService
    {
        private readonly IUserFactory _factory;
        private readonly IUserRepository _repository;

        public UserService(IUserFactory factory, IUserRepository repository)
        {
            _factory = factory;
            _repository = repository;
        }
        public async Task<DefaultResponse> ChangeEmailAsync(UpdUserRequest request)
        {
            var entity = await _repository.GetByUniqueIdAsync(request.Id);
            UserException.ThrowWhen(entity == null, "ERROR_USERSERVICE_001", "Usuário não encontrado.");
            entity.ChangeEmail(request.Email);
            entity.Validate();
            await _repository.SaveChangesAsync();
            return new DefaultResponse(true, "Email alterado com sucesso");
        }

        public async Task<DefaultResponse> ChangeNameAsync(UpdUserRequest request)
        {
            var entity = await _repository.GetByUniqueIdAsync(request.Id);
            UserException.ThrowWhen(entity == null, "ERROR_USERSERVICE_001", "Usuário não encontrado.");
            entity.ChangeName(request.Name);
            entity.Validate();
            await _repository.SaveChangesAsync();
            return new DefaultResponse(true, "Nome alterado com sucesso");
        }

        public Task<DefaultResponse> GetById(Guid uniqueId)
        {
            throw new NotImplementedException();
        }

        public async Task<DefaultResponse> Insert(UserRequest request)
        {
            var entity = await _factory.CreateAsync(request);

            await _repository.InsertAsync(entity);
            await _repository.SaveChangesAsync();

            return new DefaultResponse(true, "Usuário inserido com sucesso",
                new
                {
                    Id = entity.Id,
                });
        }

        public async Task<DefaultResponse> UpdateAsync(UpdUserRequest request)
        {
            var entity = await _repository.GetByUniqueIdAsync(request.Id);
            UserException.ThrowWhen(entity == null, "ERROR_USERSERVICE_001", "Usuário não encontrado.");
            entity.Change(request.Name, request.Email, request.DateOfBirth);
            entity.Validate();
            await _repository.SaveChangesAsync();
            return new DefaultResponse(true, "Nome alterado com sucesso");
        }
    }
}
