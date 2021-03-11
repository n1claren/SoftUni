using System;
using System.Collections.Generic;

namespace _04.Wild_Farm
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            int animalsCount = 0;
            int index = 0;

            while (true)
            {

                if (index % 2 == 0)
                {
                    string[] input = Console.ReadLine()
                                              .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string type = input[0];

                    if (type == "End")
                    {
                        break;
                    }

                    string name = input[1];
                    double weight = double.Parse(input[2]);

                    Animal animal = null;

                    if (type == nameof(Hen))
                    {
                        double wingSize = double.Parse(input[3]);
                        animal = new Hen(name, weight, wingSize);
                    }
                    else if (type == nameof(Owl))
                    {
                        double wingSize = double.Parse(input[3]);
                        animal = new Owl(name, weight, wingSize);
                    }
                    else if (type == nameof(Cat))
                    {
                        string region = input[3];
                        string breed = input[4];
                        animal = new Cat(name, weight, region, breed);
                    }
                    else if (type == nameof(Dog))
                    {
                        string region = input[3];
                        animal = new Dog(name, weight, region);
                    }
                    else if (type == nameof(Mouse))
                    {
                        string region = input[3];
                        animal = new Mouse(name, weight, region);
                    }
                    else if (type == nameof(Tiger))
                    {
                        string region = input[3];
                        string breed = input[4];
                        animal = new Tiger(name, weight, region, breed);
                    }

                    animals.Add(animal);
                    animal.Sound();

                    animalsCount++;

                    index++;
                }
                else
                {
                    string[] cmdArgs = Console.ReadLine()
                                              .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string foodType = cmdArgs[0];
                    int foodQuantity = int.Parse(cmdArgs[1]);

                    Food food = null;

                    if (foodType == nameof(Fruit))
                    {
                        food = new Fruit(foodQuantity);
                    }
                    else if (foodType == nameof(Meat))
                    {
                        food = new Meat(foodQuantity);
                    }
                    else if (foodType == nameof(Seeds))
                    {
                        food = new Seeds(foodQuantity);
                    }
                    else if (foodType == nameof(Vegetable))
                    {
                        food = new Vegetable(foodQuantity);
                    }

                    animals[animalsCount - 1].Eat(food);

                    index++;
                }
            }

            foreach (var item in animals)
            {
                Console.WriteLine(item);
            }
        }
    }
}