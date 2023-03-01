using MediaDatabaseCreator.Model;
using Microsoft.EntityFrameworkCore;

namespace MediaDatabaseCreator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<MovieDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("AppSettingsDbContext"));
            });

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}