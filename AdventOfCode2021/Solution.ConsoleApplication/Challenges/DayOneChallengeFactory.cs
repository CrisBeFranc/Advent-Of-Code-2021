using Solution.ConsoleApplication.Common;

namespace Solution.ConsoleApplication.Challenges
{
    public class DayOneChallengeFactory : ChallengeFactory
    {
        private readonly string _sourceFile;

        public DayOneChallengeFactory(string sourceFile)
        {
            _sourceFile = $"../../../../{sourceFile}";
        }

        public override Challenge GetChallenge()
        {
            return new DayOneChallenge(_sourceFile);
        }
    }
}