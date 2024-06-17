using AutoMapper;
using ExamMaster.Domain.TestManager.Entities;
using ExamMaster.Domain.TestManager.Exceptions;
using ExamMaster.Domain.TestManager.Interfaces;
using ExamMaster.Domain.TestManager.Requests;
using ExamMaster.Shared.Exceptions;
using ExamMaster.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Domain.TestManager.Factories
{
    public class AnswerFactory : IAnswerFactory
    {
        //private readonly IMapper _mapper;
        private readonly IAnswerRepository _repository;

        public AnswerFactory(/*IMapper mapper,*/ IAnswerRepository repository)
        {
            //_mapper = mapper;
            _repository = repository;
        }
        public async Task<AnswerOptionEntity> CreateAsync(AnswerRequest request)
        {
            //var entity = _mapper.Map<TestManagerEntity>(request);

            var entity = new AnswerOptionEntity(request.Answer, request.IsCorrect);
            entity.Validate();

            var exist = await _repository.ExistsAsync(x => x.Answer.Equals(request.Answer));

            TestManagerException.ThrowWhen(exist, "ERROR_ANSWER_FACTORY_001", "Já existe uma resposta com o mesmo enunciado");

            return entity;


        }
    }
}
