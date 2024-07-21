using Common.Shared.Abstractions;
using Common.Shared.Records;
using FluentValidation;
using MockExam.Manage.Domain.Answers.Exceptions;
using MockExam.Manage.Domain.Questions.Entities;

namespace MockExam.Manage.Domain.Answers.Entities
{
    public class AnswerOptionEntity : EntityBase<long>
    {
        public AnswerOptionEntity() { }

        public AnswerOptionEntity(string description, bool isCorrectAnswer)
        {
            Answer = description;
            IsCorrectAnswer = isCorrectAnswer;
        }

        public string Answer { get => GetProperty<string>(); private set => SetProperty(value); }
        public bool IsCorrectAnswer { get; private set; }
        public QuestionEntity Question { get; set; }

        public void ChangeDescription(string newDescription)
        {
            Answer = newDescription;
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

        public override ResponseBase<long> GetResponse()
        {
            throw new NotImplementedException();
        }

        private class AnswerOptionValidator : AbstractValidator<AnswerOptionEntity>
        {

            public AnswerOptionValidator()
            {

                RuleFor(x => x.Answer).NotEmpty().WithErrorCode("ERROR_ANSWEROPTION_DESCRIPTION_001");

                RuleFor(x => x.Answer).MaximumLength(300).WithErrorCode("ERROR_ANSWEROPTION_DESCRIPTION_002");


            }

        }
    }
}
