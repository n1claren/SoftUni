using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony
{
    public class InvalidNumberException : Exception
    {
        private const string EXEPTION_MSG = "Invalid number!";

        public InvalidNumberException()
            : base(EXEPTION_MSG)
        {
        }

        public InvalidNumberException(string message) 
            : base(message)
        {
        }
    }
}
