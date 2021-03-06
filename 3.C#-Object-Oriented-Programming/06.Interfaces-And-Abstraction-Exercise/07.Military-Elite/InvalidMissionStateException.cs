using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class InvalidMissionStateException : Exception
    {
        private const string INVALID_STATE = "Invalid mission state!";
        public InvalidMissionStateException()
            : base(INVALID_STATE)
        {

        }
        public InvalidMissionStateException(string message) 
            : base(message)
        {

        }
    }
}
