using System.ComponentModel.DataAnnotations;

namespace MediaDatabaseCreator.Model
{
    public class Character
    {
        [Key]
        public int CharacterId { get; set; }
        [MaxLength(40)]
        public string FullName { get; set; } = null!;
        [MaxLength(40)]
        public string? Alias { get; set; }
        [MaxLength(5)]
        public string? Gender { get; set; }
        public string? Picture { get; set; }
        public virtual ICollection<Movie> Movies { get;set; } = new HashSet<Movie>();
    }
}
