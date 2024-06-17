using ExamMaster.Domain.TestManager.Exceptions;
using ExamMaster.Domain.TestManager.ValueObjects;
using ExamMaster.Shared.Abstractions;
using ExamMaster.Shared.Extensions;
using ExamMaster.Shared.Records;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XAct;
using static ExamMaster.Domain.TestManager.Entities.TestManagerEntity;

namespace ExamMaster.Domain.TestManager.Entities
{
    public class TestManagerEntity : EntityBase
    {
        public string Title { get => GetProperty<String>(); private set => SetProperty(value); }
        public string Description { get => GetProperty<String>(); private set => SetProperty(value); }
        public EffectivePeriodValueObject EffectivePeriod { get => GetProperty<EffectivePeriodValueObject>(); private set => SetProperty(value); }

        public List<QuestionEntity> Questions { get => GetProperty<List<QuestionEntity>>(); private set => SetProperty(value); }

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

                RuleFor(x => x.Description).MaximumLength(500).WithErrorCode("ERROR_TESTMANAGER_DESCRIPTION_003");

            }

        }

    }
}
