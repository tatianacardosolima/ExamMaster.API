using Microsoft.EntityFrameworkCore;
using MockExam.Manage.Database.Write.Context;
using MockExam.Manage.Database.Write.Repositories;
using MockExam.Manage.Domain.Answers.Interfaces;
using MockExam.Manage.Domain.MockExam.Interfaces;

namespace MockExam.Manage.API.Setup
{
    public static class RepositorySetup
    {
        public static void AddDependencyDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddScoped(serviceProvider =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                var options = new DbContextOptionsBuilder<MockExamContext>()
                    .UseMySql(connectionString, new MySqlServerVersion(new Version(9, 0, 1)))
                    .Options;

                var userLoggedInfo = "1"; // Capturar o usuário logado através do Token
                var context = new MockExamContext(options, userLoggedInfo);
                return context;
            });
        }
        public static void AddDependencyRepository(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddTransient<IMockRepository, MockExamRepository>();
            services.AddTransient<IQuestionRepository, QuestionRepository>();
            services.AddTransient<IAnswerRepository, AnswerRepository>();

        }
    }
}
