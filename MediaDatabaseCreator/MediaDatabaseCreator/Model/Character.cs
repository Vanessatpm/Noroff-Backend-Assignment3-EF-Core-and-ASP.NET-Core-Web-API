using System.ComponentModel.DataAnnotations;

namespace MediaDatabaseCreator.Model
{
    public class Character
    {
        [Key]
        public int CharacterId { get; set; }
        [MaxLength(40)]
        public string FullName { get; set; }
        [MaxLength(40)]
        public string? Alias { get; set; }
        public bool Gender { get; set; }
        public string Picture { get; set; }
    }
}
