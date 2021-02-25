using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList randomList = new RandomList();

            randomList.Add("Ivanka");
            randomList.Add("Stoqnka");
            randomList.Add("Ebanka");
            randomList.Add("Pembqnka");
            randomList.Add("Divanka");
            randomList.Add("Huliganka");
            randomList.Add("Gogi");

            for (int i = 0; i < 7; i++)
            {
                randomList.RandomString();
            }
        }
    }
}
