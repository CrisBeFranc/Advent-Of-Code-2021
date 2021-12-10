using Solution.ConsoleApplication.Common;

namespace Solution.ConsoleApplication.Challenges
{
    public class DaySixChallengeFactory : ChallengeFactory
    {
        private readonly string _sourceFile;

        public DaySixChallengeFactory(string sourceFile)
        {
            _sourceFile = $"../../../../{sourceFile}";
        }

        public override Challenge GetChallenge()
        {
            return new DaySixChallenge(_sourceFile);
        }
    }
}