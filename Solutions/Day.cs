using CommandLine;
using Microsoft.Extensions.Configuration;
using System.Net.Http;

// ReSharper disable MemberCanBeProtected.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable StringLiteralTypo

namespace Solutions;

/// <summary>
/// Base class for a day's solution. Provides stopwatch timing and command line parsing.
/// </summary>
/// <param name="year">Puzzle year</param>
/// <param name="day">Puzzle day</param>
/// <param name="puzzleName">Puzzle name</param>
public abstract class Day(int year, int day, string puzzleName)
{
    private static readonly HttpClient HttpClient = new() { BaseAddress = new("https://adventofcode.com") };
    private static readonly string Cookie = new ConfigurationBuilder().AddUserSecrets<Day>().Build()["SessionCookie"] ?? "";

    private static List<Day> GetAllDays() =>
        Assembly.GetEntryAssembly()!.GetTypes()
            .Where(t => t.BaseType == typeof(Day))
            .Select(t => (Activator.CreateInstance(t) as Day)!)
            .ToList();

    /// <summary>
    /// The year this Day is from.
    /// </summary>
    public int Year { get; } = year;

    /// <summary>
    /// What day it is.
    /// </summary>
    public int DayNumber { get; } = day;

    /// <summary>
    /// The name of the puzzle.
    /// </summary>
    public string PuzzleName { get; } = puzzleName;

    /// <summary>
    /// Enumerable of all lines in the input file.
    /// </summary>
    public IEnumerable<string> Input => File.ReadLines(FileName);

    /// <summary>
    /// Path to the input file in the format of "inputYEAR/dayNN.in".
    /// </summary>
    public string FileName =>
        UseTestInput
            ? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"input/{Year}/test{DayNumber:00}.in")
            : Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                $"Sync/Notes/aocinput/{Year}/day{DayNumber:00}.in");

    /// <summary>Download puzzle input from adventofcode.com for the current day</summary>
    public void SaveInput()
    {
        if (UseTestInput || File.Exists(FileName)) return;

        ArgumentException.ThrowIfNullOrWhiteSpace(Cookie);
        HttpRequestMessage req = new(HttpMethod.Get, $"/{Year}/day/{DayNumber}/input");
        req.Headers.Add("Cookie", $"session={Cookie}");
        var response = HttpClient.Send(req);
        response.Content.ReadAsStream().CopyTo(new FileStream(FileName, FileMode.CreateNew));
    }

    /// <summary>
    /// A toggle to read the test input file instead of the real input.
    /// </summary>
    public bool UseTestInput { get; set; }

    public override string ToString() => $"{Year}.{DayNumber:00}: {PuzzleName}";

    /// <summary>
    /// Initial parsing of the puzzle input. To be overridden by derived solution classes.
    /// </summary>
    public virtual void ProcessInput()
    {
    }

    /// <summary>
    /// Solve Part 1.
    /// </summary>
    /// <returns>object whose string representation will be the answer</returns>
    public abstract object Part1();

    /// <summary>
    /// Solve Part 2.
    /// </summary>
    /// <returns>object whose string representation will be the answer</returns>
    public abstract object Part2();


    private void PrintDay()
    {
        SaveInput();
        Util.TimeAndPrint(ProcessInput, this.ToString());
        Util.TimeAndPrint(Part1, "P1");
        Util.TimeAndPrint(Part2, "P2");
        Console.WriteLine();
    }

    // ReSharper disable once ClassNeverInstantiated.Local
    // ReSharper disable UnusedAutoPropertyAccessor.Local
    private class Options
    {
        [Option('t', "test", Required = false, Default = false, HelpText = "Use test input for the given day")]
        public bool TestInput { get; set; }

        [Option('a', "all", Required = false, Default = false,
            HelpText = "Run all available days. Overrides day and part.")]
        public bool RunAllDays { get; set; }

        [Value(0, MetaName = "Year Number", HelpText = "Which Year to run")]
        public int YearNumber { get; set; }

        [Value(1, MetaName = "Day Number", HelpText = "Which Day to run")]
        public int DayNumber { get; set; }

        [Value(2, MetaName = "Part", HelpText = "Which Part to run")]
        public int? PartNumber { get; set; }
    }

    /// <summary>
    /// Parse the command line args and run the appropriate puzzles.
    /// </summary>
    /// <param name="args"></param>
    /// <exception cref="ApplicationException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static void RunFromArgs(string[] args)
    {
        Parser.Default.ParseArguments<Options>(args).WithParsed(options =>
        {
            var days = GetAllDays();
            if (days.All(d => d.Year != options.YearNumber))
                throw new ApplicationException(
                    $"Invalid year. Available years: {days.Select(d => d.Year).Distinct().OrderBy(d => d).Join(", ")}");

            if (options.RunAllDays)
            {
                foreach (var day in days.Where(d => d.Year == options.YearNumber).OrderBy(d => d.DayNumber))
                {
                    day.UseTestInput = options.TestInput;
                    day.PrintDay();
                }
            }
            else
            {
                var day = days.SingleOrDefault(d => d.DayNumber == options.DayNumber && d.Year == options.YearNumber) ??
                          throw new ApplicationException($"Day {options.DayNumber} not yet implemented.");

                day.UseTestInput = options.TestInput;

                day.SaveInput();

                Util.TimeAndPrint(day.ProcessInput, day.ToString());

                if (options.PartNumber.HasValue)
                {
                    switch (options.PartNumber)
                    {
                        case 1:
                            Util.TimeAndPrint(day.Part1);
                            break;
                        case 2:
                            Util.TimeAndPrint(day.Part2);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(args),
                                $"{options.PartNumber} is not a valid part. Must be 1 or 2.");
                    }
                }
                else
                {
                    Util.TimeAndPrint(day.Part1);
                    Util.TimeAndPrint(day.Part2);
                }
            }
        }).WithNotParsed(errors =>
        {
            foreach (var err in errors) Console.WriteLine(err);
        });
    }

    public static void RunAllYears()
    {
        foreach (var day in GetAllDays().OrderBy(d => d.Year).ThenBy(d => d.DayNumber))
            day.PrintDay();
    }
}
