using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Common.Shared.Exceptions;
using Common.Shared.Interfaces;
using Common.Shared.Responses;

namespace Common.Shared.Abstractions
{
    public class ServiceBase <TEntity, TRequest, 
                              TResponse, TId>
        where TId : struct
        where TEntity : EntityBase<TId>
        where TRequest : IRequest
        where TResponse: ResponseBase<TId>

    {
        protected readonly IRepository<TEntity, Guid> _repository;
        protected readonly IFactory<TRequest, TEntity, TId> _factory;

        public ServiceBase(IRepository<TEntity, Guid> repository,
            IFactory<TRequest, TEntity, TId> factory)
        {
            _repository = repository;
            _factory = factory;
        }

        public virtual async Task<DefaultResponse> InsertAsync(TRequest request)
        {

            var entity = await _factory.CreateAsync(request);
            
            await _repository.InsertAsync(entity);
            await _repository.SaveChangesAsync();
            
            return new DefaultResponse(true, "Registro Inserido com sucesso", new { Id = entity.Id});
        }

        public virtual async Task<DefaultResponse> UpdateAsync(TRequest request)
        {

            var entity = await _factory.CreateAsync(request);

            _repository.Update(entity);
            await _repository.SaveChangesAsync();

            return new DefaultResponse(true, "Registro Alterado com sucesso", new { Id = entity.Id });
        }

        public virtual async Task<DefaultResponse> DeleteAsync(Guid id)
        {

            TEntity entity = await _repository.GetByIdAsync(id);
            DomainException.ThrowWhen(entity == null, "Registro não encontrado");
            
            _repository.Delete(entity);
            await _repository.SaveChangesAsync();
            
            return new DefaultResponse(true, "Registro excluído");
        }

        public virtual async Task<DefaultResponse> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            NotFoundException.ThrowWhenNullEntity(entity, "Registro não encontrado");
            TResponse response = (TResponse)entity.GetResponse();
            return new DefaultResponse(true, "Registro encontrado", response);
        }
    }
}
