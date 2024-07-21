using Common.Shared.ValueObjects;
using MockExam.Manage.Domain.Answers.Entities;
using MockExam.Manage.Domain.Answers.Exceptions;
using MockExam.Manage.Domain.Answers.Interfaces;
using MockExam.Manage.Domain.Answers.Requests;

namespace MockExam.Manage.Domain.Answers.Factories
{
    public class MockFactory : IMockFactory
    {
        //private readonly IMapper _mapper;
        private readonly ITestManagerRepository _repository;

        public MockFactory(/*IMapper mapper,*/ ITestManagerRepository repository)
        {
            //_mapper = mapper;
            _repository = repository;
        }
        public async Task<MockEntity> CreateAsync(MockRequest request)
        {
            //var entity = _mapper.Map<TestManagerEntity>(request);

            var entity = new MockEntity(request.Title, request.Description,
                new EffectivePeriodValueObject(request.EffectivePeriod.StartDate,
                                                            request.EffectivePeriod.EndDate));
            entity.Validate();

            var exist = await _repository.ExistsAsync(x => x.Title.Equals(request.Title));

            MockException.ThrowWhen(exist, "ERROR_TESTMANAGER_FACTORY_001", "Já existe um teste com o mesmo título");

            return entity;


        }
    }
}
