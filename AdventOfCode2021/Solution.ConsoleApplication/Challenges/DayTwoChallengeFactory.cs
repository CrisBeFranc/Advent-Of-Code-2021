using Solution.ConsoleApplication.Common;

namespace Solution.ConsoleApplication.Challenges
{
    public class DayTwoChallengeFactory : ChallengeFactory
    {
        private readonly string _sourceFile;

        public DayTwoChallengeFactory(string sourceFile)
        {
            _sourceFile = $"../../../../{sourceFile}";
        }

        public override Challenge GetChallenge()
        {
            return new DayTwoChallenge(_sourceFile);
        }
    }
}