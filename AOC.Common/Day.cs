using CommandLine;

namespace AOC.Common;

public abstract class Day(int year, int day, string puzzleName)
{
    public int Year { get; } = year;
    public int DayNumber { get; } = day;
    public string PuzzleName { get; } = puzzleName;

    protected string[] Input => File.ReadAllLines(FileName);

    public string FileName =>
        Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
            $"input{Year}/{(UseTestInput ? "test" : "day")}{DayNumber,2:00}.in");

    public static bool UseTestInput { get; set; }
    private readonly Stopwatch _stopwatch = new();

    public abstract void ProcessInput();
    public abstract object Part1();
    public abstract object Part2();

    private void PrintProcessInput()
    {
        _stopwatch.Restart();
        ProcessInput();
        _stopwatch.Stop();
        Console.WriteLine(
            $"{Year} Day {DayNumber,2}: {PuzzleName,-40} {_stopwatch.ScaleMilliseconds()}ms elapsed processing input");
    }

    private void PrintPart1()
    {
        _stopwatch.Restart();
        var part1 = Part1();
        _stopwatch.Stop();

        Console.WriteLine($"Part 1: {part1,-45} {_stopwatch.ScaleMilliseconds()}ms elapsed");
    }

    private void PrintPart2()
    {
        _stopwatch.Restart();
        var part2 = Part2();
        _stopwatch.Stop();

        Console.WriteLine($"Part 2: {part2,-45} {_stopwatch.ScaleMilliseconds()}ms elapsed");
    }

    private class Options
    {
        [Option('t', "test", Required = false, Default = false, HelpText = "Use test input for the given day")]
        public bool TestInput { get; set; }

        [Option('a', "all", Required = false, Default = false, HelpText = "Run all available days. Overrides day and part.")]
        public bool RunAllDays { get; set; }

        [Value(0, MetaName = "Day Number", HelpText = "Which Day to run")]
        public int DayNumber { get; set; }

        [Value(1, MetaName = "Part", HelpText = "Which Part to run")]
        public int? PartNumber { get; set; }
    }

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
                var day = days.SingleOrDefault(d => d.DayNumber == options.DayNumber);
                if (day != null)
                {
                    day.PrintProcessInput();
                    if (options.PartNumber.HasValue)
                    {
                        switch (options.PartNumber)
                        {
                            case 1:
                                day.PrintPart1();
                                break;
                            case 2:
                                day.PrintPart2();
                                break;
                            default:
                                throw new ArgumentOutOfRangeException(nameof(args));
                        }
                    }
                    else
                    {
                        day.PrintPart1();
                        day.PrintPart2();
                    }

                    Console.WriteLine();

                }
                else throw new ApplicationException($"Day {options.DayNumber} invalid or not yet implemented");
            }
        }).WithNotParsed(errors =>
        {
            foreach (var err in errors) Console.WriteLine(err);
        });
    }
}
