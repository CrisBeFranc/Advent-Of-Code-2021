using Solution.ConsoleApplication.Common;

namespace Solution.ConsoleApplication.Challenges
{
    public class DayThreeChallengeFactory : ChallengeFactory
    {
        private readonly string _sourceFile;

        public DayThreeChallengeFactory(string sourceFile)
        {
            _sourceFile = $"../../../../{sourceFile}";
        }

        public override Challenge GetChallenge()
        {
            return new DayThreeChallenge(_sourceFile);
        }
    }
}