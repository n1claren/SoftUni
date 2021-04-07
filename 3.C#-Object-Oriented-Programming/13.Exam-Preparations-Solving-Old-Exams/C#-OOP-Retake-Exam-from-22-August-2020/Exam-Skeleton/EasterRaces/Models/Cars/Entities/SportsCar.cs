namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private const int cubicCentimeters = 3000;
        private const int minHP = 250;
        private const int maxHP = 450;

        public SportsCar(string model, int horsePower) 
            : base(model, horsePower, cubicCentimeters, minHP, maxHP)
        {

        }
    }
}
