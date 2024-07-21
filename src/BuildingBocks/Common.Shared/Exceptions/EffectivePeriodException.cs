using Common.Shared.Exceptions;

namespace Common.Shared.Exceptions
{
    public class EffectivePeriodException(string code, string message) : DomainException(code, message)
    {
        public static void ThrowIfStartDateGreaterThanEndDate(DateTime startDate, DateTime? endDate)
        {
            if (endDate != null && startDate > endDate)
            {
                throw new EffectivePeriodException("", "Start Date is greater than end date.");
            }
        }
    }
}
