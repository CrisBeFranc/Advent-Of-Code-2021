using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Solution.ConsoleApplication.Common
{
    public abstract class Challenge
    {
        public abstract string[] LoadedFile { get; }
        public abstract int Day { get; }
        public abstract string ChallengeName { get; }
        public abstract string ChallengeOne { get; }
        public abstract string ChallengeTwo { get; }
    }
}