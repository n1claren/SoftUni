using System;

namespace CarDealer.DTO
{
    public class CustomerInputModel
    {
        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        public bool IsYoungDriver { get; set; }
    }
}
