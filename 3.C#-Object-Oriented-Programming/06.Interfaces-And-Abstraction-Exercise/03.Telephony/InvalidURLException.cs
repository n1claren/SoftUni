using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony
{
    public class InvalidURLException : Exception
    {
        private const string EXCEPTION_MSG = "Invalid URL!";

        public InvalidURLException()
            : base(EXCEPTION_MSG)
        {
        }

        public InvalidURLException(string message) 
            : base(message)
        {
        }
    }
}
