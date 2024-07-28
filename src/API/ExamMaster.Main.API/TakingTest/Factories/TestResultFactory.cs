using ExamMaster.Domain.TakingTest.Entities;
using ExamMaster.Domain.TakingTest.Interfaces;
using ExamMaster.Domain.TakingTest.Requests;

namespace ExamMaster.Domain.TakingTest.Factories
{
    public class TestResultFactory : ITestResultFactory
    {
        //private readonly ITestManagerRepository _testManagerRepository;
        //private readonly IUserRepository _userRepository;

        public TestResultFactory(
                //ITestManagerRepository testManagerRepository,
                //IUserRepository userRepository
                )
        {
            //_testManagerRepository = testManagerRepository;
            //_userRepository = userRepository;
        }
        public async Task<TakeExamEntity> CreateAsync(TestResultRequest request)
        {
            throw new NotImplementedException();
            //var testManagerEntity = await _testManagerRepository.GetByUniqueIdAsync(request.TestManagerId);
            //TakeExamException.ThrowWhen(testManagerEntity == null, "ERROR_TESTRESULTFACTORY_001", "Teste não encontrado.");
                        

            //var userEntity = await _userRepository.GetByUniqueIdAsync(request.UserId);
            //TakeExamException.ThrowWhen(userEntity == null, "ERROR_TESTRESULTFACTORY_002", "Usuário não encontrado.");
            
            //var entity = new TestResultEntity(testManagerEntity, userEntity);

            //return entity;
        }
    }
}
