using MockExam.Manage.Domain.Answers.Entities;
using MockExam.Manage.Domain.Answers.Exceptions;
using MockExam.Manage.Domain.Answers.Interfaces;
using MockExam.Manage.Domain.Answers.Requests;
using MockExam.Manage.Domain.Questions.Entities;

namespace MockExam.Manage.Domain.Answers.Factories
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

            var entity = new QuestionEntity(request.Statement, request.QuestionType);
            entity.Validate();

            var exist = await _repository.ExistsAsync(x => x.Statement.Equals(request.Statement)
                    && x.Mock.Id == request.MockId);

            QuestionException.ThrowWhen(exist, "ERROR_QUESTION_FACTORY_001", "Já existe uma questão com o mesmo enunciado");

            return entity;


        }
    }
}
