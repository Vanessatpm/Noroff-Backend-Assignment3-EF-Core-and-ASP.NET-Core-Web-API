using MediaDatabaseCreator.Model;
using MediaDatabaseCreator.Services;
using Microsoft.EntityFrameworkCore;

namespace MediaDatabaseCreator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<FilmDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString(
                    "VanessaMovieDatabase"
                    ));
            });

            builder.Services.AddScoped<ICharacterService, CharacterService>();

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