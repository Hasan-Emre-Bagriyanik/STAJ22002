using Teacher_Schedule_Api.Models.DapperContext;
using Teacher_Schedule_Api.Repositories.LessonRepositories;
using Teacher_Schedule_Api.Repositories.SchedulesRepositories;
using Teacher_Schedule_Api.Repositories.StatisticRepositories;
using Teacher_Schedule_Api.Repositories.StudentCommentRepositories;
using Teacher_Schedule_Api.Repositories.TeacherRepositories;
using Teacher_Schedule_Api.Repositories.WhoWeAreRepositories;
namespace Teacher_Schedule_Api
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddTransient<Context>();

            builder.Services.AddTransient<ITeacherRepository, TeacherRepository>();
            builder.Services.AddTransient<ILessonRepository, LessonRepository>();
            builder.Services.AddTransient<IScheduleRepository, ScheduleRepository>();
            builder.Services.AddTransient<IStudentCommentRepository, StudentCommentRepository>();
            builder.Services.AddTransient<IWhoWeAreRepository, WhoWeAreRepository>();
            builder.Services.AddTransient<IStatisticRepository, StatisticRepository>();
            // Add services to the container.

            builder.Services.AddHttpClient();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}