using MockExam.Manage.Domain.Answers.Factories;
using MockExam.Manage.Domain.Answers.Interfaces;
using MockExam.Manage.Domain.MockExam.Interfaces;

namespace MockExam.Manage.API.Setup
{
    public static class FactorySetup
    {
       
        public static void AddDependencyFactory(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddTransient<IMockFactory, MockFactory>();
            services.AddTransient<IQuestionFactory, QuestionFactory>();
            services.AddTransient<IAnswerFactory, AnswerFactory>();

        }
    }
}
