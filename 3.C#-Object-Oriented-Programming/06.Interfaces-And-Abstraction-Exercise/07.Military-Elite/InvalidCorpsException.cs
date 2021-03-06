using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class InvalidCorpsException : Exception
    {
        private const string INVALID_MSG = "Invalid corps!";
        public InvalidCorpsException()
            : base(INVALID_MSG)
        {

        }

        public InvalidCorpsException(string message) 
            : base(message)
        {

        }
    }
}
