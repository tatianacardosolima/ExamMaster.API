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
    public class QuestionFactory : IQuestionFactory
    {
        //private readonly IMapper _mapper;
        private readonly IQuestionRepository _repository;

        public QuestionFactory(/*IMapper mapper,*/ IQuestionRepository repository)
        {
            //_mapper = mapper;
            _repository = repository;
        }
        public async Task<QuestionEntity> CreateAsync(QuestionRequest request)
        {
            //var entity = _mapper.Map<TestManagerEntity>(request);

            var entity = new QuestionEntity(request.QuestionPrompt, request.QuestionType);
            entity.Validate();

            var exist = await _repository.ExistsAsync(x => x.QuestionPrompt.Equals(request.QuestionPrompt));

            TestManagerException.ThrowWhen(exist, "ERROR_QUESTION_FACTORY_001", "Já existe uma questão com o mesmo enunciado");

            return entity;


        }
    }
}
