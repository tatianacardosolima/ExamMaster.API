using ExamMaster.Shared.Exceptions;
using ExamMaster.Shared.Interfaces;
using ExamMaster.Shared.Records;
using FluentValidation;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ExamMaster.Shared.Abstractions
{
    public abstract class EntityBase : IEntity, INotifyPropertyChanged
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

        private readonly Dictionary<string, object> _propertyValues = new Dictionary<string, object>();


        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(T value, [CallerMemberName] string propertyName = null)
        {
            if (_propertyValues.TryGetValue(propertyName, out var existingValue) && EqualityComparer<T>.Default.Equals((T)existingValue, value))
            {
                return false;
            }

            _propertyValues[propertyName] = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected T? GetProperty<T>([CallerMemberName] string propertyName = null)
        {
            _propertyValues.TryGetValue(propertyName, out var value);
            return value == null ? default : (T)value;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            // Atualize a propriedade Modified sempre que outra propriedade mudar
            if (propertyName != nameof(ModifiedAt))
            {
                ModifiedAt = DateTime.Now;
            }
        }
    }
}
