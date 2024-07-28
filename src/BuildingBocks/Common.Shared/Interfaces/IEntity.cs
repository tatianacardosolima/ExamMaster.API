using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common.Shared.Interfaces
{
    public interface IEntity<TId> where TId : struct
    {
        TId Id { get; }
        DateTime CreatedAt { get; }
        DateTime? ModifiedAt { get; }
    }
}
