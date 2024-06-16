using ExamMaster.Shared.Exceptions;
using ExamMaster.Shared.Interfaces;
using ExamMaster.Shared.Records;
using FluentValidation;

namespace ExamMaster.Shared.Abstractions
{
    public abstract class EntityBase : IEntity         
    {
        protected EntityBase()
        {
            CreatedAt = DateTime.UtcNow;
            UniqueId = Guid.NewGuid();
        }
        public int Id { get; }
        public Guid UniqueId { get; }
        public DateTime CreatedAt { get; protected set; } = DateTime.Now;
        public DateTime? ModifiedAt { get; protected set; }
        public bool Active { get; protected set; } = true;

        protected List<ErrorRecord> _errors = new List<ErrorRecord>();
        public IReadOnlyCollection<ErrorRecord> Errors => _errors;

        public abstract bool Validate();
        /// <summary>
        /// Indicates whether an entity is active in the system.
        /// </summary>
        /// <returns>Returns true if the entity is active. Otherwise, it returns false.</returns>
        public bool IsActive()
        {
            return Active;
        }

        /// <summary>
        /// Inactivates an entity if it is active in the system.
        /// </summary>
        /// <exception cref="EntityInactiveException">The entity has already been inactivated.</exception>
        public void Inactivate()
        {
            EntityInactiveException.ThrowWhenIsInactive(this, "The entity has already been inactivated.");
            Active = false;
            ModifiedAt = DateTime.UtcNow;
        }
    }
}
