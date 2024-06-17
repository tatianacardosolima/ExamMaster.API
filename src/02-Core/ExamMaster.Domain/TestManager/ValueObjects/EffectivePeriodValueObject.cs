using ExamMaster.Domain.TestManager.Exceptions;

namespace ExamMaster.Domain.TestManager.ValueObjects
{
    public record EffectivePeriodValueObject
    {
        public EffectivePeriodValueObject()
        {
        }
        public EffectivePeriodValueObject(DateTime startDate, DateTime? endDate)
        {
            EffectivePeriodException.ThrowIfStartDateGreaterThanEndDate(startDate, endDate);
            StartDate = startDate;
            EndDate = endDate;
        }

        public DateTime StartDate { get; init; }
        public DateTime? EndDate { get; init; }
    }
}
