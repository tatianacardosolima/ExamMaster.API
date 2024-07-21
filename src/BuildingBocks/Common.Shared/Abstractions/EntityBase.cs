using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Common.Shared.Interfaces;
using Common.Shared.Records;

namespace Common.Shared.Abstractions
{
    public abstract class EntityBase<TId>: IEntity
        where TId : struct
    {
        public Guid Id { get; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime? ModifiedAt { get; protected set; }
        public Guid CreatedBy { get; protected set; }

        public bool Active { get; protected set; } = true;

        protected EntityBase()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            ModifiedAt = DateTime.UtcNow;
            Active = true;
        }

        public bool IsActive()
        {
            return Active;
        }
        public void Inactivate()
        {
            //EntityInactiveException.ThrowWhenIsInactive(this, "The entity has already been deleted");
            Active = false;
            ModifiedAt = DateTime.UtcNow;
        }

        public abstract ResponseBase<TId> GetResponse();

        [NotMapped]
        protected List<ErrorRecord> _errors = new List<ErrorRecord>();
        [NotMapped]
        public IReadOnlyCollection<ErrorRecord> Errors => _errors;
        public abstract bool Validate();

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
