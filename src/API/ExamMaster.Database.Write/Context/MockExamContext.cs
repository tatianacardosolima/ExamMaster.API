using Microsoft.EntityFrameworkCore;
using MockExam.Manage.Database.Write.Mappings;
using MockExam.Manage.Domain.Answers.Entities;
using MockExam.Manage.Domain.Mocks.Entities;
using MockExam.Manage.Domain.Questions.Entities;

namespace MockExam.Manage.Database.Write.Context
{
    public class MockExamContext : DbContext
    {
        public string UserId { get; set; }
        public MockExamContext(DbContextOptions<MockExamContext> options,
               string userId
            ) : base(options)
        {
            UserId = userId;
        }

        public DbSet<MockEntity> Mock{ get; set; }
        public DbSet<QuestionEntity> Question { get; set; }
        public DbSet<AnswerOptionEntity> Answer { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfiguration(new MockMap());
            builder.ApplyConfiguration(new QuestionMap());
            builder.ApplyConfiguration(new AnswerMap());

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(true, cancellationToken);
        }


    }
}
