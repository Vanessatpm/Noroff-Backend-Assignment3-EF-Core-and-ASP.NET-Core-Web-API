using MediaDatabaseCreator.Model;
using MediaDatabaseCreator.Services;
using MediaDatabaseCreator.Services.Franchises;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace MediaDatabaseCreator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddDbContext<FilmDbContext>(options 
                => options.UseSqlServer(builder.Configuration.GetConnectionString("VanessaMovieDatabase")));
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
            builder.Services.AddScoped<ICharacterService, CharacterService>();
            builder.Services.AddTransient<IFranchiseService, FranchiseService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}