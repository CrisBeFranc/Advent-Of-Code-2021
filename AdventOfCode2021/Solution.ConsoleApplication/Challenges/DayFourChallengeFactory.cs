using Solution.ConsoleApplication.Common;

namespace Solution.ConsoleApplication.Challenges
{
    public class DayFourChallengeFactory : ChallengeFactory
    {
        private readonly string _sourceFile;

        public DayFourChallengeFactory(string sourceFile)
        {
            _sourceFile = $"../../../../{sourceFile}";
        }

        public override Challenge GetChallenge()
        {
            return new DayFourChallenge(_sourceFile);
        }
    }
}