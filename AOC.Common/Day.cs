namespace AOC.Common;

public abstract class Day(int year, int day, string puzzleName)
{
    public static bool UseTestInput { get; set; }

    public int Year { get; } = year;
    public int DayNumber { get; } = day;
    public string PuzzleName { get; } = puzzleName;

    protected IEnumerable<string> Input =>
        File.ReadLines(FileName);

    public string FileName =>
        Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
            $"input{Year}/{(UseTestInput ? "test" : "day")}{DayNumber,2:00}.in");

    public abstract void ProcessInput();

    public abstract object Part1();
    public abstract object Part2();

    private void PrintDay(bool showTiming = true)
    {
        Console.Write($"{Year} Day {DayNumber,2}: {PuzzleName,-40} ");

        var s = Stopwatch.StartNew();
        ProcessInput();
        s.Stop();

        Console.WriteLine(showTiming ? $"{s.ScaleMilliseconds()}ms elapsed processing input" : "");

        s.Reset();

        s.Start();
        var part1 = Part1();
        s.Stop();
        Console.Write($"Part 1: {part1,-45} ");

        Console.WriteLine(showTiming ? $"{s.ScaleMilliseconds()}ms elapsed" : "");

        s.Reset();

        s.Start();
        var part2 = Part2();
        s.Stop();
        Console.Write($"Part 2: {part2,-45} ");

        Console.WriteLine(showTiming ? $"{s.ScaleMilliseconds()}ms elapsed" : "");

        Console.WriteLine();
    }

    public static void RunFromArgs(string[] args)
    {
        var days = Assembly.GetEntryAssembly()?.GetTypes()
            .Where(t => t.BaseType == typeof(Day))
            .Select(t => (Activator.CreateInstance(t) as Day)!)
            .OrderBy(d => d.DayNumber)
            .ToList();

        if (days == null || days.Count == 0)
        {
            throw new ApplicationException("no days found");
        }

        UseTestInput = args.Contains("--test");
        var verbose = args.Contains("--verbose");

        if (args.Length > 0 && int.TryParse(args[0], out var dayNum))
        {
            var day = days.FirstOrDefault(d => d.DayNumber == dayNum);
            if (day != null) day.PrintDay(verbose);
            else throw new ApplicationException($"Day {dayNum} invalid or not yet implemented");
        }
        else
        {
            foreach (var d in days) d.PrintDay(verbose);
        }
    }
}