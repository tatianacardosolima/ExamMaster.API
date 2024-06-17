using ExamMaster.Domain.TestManager.Exceptions;
using ExamMaster.Domain.TestManager.Interfaces;
using ExamMaster.Domain.TestManager.Requests;
using ExamMaster.Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Domain.TestManager.Facade
{
    internal class TestManagerFacade : ITestManagerFacade
    {
        private readonly ITestManagerRepository _repository;
        private readonly ITestManagerFactory _factory;

        public TestManagerFacade(ITestManagerRepository repository, ITestManagerFactory factory)
        {
            _repository = repository;
            _factory = factory;

        }
        public async Task<DefaultResponse> CreateTestManager(TestManagerRequest request)
        {
            TestManagerException.ThrowWhen(request == null, 
                    "ERROR_TESTMANAGER_REQUEST", "Os dados do testes não podem ser nulos");

            var entity = await _factory.CreateAsync(request);

            await _repository.InsertAsync(entity);

            return new DefaultResponse(true, "Teste Manager Inserido com sucesso!", new { id = entity.Id });

        }
    }
}
