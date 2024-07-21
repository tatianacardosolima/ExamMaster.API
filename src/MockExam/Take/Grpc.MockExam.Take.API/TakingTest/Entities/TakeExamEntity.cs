using Common.Shared.Abstractions;
using Common.Shared.Records;
using Common.Shared.ValueObjects;
using ExamMaster.Domain.TakingTest.Exceptions;
using FluentValidation;

namespace ExamMaster.Domain.TakingTest.Entities
{
    public enum TestStatus
    {
        NotStarted,
        Incomplete,
        Completed
    }
    public class TakeExamEntity : EntityBase<Guid>
    {
        public TakeExamEntity()
        {            
        }

        public TakeExamEntity(Guid mockExamId, Guid createdBy)
        {
            MockExamId = mockExamId;
            CreatedBy = createdBy;
            TestStatus = TestStatus.NotStarted;
            EffectivePeriod = new EffectivePeriodValueObject(DateTime.UtcNow);
        }


        public Guid MockExamId { get => GetProperty<Guid>(); private set => SetProperty(value); }
        public int TestManagerId { get => GetProperty<int>(); private set => SetProperty(value); }

        public Guid UserId { get => GetProperty<Guid>(); private set => SetProperty(value); }
        
        public EffectivePeriodValueObject EffectivePeriod { get => GetProperty<EffectivePeriodValueObject>(); private set => SetProperty(value); }

        public TestStatus TestStatus { get => GetProperty<TestStatus>(); private set => SetProperty(value); }


        public void SetStatusIncomplete()
        { 
            TestStatus = TestStatus.Incomplete;
        }

        public void SetStatusComplete()
        {
            TestStatus = TestStatus.Completed;
        }

        public override bool Validate()
        {
            var validator = new TestResultValidator();
            var validation = validator.Validate(this);
            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                    _errors.Add(new ErrorRecord(error.ErrorCode, error.ErrorMessage));
                throw new TakeExamException(_errors);
            }
            return true;

        }

        public override ResponseBase<Guid> GetResponse()
        {
            throw new NotImplementedException();
        }

        private class TestResultValidator : AbstractValidator<TakeExamEntity>
        {

            public TestResultValidator()
            {

                RuleFor(x => x.MockExamId).NotEmpty().WithErrorCode("ERROR_TESTRESULT_TESTMANAGER_001");
                RuleFor(x => x.CreatedBy).NotEmpty().WithErrorCode("ERROR_TESTRESULT_USER_002");
                RuleFor(x => x.EffectivePeriod).NotEmpty().WithErrorCode("ERROR_TESTRESULT_EFFECTIVEPERIOD_003");               

            }

        }
    }
}
