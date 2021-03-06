using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Telephony
{
    public class StationaryPhone : ICallable
    {
        public void Call(string number)
        {
            if (!number.All(ch => Char.IsDigit(ch)))
            {
                throw new InvalidNumberException();
            }

            Console.WriteLine($"Dialing... {number}");
        }
    }
}
