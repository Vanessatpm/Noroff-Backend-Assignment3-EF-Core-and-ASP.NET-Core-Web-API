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
        public DbContext<Franchise> Franchises { get; set; }
    }
}
