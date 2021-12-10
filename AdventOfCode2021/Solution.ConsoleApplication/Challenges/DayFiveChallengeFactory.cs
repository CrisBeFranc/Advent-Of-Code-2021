using Solution.ConsoleApplication.Common;

namespace Solution.ConsoleApplication.Challenges
{
    public class DayFiveChallengeFactory : ChallengeFactory
    {
        private readonly string _sourceFile;

        public DayFiveChallengeFactory(string sourceFile)
        {
            _sourceFile = $"../../../../{sourceFile}";
        }

        public override Challenge GetChallenge()
        {
            return new DayFiveChallenge(_sourceFile);
        }
    }
}