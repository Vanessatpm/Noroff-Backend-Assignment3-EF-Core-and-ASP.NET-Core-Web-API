namespace MediaDatabaseCreator.Model.DTO.CharacterDTO_s
{
    public class CharacterPutDTO
    {
        public int CharacterId { get; set; }
        public string FullName { get; set; }
        public string? Alias { get; set; } 
        public string? Gender { get; set; }
        public string? PictureUrl { get; set; }
    }
}
