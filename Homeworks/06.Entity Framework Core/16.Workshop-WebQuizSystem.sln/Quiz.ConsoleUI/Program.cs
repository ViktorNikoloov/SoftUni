using System.IO;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Quiz.Data;
using Quiz.Services;
using Quiz.Services.Models;

namespace Quiz.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            //var dbContext = serviceProvider.GetService<ApplicationDbContext>();
            //dbContext.Database.Migrate();

            var jsonImporter = serviceProvider.GetService<IJsonImportService>();
            jsonImporter.Import("EF-Core-Quiz.json", "EF Core Test");


            //var addQuiz = serviceProvider.GetService<IQuizService>();
            //addQuiz.Add("SoftUniQuiz");

            //var questionService = serviceProvider.GetService<IQuestionService>();
            //questionService.Add("1+1", 1);

            //var answerService = serviceProvider.GetService<IAnswerService>();
            //answerService.Add("2", 5, true, 3);

            //var userAnswerService = serviceProvider.GetService<IUserAnswerService>();
            //userAnswerService
            //    .AddUserAnswer("fdb3074e-caa7-4fea-b798-4df63a06d935", 1, 3, 1);

            //var quizService = serviceProvider.GetService<IUserAnswerService>();
            //var quiz = quizService
            //    .GetUserResult("fdb3074e-caa7-4fea-b798-4df63a06d935", 1);

            //Console.WriteLine(quiz);

            //var quizService = serviceProvider.GetService<IQuizService>();
            //quizService.Add("C# DB");
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            services.AddDbContext<ApplicationDbContext>(options
                => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>(options
                => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddTransient<IQuizService, QuizService>();
            services.AddTransient<IQuestionService, QuestionService>();
            services.AddTransient<IAnswerService, AnswerService>();
            services.AddTransient<IUserAnswerService, UserAnswerService>();
            services.AddTransient<IJsonImportService, JsonImportService>();
        }
    }
}
