using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Engine
    {
        public const string END_OF_INPUT_COMMAND = "Beast!";

        private readonly List<Animal> animals;

        public Engine()
        {
            this.animals = new List<Animal>();
        }

        public void Run()
        {
            string type = string.Empty;

            while ((type = Console.ReadLine()) != END_OF_INPUT_COMMAND)
            {
                string[] animalInput = Console.ReadLine().Split();

                Animal animal;

                try
                {
                    animal = GetAnimal(type, animalInput);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }

                this.animals.Add(animal);
            }

            foreach (Animal animal in this.animals)
            {
                Console.WriteLine(animal);
            }
        }

        private Animal GetAnimal(string type, string[] animalInput)
        {
            string name = animalInput[0];
            int age = int.Parse(animalInput[1]);
            string gender = GetGender(animalInput);

            Animal animal = null;

            if (type == "Dog")
            {
                animal = new Dog(name, age, gender);
            }
            else if (type == "Cat")
            {
                animal = new Cat(name, age, gender);
            }
            else if (type == "Frog")
            {
                animal = new Frog(name, age, gender);
            }
            else if (type == "Kitten")
            {
                animal = new Kitten(name, age);
            }
            else if (type == "Tomcat")
            {
                animal = new Tomcat(name, age);
            }
            else
            {
                throw new ArgumentException("Invalid input!");
            }

            return animal;
        }

        private string GetGender(string[] animalInput)
        {
            string gender = null;

            if (animalInput.Length >= 3)
            {
                gender = animalInput[2];
            }

            return gender;
        }
    }
}
