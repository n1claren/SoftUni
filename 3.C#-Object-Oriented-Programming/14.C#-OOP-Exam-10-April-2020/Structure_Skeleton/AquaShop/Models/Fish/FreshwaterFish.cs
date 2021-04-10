namespace AquaShop.Models.Fish
{
    public class FreshwaterFish : Fish
    {
        private const int size = 3;

        public FreshwaterFish(string name, string species, decimal price) 
            : base(name, species, price)
        {
            Size = size;
        }

        public override void Eat()
        {
            Size += 3;
        }
    }
}
