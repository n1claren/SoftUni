using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public void Call(string number)
        {
            if (!number.All(ch => Char.IsDigit(ch)))
            {
                throw new InvalidNumberException();
            }

            Console.WriteLine($"Calling... {number}");
        }
        public void Browse(string url)
        {
            if (url.Any(ch => Char.IsDigit(ch)))
            {
                throw new InvalidURLException();
            }

            Console.WriteLine($"Browsing: {url}!");
        }
    }
}
