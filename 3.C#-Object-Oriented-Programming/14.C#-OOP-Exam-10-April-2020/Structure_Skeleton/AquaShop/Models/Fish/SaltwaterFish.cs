namespace AquaShop.Models.Fish
{
    public class SaltwaterFish : Fish
    {
        private const int size = 5;

        public SaltwaterFish(string name, string species, decimal price) 
            : base(name, species, price)
        {
            Size = size;
        }

        public override void Eat()
        {
            Size += 2;
        }
    }
}
