using Common.Shared.Exceptions;

namespace Common.Shared.ValueObjects
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
        public EffectivePeriodValueObject(DateTime startDate)
        {
            EffectivePeriodException.ThrowIfStartDateGreaterThanEndDate(startDate, null);
            StartDate = startDate;
        }
        public DateTime StartDate { get; init; }
        public DateTime? EndDate { get; init; }
    }
}
