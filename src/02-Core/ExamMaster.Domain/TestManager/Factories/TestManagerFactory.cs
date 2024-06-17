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
    public class TestManagerFactory : ITestManagerFactory
    {
        //private readonly IMapper _mapper;
        private readonly ITestManagerRepository _repository;

        public TestManagerFactory(/*IMapper mapper,*/ ITestManagerRepository repository)
        {
            //_mapper = mapper;
            _repository = repository;
        }
        public async Task<TestManagerEntity> CreateAsync(TestManagerRequest request)
        {
            //var entity = _mapper.Map<TestManagerEntity>(request);

            var entity = new TestManagerEntity(request.Title, request.Description,
                new ValueObjects.EffectivePeriodValueObject(request.EffectivePeriod.StartDate,
                                                            request.EffectivePeriod.EndDate));
            entity.Validate();

            var exist = await _repository.ExistsAsync(x => x.Title.Equals(request.Title));

            TestManagerException.ThrowWhen(exist, "ERROR_TESTMANAGER_FACTORY_001", "Já existe um teste com o mesmo título");

            return entity;


        }
    }
}
