using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace MediaDatabaseCreator.Model
{
    public class MovieEFContext : DbContext
    {
        public MovieEFContext() : base()
        {

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Franchise> Franchises { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source = " + //<INSERT YOUR DATA SOURCE>; " +
                "Initial Catalog = MovieEF; " +
                "Integrated Security = True; " +
                "Trust Server Certificate = True;");
        }
    }
}
