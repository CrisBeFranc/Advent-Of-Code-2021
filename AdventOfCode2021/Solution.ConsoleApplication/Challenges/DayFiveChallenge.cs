using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Solution.ConsoleApplication.Common;

namespace Solution.ConsoleApplication.Challenges
{
    public class DayFiveChallenge : Challenge
    {
        public DayFiveChallenge(string sourceFile)
        {
            ChallengeName = "Hydrothermal Venture";
            Day = 5;
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
            var coords = LoadedFile.Select(line => Regex.Split(line, @"[^\d]+")
                                                        .Select(int.Parse)
                                                        .ToArray())
                                   .Select(c => new { x1 = c[0], y1 = c[1], x2 = c[2], y2 = c[3] })                                   
                                   .ToArray();


            return coords.Where(x => x.x1 == x.x2 || x.y1 == x.y2)
                         .SelectMany(x => GetPointsForLine(x.x1, x.y1, x.x2, x.y2))
                         .GroupBy(x => x)       
                         .Where(g => g.Count() > 1)
                         .Count()
                         .ToString();
        }

        private string ChallengeTwoSolver()
        {
            var coords = LoadedFile.Select(line => Regex.Split(line, @"[^\d]+")
                                                        .Select(int.Parse)
                                                        .ToArray())
                                   .Select(c => new { x1 = c[0], y1 = c[1], x2 = c[2], y2 = c[3] })
                                   .ToArray();


            return coords.Where(x => true || x.x1 == x.x2 || x.y1 == x.y2)
                         .SelectMany(x => GetPointsForLine(x.x1, x.y1, x.x2, x.y2))
                         .GroupBy(x => x)
                         .Where(g => g.Count() > 1)
                         .Count()
                         .ToString();
        }

        private static IEnumerable<(int x, int y)> GetPointsForLine(int x1, int y1, int x2, int y2)
        {
            var xDir = Math.Sign(x2 - x1);            
            var yDir = Math.Sign(y2 - y1);

            for (int x = x1, y = y1; x != (x2 + xDir) || y != (y2 + yDir); x += xDir, y += yDir)
            {                
                yield return (x, y);
            }
        }

        #endregion Private Methods
    }
}