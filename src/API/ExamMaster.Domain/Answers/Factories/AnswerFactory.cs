using Common.Shared.Records.Requests;
using Common.Shared.Requests;
using MockExam.Manage.Domain.Answers.Entities;
using MockExam.Manage.Domain.Answers.Exceptions;
using MockExam.Manage.Domain.Answers.Interfaces;

namespace MockExam.Manage.Domain.Answers.Factories
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
        public async Task<AnswerOptionEntity> CreateAsync(UpdAnswerRequest request)
        {
            //var entity = _mapper.Map<TestManagerEntity>(request);

            var entity = new AnswerOptionEntity(request.Answer, request.IsCorrect);
            entity.Validate();

            var exist = await _repository.ExistsAsync(x => x.Answer.Equals(request.Answer));

            MockException.ThrowWhen(exist, "ERROR_ANSWER_FACTORY_001", "Já existe uma resposta com o mesmo enunciado");

            return entity;


        }
    }
}
