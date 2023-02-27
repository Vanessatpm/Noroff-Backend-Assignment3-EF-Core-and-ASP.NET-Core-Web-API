using System.ComponentModel.DataAnnotations;

namespace MediaDatabaseCreator.Model
{
    public class Character
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string? Alias { get; set; }
        public bool Gender { get; set; }
        public string Picture { get; set; }
    }
}
