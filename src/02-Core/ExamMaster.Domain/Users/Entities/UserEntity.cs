using ExamMaster.Domain.TestManager.Entities;
using ExamMaster.Domain.TestManager.Exceptions;
using ExamMaster.Domain.Users.Exceptions;
using ExamMaster.Shared.Abstractions;
using ExamMaster.Shared.Extensions;
using ExamMaster.Shared.Records;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Domain.Users.Entities
{
    public class UserEntity : EntityBase
    {
        public string Name { get => GetProperty<string>(); private set => SetProperty(value); }
        public string Email { get => GetProperty<string>(); private set => SetProperty(value); }

        public DateTime? DateOfBirth { get; private set; }

        
        public UserEntity(string name, string email, DateTime dateOfBirth)
        {
            Name = name;
            Email = email;
            DateOfBirth = dateOfBirth;
        }

        public void Change(string name, string email, DateTime dateOfBirth)
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
                    _errors.Add(new ErrorRecord(error.ErrorCode, error.ErrorMessage));
                throw new UserException(_errors);
            }
            return true;

        }


        private class UserValidator : AbstractValidator<UserEntity>
        {

            public UserValidator()
            {

                RuleFor(x => x.Name).NotEmpty().WithErrorCode("ERROR_USER_NAME_001");

                RuleFor(x => x.Name).MaximumLength(200).WithErrorCode("ERROR_USER_NAME_002");

                RuleFor(x => x.Email).NotEmpty().WithErrorCode("ERROR_USER_EMAIL_003");

                RuleFor(x => x.Name).MaximumLength(200).WithErrorCode("ERROR_USER_EMAIL_004");

                RuleFor(x => new { x.Email }).Custom((value, context) =>
                {
                    if (!value.Email.IsValidEmail())
                        context.AddFailure("Email inválido.");
                    
                });

            }

        }
    }
}
