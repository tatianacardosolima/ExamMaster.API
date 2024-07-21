using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Shared.Abstractions;

namespace Common.Shared.Interfaces
{
    public interface IFactory<TRequest, TEntity, TId> 
            
            where TRequest: IRequest 
            where TEntity : EntityBase<TId>
            where TId : struct

    {
        Task<TEntity> CreateAsync(TRequest request);
    }
}
