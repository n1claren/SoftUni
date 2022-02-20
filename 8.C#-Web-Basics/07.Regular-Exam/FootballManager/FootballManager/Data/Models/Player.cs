using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootballManager.Data.Models
{
    public class Player
    {
        [Key]
        public int Id { get; init; }

        [Required]
        public string FullName { get; init; }

        [Required]
        public string ImageUrl { get; init; }

        [Required]
        public string Position { get; init; }

        [Required]
        public byte Speed { get; init; }

        [Required]
        public byte Endurance { get; init; }

        [Required]
        public string Description { get; init; }

        public ICollection<UserPlayer> UserPlayers { get; init; }
    }
}
