using CommandLine;
// ReSharper disable MemberCanBeProtected.Global
// ReSharper disable MemberCanBePrivate.Global

namespace AOC.Common;

/// <summary>
/// Base class for a day's solution. Provides stopwatch timing and command line parsing.
/// </summary>
/// <param name="year">Puzzle year</param>
/// <param name="day">Puzzle day</param>
/// <param name="puzzleName">Puzzle name</param>
public abstract class Day(int year, int day, string puzzleName)
{
    private readonly Stopwatch _stopwatch = new();

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
        Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
            $"input{Year}/{(UseTestInput ? "test" : "day")}{DayNumber:00}.in");

    /// <summary>
    /// A toggle to read the test input file instead of the real input.
    /// </summary>
    public static bool UseTestInput { get; set; }

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

    /// <summary>
    /// Runs <see cref="ProcessInput"/> and prints timing information to the console.
    /// </summary>
    public void PrintProcessInput()
    {
        _stopwatch.Restart();
        ProcessInput();
        _stopwatch.Stop();

        Console.WriteLine($"{this,-59} {_stopwatch.ScaleMilliseconds():00.0000}ms");
    }

    /// <summary>
    /// Runs the <see cref="Part1"/> solver with timings and prints the result to the console.
    /// </summary>
    public object PrintPart1()
    {
        _stopwatch.Restart();
        var part1 = Part1();
        _stopwatch.Stop();

        Console.WriteLine($"P1: {part1,-55} {_stopwatch.ScaleMilliseconds():00.0000}ms");
        return part1;
    }

    /// <summary>
    /// Runs the <see cref="Part2"/> solver with timings and prints the result to the console.
    /// </summary>
    public object PrintPart2()
    {
        _stopwatch.Restart();
        var part2 = Part2();
        _stopwatch.Stop();

        Console.WriteLine($"P2: {part2,-55} {_stopwatch.ScaleMilliseconds():00.0000}ms");
        return part2;
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

        [Value(0, MetaName = "Day Number", HelpText = "Which Day to run")]
        public int DayNumber { get; set; }

        [Value(1, MetaName = "Part", HelpText = "Which Part to run")]
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
        var days = Assembly.GetEntryAssembly()?.GetTypes()
            .Where(t => t.BaseType == typeof(Day))
            .Select(t => (Activator.CreateInstance(t) as Day)!)
            .OrderBy(d => d.DayNumber)
            .ToList();

        if (days == null || days.Count == 0)
            throw new ApplicationException("no days found");

        Parser.Default.ParseArguments<Options>(args).WithParsed(options =>
        {
            UseTestInput = options.TestInput;

            if (options.RunAllDays)
            {
                foreach (var day in days)
                {
                    day.PrintProcessInput();
                    day.PrintPart1();
                    day.PrintPart2();
                    Console.WriteLine();
                }
            }
            else
            {
                if (options.DayNumber is < 1 or > 25)
                    throw new ArgumentOutOfRangeException(nameof(args),
                        $"{options.DayNumber} is not a valid advent day. Must be between 1 and 25.");

                var day = days.SingleOrDefault(d => d.DayNumber == options.DayNumber) ??
                          throw new ApplicationException($"Day {options.DayNumber} not yet implemented");

                day.PrintProcessInput();

                if (options.PartNumber.HasValue)
                {
                    switch (options.PartNumber)
                    {
                        case 1: day.PrintPart1(); break;
                        case 2: day.PrintPart2(); break;
                        default: throw new ArgumentOutOfRangeException(nameof(args),
                            $"{options.PartNumber} is not a valid part. Must be 1 or 2.");
                    }
                }
                else
                {
                    day.PrintPart1();
                    day.PrintPart2();
                }
            }
        }).WithNotParsed(errors =>
        {
            foreach (var err in errors) Console.WriteLine(err);
        });
    }
}
