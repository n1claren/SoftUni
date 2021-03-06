using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class InvalidMissionCompletionException : Exception
    {
        private const string MISSION_COMPLETED_ERROR = "Mission already completed!";
        public InvalidMissionCompletionException()
            : base(MISSION_COMPLETED_ERROR)
        {
        }
        public InvalidMissionCompletionException(string message) 
            : base(message)
        {
        }
    }
}
