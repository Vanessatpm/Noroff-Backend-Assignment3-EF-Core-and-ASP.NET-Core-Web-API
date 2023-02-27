using System.ComponentModel.DataAnnotations;

namespace MediaDatabaseCreator.Model
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string MovieTitle { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public string Director { get; set; }
        public string MoviePicture { get; set; }
        public string MovieTrailer { get; set; }

    }
}
