using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Store_Boxes
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Box> boxes = new List<Box>();

            while (input != "end")
            {
                string[] inputCollection = input.Split();

                Box currentBox = new Box();

                currentBox.SeriaNumber = inputCollection[0];
                currentBox.Item.Name = inputCollection[1];
                currentBox.Quantity = int.Parse(inputCollection[2]);
                currentBox.Item.Price = double.Parse(inputCollection[3]);

                currentBox.PriceBox = currentBox.Quantity * (decimal)currentBox.Item.Price;

                boxes.Add(currentBox);

                input = Console.ReadLine();
            }

            List<Box> result = boxes.OrderByDescending(x => x.PriceBox).ToList();

            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine(result[i].SeriaNumber);
                Console.WriteLine($"-- {result[i].Item.Name} - ${result[i].Item.Price:f2}: {result[i].Quantity}");
                Console.WriteLine($"-- ${result[i].PriceBox:f2}");
            }
        }
    }

    class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }

    class Box
    {
        public Box()
        {
            Item = new Item();
        }

        public string SeriaNumber { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public decimal PriceBox { get; set; }
    }
}
