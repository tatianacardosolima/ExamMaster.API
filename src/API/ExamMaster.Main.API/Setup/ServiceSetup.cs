using Common.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MockExam.Manage.Database.Write.Context;
using MockExam.Manage.Database.Write.Repositories;
using MockExam.Manage.Domain.Answers.Factories;
using MockExam.Manage.Domain.Answers.Interfaces;
using MockExam.Manage.Domain.Answers.Services;
using MockExam.Manage.Domain.MockExam.Interfaces;
using MockExam.Manage.Domain.MockExam.Services;
using MockExam.Manage.Domain.Question.Services;

namespace MockExam.Manage.API.Setup
{
    public static class ServiceSetup
    {
       
        public static void AddDependencyService(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddTransient<IMockService, MockService>();
            services.AddTransient<IQuestionService, QuestionService>();
            services.AddTransient<IAnswerService, AnswerService>();

        }
    }
}
