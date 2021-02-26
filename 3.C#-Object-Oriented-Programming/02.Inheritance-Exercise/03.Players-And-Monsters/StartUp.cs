using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            BladeKnight bladeKnight = new BladeKnight("HuKuTa", 85);

            Console.WriteLine(bladeKnight);
        }
    }
}
