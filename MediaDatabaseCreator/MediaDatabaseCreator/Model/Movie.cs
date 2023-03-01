using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.PortableExecutable;

namespace MediaDatabaseCreator.Model
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        [MaxLength(60)]
        public string MovieTitle { get; set; } = null!;
        [MaxLength(60)]
        public string? Genre { get; set; }
        public int ReleaseYear { get; set; }
        [MaxLength(40)]
        public string Director { get; set; } = null!;
        public string? MoviePictureUrl { get; set; }
        public string? MovieTrailerUrl { get; set; }

        // Navigation
        public virtual ICollection<Character> Characters { get; set; } = new HashSet<Character>();
        public int FranchiseId { get; set; }
        public virtual Franchise Franchise { get; set; } = null!;
    }
}
