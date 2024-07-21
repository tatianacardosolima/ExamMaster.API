using Common.Shared.Abstractions;
using Common.Shared.Extensions;
using Common.Shared.Records;
using ExamMaster.Domain.Users.Exceptions;
using FluentValidation;

namespace ExamMaster.Domain.Users.Entities
{
    public class UserEntity : EntityBase<Guid>
    {
        public string Name { get => GetProperty<string>(); private set => SetProperty(value); }
        public string Email { get => GetProperty<string>(); private set => SetProperty(value); }
        public string Password { get => GetProperty<string>(); private set => SetProperty(value); }
        public DateTime? DateOfBirth { get; private set; }

        
        public UserEntity(string name, string email, DateTime? dateOfBirth, string password)
        {
            Name = name;
            Email = email;
            DateOfBirth = dateOfBirth;
            Password = password;
        }

        public void Change(string name, string email, DateTime? dateOfBirth)
        {
            Name = name;
            Email = email;
            DateOfBirth = dateOfBirth;
        }

        public void ChangeName(string name)
        {
            Name = name;            
        }
        public void ChangeEmail(string email)
        {            
            Email = email;            
        }
        public void ChangeDateOfBirth(DateTime dateOfBirth)
        {            
            DateOfBirth = dateOfBirth;
            ModifiedAt = DateTime.UtcNow;
        }
        public UserEntity(string name, string email)
        {
            Name = name;
            Email = email;
            DateOfBirth = null;
        }

        public override bool Validate()
        {
            var validator = new UserValidator();
            var validation = validator.Validate(this);
            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                    _errors.Add(new ErrorRecord(
                        error.ErrorCode == null? error.ErrorMessage: error.ErrorCode
                        , error.ErrorMessage));
                throw new UserException(_errors);
            }
            return true;

        }

        public override ResponseBase<Guid> GetResponse()
        {
            throw new NotImplementedException();
        }

        private class UserValidator : AbstractValidator<UserEntity>
        {

            public UserValidator()
            {

                RuleFor(x => x.Name).NotEmpty().WithErrorCode("ERROR_USER_NAME_001");

                RuleFor(x => x.Name).MaximumLength(200).WithErrorCode("ERROR_USER_NAME_002");

                RuleFor(x => x.Email).NotEmpty().WithErrorCode("ERROR_USER_EMAIL_003");

                RuleFor(x => x.Email).MaximumLength(200).WithErrorCode("ERROR_USER_EMAIL_004");

                RuleFor(x => new { x.Email }).Custom((value, context) =>
                {
                    if (!value.Email.IsValidEmail())
                        context.AddFailure("ERROR_USER_EMAIL_005");
                    
                });

            }

        }
    }
}
