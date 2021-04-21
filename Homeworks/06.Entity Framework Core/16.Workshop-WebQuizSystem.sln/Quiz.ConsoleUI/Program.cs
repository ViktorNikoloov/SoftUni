using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quiz.Data;
using Quiz.Services;
using System.IO;

namespace Quiz.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var quizService = serviceProvider.GetService<IQuizService>();
            var quiz = quizService.GetQuizById(1);

            System.Console.WriteLine(quiz.Title);

            foreach (var question in quiz.Questions)
            {
                System.Console.WriteLine(question.Title);

                foreach (var answer in question.Answers)
                {
                    System.Console.WriteLine(answer.Title);
                }
            }

            //var quizService = serviceProvider.GetService<IQuizService>();
            //quizService.Add("C# DB");

            //var questionService = serviceProvider.GetService<IQuestionService>();
            //questionService.Add("What is Entity Framework Core", 1);

            //var answerService = serviceProvider.GetService<IAnswerService>();
            //answerService.Add("it is MicroORM", 0, false, 1);

            //var userAnswerService = serviceProvider.GetService<IUserAnswerService>();
            //userAnswerService.AddUserAnswer("1bc16e6d-4e4b-425f-85ad-0ebeaafb064c", 1, 1, 2);


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

        }
    }
}
