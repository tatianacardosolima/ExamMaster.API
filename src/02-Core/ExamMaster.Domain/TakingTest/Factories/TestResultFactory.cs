using ExamMaster.Domain.TakingTest.Entities;
using ExamMaster.Domain.TakingTest.Exceptions;
using ExamMaster.Domain.TakingTest.Interfaces;
using ExamMaster.Domain.TakingTest.Requests;
using ExamMaster.Domain.TestManager.Interfaces;
using ExamMaster.Domain.Users.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Domain.TakingTest.Factories
{
    public class TestResultFactory : ITestResultFactory
    {
        private readonly ITestManagerRepository _testManagerRepository;
        private readonly IUserRepository _userRepository;

        public TestResultFactory(
                ITestManagerRepository testManagerRepository,
                IUserRepository userRepository)
        {
            _testManagerRepository = testManagerRepository;
            _userRepository = userRepository;
        }
        public async Task<TestResultEntity> CreateAsync(TestResultRequest request)
        {
            var testManagerEntity = await _testManagerRepository.GetByUniqueIdAsync(request.TestManagerId);
            TestResultException.ThrowWhen(testManagerEntity == null, "ERROR_TESTRESULTFACTORY_001", "Teste não encontrado.");
                        

            var userEntity = await _userRepository.GetByUniqueIdAsync(request.UserId);
            TestResultException.ThrowWhen(userEntity == null, "ERROR_TESTRESULTFACTORY_002", "Usuário não encontrado.");
            
            var entity = new TestResultEntity(testManagerEntity, userEntity);

            return entity;
        }
    }
}
