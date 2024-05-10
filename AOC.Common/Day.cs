using CommandLine;

namespace AOC.Common;

/// <summary>
/// Base class for a day's solution. Provides stopwatch timing and command line parsing.
/// </summary>
/// <param name="year"></param>
/// <param name="day"></param>
/// <param name="puzzleName"></param>
public abstract class Day(int year, int day, string puzzleName)
{
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
    protected IEnumerable<string> Input => File.ReadLines(FileName);

    /// <summary>
    /// Path to the input file in the format of "inputYEAR/dayNN.in".
    /// </summary>
    public string FileName =>
        Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
            $"input{Year}/{(UseTestInput ? "test" : "day")}{DayNumber,2:00}.in");

    /// <summary>
    /// A toggle to read the test input file instead of the real input.
    /// </summary>
    public static bool UseTestInput { get; set; }

    private readonly Stopwatch _stopwatch = new();

    /// <summary>
    /// Initial parsing of the puzzle input.
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
    private void PrintProcessInput()
    {
        _stopwatch.Restart();
        ProcessInput();
        _stopwatch.Stop();

        Console.WriteLine(
            $"{Year} Day {DayNumber,2}: {PuzzleName,-40} {_stopwatch.ScaleMilliseconds()}ms elapsed processing input");
    }

    /// <summary>
    /// Runs the <see cref="Part1"/> solver with timings and prints the result to the console.
    /// </summary>
    private void PrintPart1()
    {
        _stopwatch.Restart();
        var part1 = Part1();
        _stopwatch.Stop();

        Console.WriteLine($"Part 1: {part1,-45} {_stopwatch.ScaleMilliseconds()}ms elapsed");
    }

    /// <summary>
    /// Runs the <see cref="Part2"/> solver with timings and prints the result to the console.
    /// </summary>
    private void PrintPart2()
    {
        _stopwatch.Restart();
        var part2 = Part2();
        _stopwatch.Stop();

        Console.WriteLine($"Part 2: {part2,-45} {_stopwatch.ScaleMilliseconds()}ms elapsed");
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
                          throw new NotImplementedException($"Day {options.DayNumber} not yet implemented");

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
