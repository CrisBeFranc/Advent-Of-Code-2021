﻿using System;
using BetterConsoleTables;
using Solution.ConsoleApplication.Challenges;
using Solution.ConsoleApplication.Common;

try
{
    // Day One Challenge
    ChallengeFactory factory = new DayOneChallengeFactory("Files/day_one.txt");
    Challenge dayOne = factory.GetChallenge();

    ColumnHeader[] headers = new[]
    {
        new ColumnHeader("Day"),
        new ColumnHeader("Challenge"),
        new ColumnHeader("Result Challenge One"),
        new ColumnHeader("Result Challenge Two")
    };

    Table table = new Table(headers)
        .AddRow(dayOne.Day, dayOne.ChallengeName, dayOne.ChallengeOne, dayOne.ChallengeTwo);

    table.Config = TableConfiguration.UnicodeAlt();
    Console.Write(table.ToString());
}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}

Console.Write($"{Environment.NewLine}Press any key to exit...");
Console.ReadKey(true);