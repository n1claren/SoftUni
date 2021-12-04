using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Theatre.DataProcessor.ImportDto
{
    public class TheatreInputModel
    {
        [Required]
        [StringLength(30, MinimumLength = 4)]
        public string Name { get; set; }

        [Required]
        [Range(1, 10)] 
        // SPENT 2 HOURS SEARCHING FOR 8 MISSING POINTS IN THE SCORE COZ OF THIS STUPID ASS PROPERTY !!!!!!!!!!!!!!
        public sbyte NumberOfHalls { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 4)]
        public string Director { get; set; }

        public ICollection<TicketInputModel> Tickets { get; set; }
    }
}
