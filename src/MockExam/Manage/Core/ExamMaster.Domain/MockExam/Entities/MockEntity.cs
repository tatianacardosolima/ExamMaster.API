using Common.Shared.Abstractions;
using Common.Shared.Extensions.ExamMaster.Shared.Extensions;
using Common.Shared.Records;
using Common.Shared.ValueObjects;
using FluentValidation;
using MockExam.Manage.Domain.Answers.Exceptions;

namespace MockExam.Manage.Domain.Answers.Entities
{
    public class MockEntity : EntityBase<Guid>
    {
        public string Title { get => GetProperty<string>(); private set => SetProperty(value); }
        public string Description { get => GetProperty<string>(); private set => SetProperty(value); }
        public EffectivePeriodValueObject EffectivePeriod { get => GetProperty<EffectivePeriodValueObject>(); private set => SetProperty(value); }

        public List<QuestionEntity> Questions { get => GetProperty<List<QuestionEntity>>(); private set => SetProperty(value); }

        public MockEntity()
        {
            Questions = new List<QuestionEntity>();
        }
        public MockEntity(string title, string description, EffectivePeriodValueObject effectivePeriod)
        {
            Title = title;
            Description = description;
            EffectivePeriod = effectivePeriod;
            Questions = new List<QuestionEntity>();
        }

        public void AddQuestions(QuestionEntity question)
        {
            if (Questions == null) { Questions = new List<QuestionEntity>(); }
            Questions.Add(question);
        }
        public void ChangeTitleAndDescription(string newTitle, string newDescription)
        {
            Title = newTitle;
            Description = newDescription;
        }

        public void ChangeEffectivePeriod(EffectivePeriodValueObject effectivePeriod)
        {
            DateTime endDate = EffectivePeriod.EndDate.GetValueOrDefault();

            if (EffectivePeriod.StartDate.HasBeenChanged(effectivePeriod.StartDate)
                || endDate.HasBeenChanged(effectivePeriod.EndDate.GetValueOrDefault()))
            {

                EffectivePeriod = effectivePeriod;
            }
        }

        public override bool Validate()
        {
            var validator = new MockEntityValidator();
            var validation = validator.Validate(this);
            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                    _errors.Add(new ErrorRecord(error.ErrorCode, error.ErrorMessage));
                throw new MockException(_errors);
            }
            return true;

        }

        public override ResponseBase<Guid> GetResponse()
        {
            throw new NotImplementedException();
        }

        private class MockEntityValidator : AbstractValidator<MockEntity>
        {

            public MockEntityValidator()
            {

                RuleFor(x => x.Title).NotEmpty().WithErrorCode("ERROR_TESTMANAGER_TITLE_001");

                RuleFor(x => x.Title).MaximumLength(200).WithErrorCode("ERROR_TESTMANAGER_TITLE_002");

                RuleFor(x => x.Description).MaximumLength(500).WithErrorCode("ERROR_TESTMANAGER_DESCRIPTION_003");

            }

        }

    }
}
