using Common.Shared.Abstractions;
using Common.Shared.Records;
using FluentValidation;
using MockExam.Manage.Domain.Answers.Entities;
using MockExam.Manage.Domain.Answers.Exceptions;
using MockExam.Manage.Domain.Mocks.Entities;

namespace MockExam.Manage.Domain.Questions.Entities
{
    public enum QuestionType
    {
        SingleOption,
        MultipleOption
    }
    public class QuestionEntity : EntityBase<long>
    {

        public MockEntity Mock { get => GetProperty<MockEntity>(); private set => SetProperty(value); }
        public string QuestionPrompt { get => GetProperty<string>(); private set => SetProperty(value); }
        public QuestionType QuestionType { get => GetProperty<QuestionType>(); private set => SetProperty(value); }

        public List<AnswerOptionEntity> Answers { get => GetProperty<List<AnswerOptionEntity>>(); private set => SetProperty(value); }

        public QuestionEntity()
        {
            Answers = new List<AnswerOptionEntity>();
        }

        public QuestionEntity(string prompt, QuestionType type)
        {
            QuestionPrompt = prompt;
            QuestionType = type;
            Answers = new List<AnswerOptionEntity>();
        }

        public void ChangePrompt(string newPrompt)
        {
            QuestionPrompt = newPrompt;
        }

        public void ChangeType(QuestionType type)
        {
            QuestionType = type;
        }

        public void AddAnswer(AnswerOptionEntity answer)
        {
            if (Answers == null) Answers = new List<AnswerOptionEntity>();
            Answers.Add(answer);
        }

        public override bool Validate()
        {
            var validator = new QuestionEntityValidator();
            var validation = validator.Validate(this);
            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                    _errors.Add(new ErrorRecord(error.ErrorCode, error.ErrorMessage));
                throw new QuestionException(_errors);
            }
            return true;

        }

        public override ResponseBase<long> GetResponse()
        {
            throw new NotImplementedException();
        }

        private class QuestionEntityValidator : AbstractValidator<QuestionEntity>
        {

            public QuestionEntityValidator()
            {

                RuleFor(x => x.QuestionPrompt).NotEmpty().WithErrorCode("ERROR_QUESTION_PROMPT_001");

                RuleFor(x => x.QuestionPrompt).MaximumLength(300).WithErrorCode("ERROR_QUESTION_PROMPT_002");

                RuleFor(x => x.QuestionType).NotNull().WithErrorCode("ERROR_QUESTION_TYPE_003");

            }

        }
    }
}
