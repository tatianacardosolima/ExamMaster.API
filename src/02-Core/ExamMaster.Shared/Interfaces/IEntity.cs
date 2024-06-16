using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Shared.Interfaces
{
    public interface IEntity
    {
        public int Id { get; }
        public Guid UniqueId { get; }
        DateTime CreatedAt { get; }
        DateTime? ModifiedAt { get; }
    }
}
