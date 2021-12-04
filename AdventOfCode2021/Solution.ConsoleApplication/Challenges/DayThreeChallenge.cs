using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Solution.ConsoleApplication.Common;

namespace Solution.ConsoleApplication.Challenges
{
    public class DayThreeChallenge : Challenge
    {
        public DayThreeChallenge(string sourceFile)
        {
            ChallengeName = "Binary Diagnostic";
            Day = 3;
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
            var input = LoadedFile.Select(s => s.ToCharArray())
                                  .Select(arr => arr.Select(c => Convert.ToBoolean(int.Parse(c.ToString())))
                                                    .ToArray())
                                  .ToList();

            return input.Aggregate(new int[input.First().Length], (agg, bits) =>             
                                    agg.Select((n, i) => bits[i] ? n + 1 : n - 1).ToArray(), (agg) =>
                                                {
                                                    var bits = new BitArray(agg.Reverse()
                                                                               .Select(c => c > 0)
                                                                               .ToArray());
                                                    var numbers = new uint[2];
                                                    bits.CopyTo(numbers, 0);
                                                    bits.Not()
                                                        .CopyTo(numbers, 1);
                                                    return numbers[0] * numbers[1];
                                                })
                        .ToString();
        }

        private string ChallengeTwoSolver()
        {
            var input = LoadedFile.Select(s => s.ToCharArray())
                                  .Select(arr => arr.Select(c => Convert.ToBoolean(int.Parse(c.ToString())))
                                                    .ToArray())
                                  .ToList();

            var oxygenFilter = RecursiveFilter(input, 0, (i) => i == 0 || i > 0);
            var co2Filter = RecursiveFilter(input, 0, (i) => i != 0 && i < 0);
            var numbers = new uint[2];

            new BitArray(oxygenFilter.First()
                                     .Reverse()
                                     .ToArray())
                        .CopyTo(numbers, 0);

            new BitArray(co2Filter.First()
                                  .Reverse()
                                  .ToArray())
                        .CopyTo(numbers, 1);

            return $"{numbers[0] * numbers[1]}";
        }

        private IEnumerable<bool[]> RecursiveFilter(IEnumerable<bool[]> bytes, int index, Func<int, bool> comparator)
            => bytes.Count() > 1
            ? RecursiveFilter(bytes.Aggregate(0, (agg, bits) => bits[index] ? agg + 1 : agg - 1, 
                                                                (agg) => bytes.Where(bits => bits[index] == comparator.Invoke(agg))),
                                                                index + 1, comparator)
            : bytes;


        #endregion Private Methods
    }
}