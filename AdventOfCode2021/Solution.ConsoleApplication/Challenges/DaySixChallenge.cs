using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Solution.ConsoleApplication.Common;

namespace Solution.ConsoleApplication.Challenges
{
    public class DaySixChallenge : Challenge
    {
        public DaySixChallenge(string sourceFile)
        {
            ChallengeName = "Lanternfish";
            Day = 6;
            LoadedFile = File.ReadAllLines(sourceFile);
        }

        public override sealed string[] LoadedFile { get; }
        public override int Day { get; }
        public override string ChallengeName { get; }
        public override string ChallengeOne => ChallengeOneSolver();
        public override string ChallengeTwo => ChallengeTwoSolver();

        #region Private Methods

        private string ChallengeOneSolver()
        {
            var ages = LoadedFile[0].Split(',')
                                    .Select(int.Parse)
                                    .ToArray();

            var dayZero = Enumerable.Range(0, 9).Select(age => ages.LongCount(x => x == age)).ToArray();

            return Enumerable.Range(0, 80)
                             .Aggregate(dayZero, (a, _) => a[1..7].Concat(new[] { a[7] + a[0], a[8], a[0] })
                                                                  .ToArray())
                             .Sum()
                             .ToString();
        }

        private string ChallengeTwoSolver()
        {
            var ages = LoadedFile[0].Split(',')
                                    .Select(int.Parse)
                                    .ToArray();

            var dayZero = Enumerable.Range(0, 9).Select(age => ages.LongCount(x => x == age)).ToArray();

            return Enumerable.Range(0, 256)
                             .Aggregate(dayZero, (a, _) => a[1..7].Concat(new[] { a[7] + a[0], a[8], a[0] })
                                                                  .ToArray())
                             .Sum()
                             .ToString();
        }       

        #endregion Private Methods
    }
}