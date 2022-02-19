using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SharedTrip.Data.Models
{
    public class Trip
    {
        [Key]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        public string StartPoint { get; init; }

        [Required]
        public string EndPoint { get; init; }

        [Required]
        public DateTime DepartureTime { get; init; }

        [Required]
        public int Seats { get; init; }

        [Required]
        public string Description { get; init; }

        public string ImagePath { get; init; }

        public List<UserTrip> UserTrips { get; init; } = new List<UserTrip>();
    }
}
