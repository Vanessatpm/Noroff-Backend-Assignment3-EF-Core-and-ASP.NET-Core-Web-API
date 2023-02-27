﻿using System.ComponentModel.DataAnnotations;

namespace MediaDatabaseCreator.Model
{
    public class Franchise
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(40)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string? Description { get; set; }
    }
}