using ExamMaster.Domain.TestManager.Exceptions;
using ExamMaster.Shared.Abstractions;
using ExamMaster.Shared.Records;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Domain.TestManager.Entities
{
    public class AnswerOptionEntity: EntityBase
    {
        public AnswerOptionEntity() { }

        public AnswerOptionEntity(string description, bool isCorrectAnswer)
        {
            Description = description;
            IsCorrectAnswer = isCorrectAnswer;
        }

        public string Description { get => GetProperty<String>(); private set => SetProperty(value); }
        public bool IsCorrectAnswer { get; private set; }

        public void ChangeDescription(string newDescription)
        { 
            Description = newDescription;
        }

        public void SetIncorrectAnswer()
        {
            IsCorrectAnswer = false;
        }

        public void SetCorrectAnswer()
        {
            IsCorrectAnswer = true;
        }

        public override bool Validate()
        {
            var validator = new AnswerOptionValidator();
            var validation = validator.Validate(this);
            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                    _errors.Add(new ErrorRecord(error.ErrorCode, error.ErrorMessage));
                throw new AnswerOptionException(_errors);
            }
            return true;

        }


        private class AnswerOptionValidator : AbstractValidator<AnswerOptionEntity>
        {

            public AnswerOptionValidator()
            {

                RuleFor(x => x.Description).NotEmpty().WithErrorCode("ERROR_ANSWEROPTION_DESCRIPTION_001");

                RuleFor(x => x.Description).MaximumLength(200).WithErrorCode("ERROR_ANSWEROPTION_DESCRIPTION_002");

                RuleFor(x => x.IsCorrectAnswer).NotNull().WithErrorCode("ERROR_ANSWEROPTION_DESCRIPTION_003");

            }

        }
    }
}
