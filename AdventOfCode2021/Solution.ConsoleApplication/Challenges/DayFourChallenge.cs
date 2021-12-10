using System;
using System.IO;
using System.Linq;
using Solution.ConsoleApplication.Common;

namespace Solution.ConsoleApplication.Challenges
{
    public class DayFourChallenge : Challenge
    {
        public DayFourChallenge(string sourceFile)
        {
            ChallengeName = "Giant Squid";
            Day = 4;
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
            var bingoNumbers = LoadedFile[0].Split(',').Select(int.Parse).ToArray();

            var winners = LoadedFile.Skip(1)
                                    .Where(l => l != string.Empty)
                                    .Select(l => l.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                                  .Select(int.Parse)
                                                  .ToArray())
                                    .Chunk(5)
                                    .Select(board => (board, drawIdx: board.Concat(Enumerable.Range(0, 5).Select(c => board.Select(r => r[c])))
                                                                           .Select(r => r.Select(x => Array.IndexOf(bingoNumbers, x)).Max())
                                                                           .Min()))
                                    .OrderBy(t => t.drawIdx).ToArray();


            var scores = new[] { winners.First(), winners.Last() }
                                .Select(t => t.board.SelectMany(r => r)
                                                    .Where(x => !bingoNumbers.Take(t.drawIdx + 1)
                                                                             .Contains(x))                          
                                                    .Sum() * bingoNumbers[t.drawIdx])
                                .ToList();            

            return scores[0].ToString();
        }

        private string ChallengeTwoSolver()
        {
            var bingoNumbers = LoadedFile[0].Split(',').Select(int.Parse).ToArray();

            var winners = LoadedFile.Skip(1)
                                    .Where(l => l != string.Empty)
                                    .Select(l => l.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                                  .Select(int.Parse)
                                                  .ToArray())
                                    .Chunk(5)
                                    .Select(board => (board, drawIdx: board.Concat(Enumerable.Range(0, 5).Select(c => board.Select(r => r[c])))
                                                                           .Select(r => r.Select(x => Array.IndexOf(bingoNumbers, x)).Max())
                                                                           .Min()))
                                    .OrderBy(t => t.drawIdx).ToArray();


            var scores = new[] { winners.First(), winners.Last() }
                                .Select(t => t.board.SelectMany(r => r)
                                                    .Where(x => !bingoNumbers.Take(t.drawIdx + 1)
                                                                             .Contains(x))
                                                    .Sum() * bingoNumbers[t.drawIdx])
                                .ToList();

            return scores[1].ToString();
        }

        #endregion Private Methods
    }
}