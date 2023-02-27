using System.ComponentModel.DataAnnotations;

namespace MediaDatabaseCreator.Model
{
    public class Franchise
    {
        public Franchise()
        {
            Movies = new HashSet<Movie>();
        }

        [Key]
        public int FranchiseId { get; set; }
        [MaxLength(40)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string? Description { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
