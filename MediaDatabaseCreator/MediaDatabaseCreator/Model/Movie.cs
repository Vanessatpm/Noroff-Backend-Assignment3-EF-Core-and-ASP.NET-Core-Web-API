using System.ComponentModel.DataAnnotations;

namespace MediaDatabaseCreator.Model
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(40)]
        public string MovieTitle { get; set; }
        [MaxLength(60)]
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        [MaxLength(40)]
        public string Director { get; set; }
        public string MoviePicture { get; set; }
        public string MovieTrailer { get; set; }

    }
}
