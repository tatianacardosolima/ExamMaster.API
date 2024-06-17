using ExamMaster.Domain.TakingTest.Exceptions;
using ExamMaster.Domain.TestManager.Entities;
using ExamMaster.Domain.TestManager.ValueObjects;
using ExamMaster.Domain.Users.Entities;
using ExamMaster.Shared.Abstractions;
using ExamMaster.Shared.Records;
using FluentValidation;

namespace ExamMaster.Domain.TakingTest.Entities
{
    public enum TestStatus
    {
        NotStarted,
        Incomplete,
        Completed
    }
    public class TestResultEntity : EntityBase
    {
        public TestResultEntity()
        {            
        }

        public TestResultEntity(TestManagerEntity testManager, UserEntity user)
        {
            TestManager = testManager;
            User = user;
            TestStatus = TestStatus.NotStarted;
            EffectivePeriod = new EffectivePeriodValueObject(DateTime.UtcNow);
        }


        public TestManagerEntity TestManager { get => GetProperty<TestManagerEntity>(); private set => SetProperty(value); }
        public int TestManagerId { get => GetProperty<int>(); private set => SetProperty(value); }

        public UserEntity User { get => GetProperty<UserEntity>(); private set => SetProperty(value); }
        public int UserId { get => GetProperty<int>(); private set => SetProperty(value); }
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
                throw new TestResultException(_errors);
            }
            return true;

        }

        private class TestResultValidator : AbstractValidator<TestResultEntity>
        {

            public TestResultValidator()
            {

                RuleFor(x => x.TestManager).NotEmpty().WithErrorCode("ERROR_TESTRESULT_TESTMANAGER_001");
                RuleFor(x => x.User).NotEmpty().WithErrorCode("ERROR_TESTRESULT_USER_002");
                RuleFor(x => x.EffectivePeriod).NotEmpty().WithErrorCode("ERROR_TESTRESULT_EFFECTIVEPERIOD_003");               

            }

        }
    }
}
