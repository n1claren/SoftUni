namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const int cubicCentimeters = 5000;
        private const int minHP = 400;
        private const int maxHP = 600;

        public MuscleCar(string model, int horsePower) 
            : base(model, horsePower, cubicCentimeters, minHP, maxHP)
        {

        }
    }
}
