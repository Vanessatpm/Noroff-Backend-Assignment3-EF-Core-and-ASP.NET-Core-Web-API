using System.ComponentModel.DataAnnotations;

namespace MediaDatabaseCreator.Model
{
    public class Franchise
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
