using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediaDatabaseCreator.Model.DTO
{
    public class CharacterDTO
    {
        [Key]
        public int CharacterId { get; set; }
        [MaxLength(40)]
        public string FullName { get; set; }
        [MaxLength(40)]
        public string? Alias { get; set; }
        [MaxLength(8)]
        public string? Gender { get; set; }
        public string? PictureUrl { get; set; }
        public int[] Movies { get; set; }

    }
}
