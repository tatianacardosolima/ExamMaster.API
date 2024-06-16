using ExamMaster.Shared.Abstractions;
using System.Diagnostics.CodeAnalysis;

namespace ExamMaster.Shared.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class EntityInactiveException(string code, string message) : DomainException(code, message)
    {
        public static void ThrowWhenIsInactive(EntityBase entity, string errorMessage)
        {
            if (!entity.IsActive())
            {
                throw new EntityInactiveException("",errorMessage);
            }
        }
    }
}
