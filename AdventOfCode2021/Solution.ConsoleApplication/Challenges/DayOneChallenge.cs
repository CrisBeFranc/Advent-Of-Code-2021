using System.IO;
using System.Linq;
using Solution.ConsoleApplication.Common;

namespace Solution.ConsoleApplication.Challenges
{
    public class DayOneChallenge : Challenge
    {
        public DayOneChallenge(string sourceFile)
        {
            ChallengeName = "Sonar Sweep";
            Day = 1;
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
            var input = LoadedFile.Select(int.Parse).ToList();
            return input.Where((num, index) => index > 0 && num > input[index - 1])
                        .Count()
                        .ToString();
        }

        private string ChallengeTwoSolver()
        {
            var input = LoadedFile.Select(int.Parse).ToList();
            return input.Where((num, index) => index > 0
                                               && index < input.Count - 2
                                               && num + input[index + 1] + input[index + 2] > input[index - 1] + num + input[index + 1])
                        .Count()
                        .ToString();
        }

        #endregion Private Methods
    }
}