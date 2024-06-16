using ExamMaster.Domain.TestManager.Exceptions;
using ExamMaster.Shared.Abstractions;
using ExamMaster.Shared.Extensions;
using ExamMaster.Shared.Records;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ExamMaster.Domain.TestManager.Entities.TestManagerEntity;

namespace ExamMaster.Domain.TestManager.Entities
{
    public class TestManagerEntity : EntityBase
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public EffectivePeriodValueObject EffectivePeriod { get; private set; }

        public IEnumerable<QuestionEntity> Questions { get; private set; }

        public TestManagerEntity()
        {
            Questions = new List<QuestionEntity>();
        }
        public TestManagerEntity(string title, string description, EffectivePeriodValueObject effectivePeriod)
        {
            Title = title;
            Description = description;
            EffectivePeriod = effectivePeriod;
            Questions = new List<QuestionEntity>();
        }
        public void ChangeTitleAndDescription(string newTitle, string newDescription)
        {
            if (Title.HasBeenChanged(newTitle) || Description.HasBeenChanged(newDescription))
                ModifiedAt = DateTime.Now;

            if (Title.HasBeenChanged(newTitle)) 
                Title = newTitle;
            if (Description.HasBeenChanged(newDescription))
                Description = newDescription;

            
        }

        public void ChangeEffectivePeriod(EffectivePeriodValueObject effectivePeriod)
        {
            DateTime endDate = EffectivePeriod.EndDate.GetValueOrDefault();

            if (EffectivePeriod.StartDate.HasBeenChanged(effectivePeriod.StartDate)
                || endDate.HasBeenChanged(effectivePeriod.EndDate.GetValueOrDefault()))
            {
                ModifiedAt = DateTime.Now;
                EffectivePeriod = effectivePeriod;
            }
            


        }

        public override bool Validate()
        {            
            var validator = new TestManagerValidator();
            var validation = validator.Validate(this);
            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                    _errors.Add(new ErrorRecord(error.ErrorCode,error.ErrorMessage));
                throw new TestManagerException(_errors);
            }
            return true;

        }


        private class TestManagerValidator : AbstractValidator<TestManagerEntity>
        {

            public TestManagerValidator()
            {
                
                RuleFor(x => x.Title).NotEmpty().WithErrorCode("ERROR_TESTMANAGER_TITLE_001");

                RuleFor(x => x.Title).MaximumLength(200).WithErrorCode("ERROR_TESTMANAGER_TITLE_002");

                RuleFor(x => x.Description).NotEmpty().WithErrorCode("ERROR_TESTMANAGER_DESCRIPTION_003");

                RuleFor(x => x.Description).MaximumLength(500).WithErrorCode("ERROR_TESTMANAGER_DESCRIPTION_004");

            }

        }

    }
}
