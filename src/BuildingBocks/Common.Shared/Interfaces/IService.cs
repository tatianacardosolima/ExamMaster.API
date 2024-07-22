using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Shared.Abstractions;
using Common.Shared.Responses;

namespace Common.Shared.Interfaces
{
    public interface IService<TEntity, TRequest,
                              TResponse, TId>
        where TEntity : EntityBase<TId>
        where TRequest : IRequest
        where TResponse : ResponseBase<TId>
        where TId: struct
    {
        Task<DefaultResponse> InsertAsync(TRequest request);
        Task<DefaultResponse> DeleteAsync(TId id);
        Task<DefaultResponse> UpdateAsync(TRequest request);
        Task<DefaultResponse> GetByIdAsync(TId id);
    }
}
