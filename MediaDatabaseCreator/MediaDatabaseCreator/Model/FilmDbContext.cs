using MediaDatabaseCreator.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace MediaDatabaseCreator.Model
{
    public class FilmDbContext : DbContext
    {
        public FilmDbContext(DbContextOptions<FilmDbContext> options) : base(options)
        {
        }

        // DbSets
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Franchise> Franchises { get; set; }

        // Data seeding
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Franchises
            modelBuilder.Entity<Franchise>().HasData(
                new Franchise() { FranchiseId = 1, Name = "Marvel Cinematic Universe", Description = "A series of superhero films produced by Marvel Studios" },
                new Franchise() { FranchiseId = 2, Name = "Star Wars", Description = "An epic space opera media franchise created by George Lucas" },
                new Franchise() { FranchiseId = 3, Name = "The Lord of the Rings", Description = "An epic high fantasy novel by J.R.R. Tolkien" }
            );
            #endregion

            #region Characters
            modelBuilder.Entity<Character>().HasData(
               new Character() { CharacterId = 1, FullName = "Tony Stark", Alias = "Iron Man", Gender = "Male", PictureUrl = "https://www.imdb.com/title/tt0371746/mediaviewer/rm1006248448/" },
               new Character() { CharacterId = 2, FullName = "Steve Rogers", Alias = "Captain America", Gender = "Male", PictureUrl = "https://www.imdb.com/title/tt0458339/mediaviewer/rm2483030016/" },
               new Character() { CharacterId = 3, FullName = "Thor Odinson", Alias = "Thor", Gender = "Male", PictureUrl = "https://www.imdb.com/title/tt0800369/mediaviewer/rm1346871297/" },
               new Character() { CharacterId = 4, FullName = "Luke Skywalker", Alias = "Jedi Knight", Gender = "Male", PictureUrl = "https://www.imdb.com/title/tt0076759/mediaviewer/rm2446233600/" },
               new Character() { CharacterId = 5, FullName = "Princess Leia Organa", Alias = "General Leia Organa", Gender = "Female", PictureUrl = "https://www.imdb.com/title/tt0076759/mediaviewer/rm1222220800/" },
               new Character() { CharacterId = 6, FullName = "Frodo Baggins", Alias = "Ring bearer", Gender = "Male", PictureUrl = "https://example.com/frodo.jpg" });
            #endregion

            #region Movies
            modelBuilder.Entity<Movie>().HasData(
                new Movie()
                {
                    MovieId = 1,
                    MovieTitle = "Avengers: Endgame",
                    Genre = "Action, Adventure, Drama",
                    ReleaseYear = 2019,
                    Director = "Anthony Russo, Joe Russo",
                    MoviePictureUrl = "https://www.imdb.com/title/tt4154796/mediaviewer/rm1057017345/",
                    MovieTrailerUrl = "https://www.youtube.com/watch?v=TcMBFSGVi1c",
                    FranchiseId = 2
                },
                new Movie() { 
                    MovieId = 2, 
                    MovieTitle = "Star Wars: Episode IV - A New Hope", 
                    Genre = "Action, Adventure, Fantasy", 
                    ReleaseYear = 1977, 
                    Director = "George Lucas", 
                    MoviePictureUrl = "https://www.imdb.com/title/tt0076759/mediaviewer/rm3500569857/", 
                    MovieTrailerUrl = "https://www.youtube.com/watch?v=1g3_CFmnU7k", 
                    FranchiseId = 2
                },
                new Movie() { 
                    MovieId = 3, 
                    MovieTitle = "The Lord of the Rings: The Fellowship of the Ring", 
                    Genre = "Action, Adventure, Drama", 
                    ReleaseYear = 2001, 
                    Director = "Peter Jackson", 
                    MoviePictureUrl = "https://www.imdb.com/title/tt0120737/mediaviewer/rm3693752064/", 
                    MovieTrailerUrl = "https://www.youtube.com/watch?v=V75dMMIW2B4",
                    FranchiseId = 3
                }
            );
            #endregion

            #region CharacterMovie
            modelBuilder.Entity<Character>()
                .HasMany(character => character.Movies)
                .WithMany(movie => movie.Characters)
                .UsingEntity<Dictionary<string, object>>(
                    "CharacterMovie",
                    r => r.HasOne<Movie>().WithMany().HasForeignKey("MovieId"),
                    l => l.HasOne<Character>().WithMany().HasForeignKey("CharacterId"),
                    je =>
                    {
                        je.HasKey("CharacterId", "MovieId");
                        je.HasData(
                            new { CharacterId = 1, MovieId = 2 },
                            new { CharacterId = 2, MovieId = 2 },
                            new { CharacterId = 2, MovieId = 1 },
                            new { CharacterId = 3, MovieId = 2 },
                            new { CharacterId = 2, MovieId = 3 },
                            new { CharacterId = 6, MovieId = 1 });
                    });
            #endregion

        }

    }
}
