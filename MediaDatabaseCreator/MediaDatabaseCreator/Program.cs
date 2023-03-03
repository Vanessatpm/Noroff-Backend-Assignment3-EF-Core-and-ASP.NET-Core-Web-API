using MediaDatabaseCreator.Model;
using MediaDatabaseCreator.Services.CharacterServices;
using MediaDatabaseCreator.Services.Franchises;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace MediaDatabaseCreator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configuring generated XML docs for Swagger

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);


            // Add services to the container.
            builder.Services.AddControllers();

            builder.Services.AddDbContext<FilmDbContext>(options 
                => options.UseSqlServer(builder.Configuration.GetConnectionString("AbdullahMovieDatabase")));
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Film API",
                    Description = "Simple API to manage Film information",
                    License = new OpenApiLicense
                    {
                        Name = "MIT 2022",
                        Url = new Uri("https://opensource.org/licenses/MIT")
                    }
                });
                c.IncludeXmlComments(xmlPath);

            });

            builder.Services.AddTransient<ICharacterService, CharacterService>();
            builder.Services.AddTransient<IFranchiseService, FranchiseService>();

            builder.Services.AddControllers();

            // Automapper
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



            


            // Build
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if(app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
          
            app.MapControllers();

            app.Run();
        }
    }
}