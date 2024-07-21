using Common.Shared.ValueObjects;
using MockExam.Manage.Domain.Answers.Entities;
using MockExam.Manage.Domain.Answers.Exceptions;
using MockExam.Manage.Domain.Answers.Interfaces;
using MockExam.Manage.Domain.Answers.Requests;
using MockExam.Manage.Domain.Mocks.Entities;

namespace MockExam.Manage.Domain.Answers.Factories
{
    public class MockFactory : IMockFactory
    {
        //private readonly IMapper _mapper;
        private readonly IMockRepository _repository;

        public MockFactory(/*IMapper mapper,*/ IMockRepository repository)
        {
            //_mapper = mapper;
            _repository = repository;
        }
        public async Task<MockEntity> CreateAsync(MockRequest request)
        {
            
            var entity = new MockEntity(request.CreatedBy, request.Title, 
                request.Description, request.Access, request.KeyWord);

            entity.Validate();

            var exist = await _repository.ExistsAsync(x => x.Title.Equals(request.Title) && x.CreatedBy== request.CreatedBy);

            MockException.ThrowWhen(exist, "ERROR_MOCK_FACTORY_001", "Já existe um teste com o mesmo título");

            return entity;


        }
    }
}
