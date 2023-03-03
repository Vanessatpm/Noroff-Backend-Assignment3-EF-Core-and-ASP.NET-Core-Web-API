using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediaDatabaseCreator.Model.Entities
{
    public class Franchise
    {

        [Key]
        public int FranchiseId { get; set; }
        [MaxLength(40)]
        public string Name { get; set; } = null!;
        [MaxLength(600)]
        public string? Description { get; set; }

        // Navigation
        public virtual ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();
    }
}
