using MockExam.Manage.Database.Write.Abstractions;
using MockExam.Manage.Database.Write.Context;
using MockExam.Manage.Domain.MockExam.Interfaces;
using MockExam.Manage.Domain.Mocks.Entities;

namespace MockExam.Manage.Database.Write.Repositories
{
    public class MockExamRepository : RepositoryBase<MockEntity, Guid>, IMockRepository
    {
        public MockExamRepository(MockExamContext context) : base(context)
        {
        }
    }
}
