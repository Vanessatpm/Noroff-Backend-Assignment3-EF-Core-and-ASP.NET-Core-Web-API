using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediaDatabaseCreator.Model.DTO
{
    public class FranchiseDTO
    {

        [Key]
        public int FranchiseId { get; set; }
        [MaxLength(40)]
        public string Name { get; set; } = null!;
        [MaxLength(600)]
        public string? Description { get; set; }

        // Navigation
       // public virtual ICollection<MovieDTO> Movies { get; set; } = new HashSet<MovieDTO>();
    }
}
