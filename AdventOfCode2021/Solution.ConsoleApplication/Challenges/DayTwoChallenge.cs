using System.IO;
using System.Linq;
using Solution.ConsoleApplication.Common;

namespace Solution.ConsoleApplication.Challenges
{
    public class DayTwoChallenge : Challenge
    {
        public DayTwoChallenge(string sourceFile)
        {
            ChallengeName = "Dive!";
            Day = 2;
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
            var input = LoadedFile.Select(x => x.Split(' '))
                                  .Select(x => (action: x[0], value: int.Parse(x[1])))
                                  .ToList();

            var (high, depth) = input.Aggregate( (h: 0, d: 0),
                (pos, cmd) => cmd switch {
                    ("forward", var x) => (pos.h + x, pos.d),
                    ("down", var x) => (pos.h, pos.d + x),
                    ("up", var x) => (pos.h, pos.d - x),
                    _ => pos
                });

            return $"{high * depth}";
        }

        private string ChallengeTwoSolver()
        {
            var input = LoadedFile.Select(x => x.Split(' '))
                                  .Select(x => (action: x[0], value: int.Parse(x[1])))
                                  .ToList();

            var (high, depth, _) = input.Aggregate( (h: 0, d: 0, aim: 0),
                (pos, cmd) => cmd switch  {
                    ("down", var x) => (pos.h, pos.d, pos.aim + x),
                    ("up", var x) => (pos.h, pos.d, pos.aim - x),
                    ("forward", var x) => (pos.h + x, pos.d + (pos.aim * x), pos.aim),
                    _ => pos  
                });

            return $"{high * depth}";
        }

        #endregion Private Methods
    }
}