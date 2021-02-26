using System;

namespace Person
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string nameInput = Console.ReadLine();
            int ageInput = int.Parse(Console.ReadLine());

            if (ageInput > 0 && ageInput > 15)
            {
                Person person = new Person(nameInput, ageInput);

                Console.WriteLine(person);
            }
            else if (ageInput > 0 && ageInput <= 15)
            {
                Child chield = new Child(nameInput, ageInput);

                Console.WriteLine(chield);
            }
        }
    }
}
