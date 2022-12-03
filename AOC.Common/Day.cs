namespace AOC.Common;

public abstract class Day
{
    protected Day(int year, int day, string puzzleName)
    {
        Year = year;
        DayNumber = day;
        PuzzleName = puzzleName;
    }

    public static bool UseTestInput { get; set; }

    public int Year { get; }
    public int DayNumber { get; }
    public string PuzzleName { get; }

    protected IEnumerable<string> Input =>
        File.ReadLines(FileName);

    public string FileName =>
        Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
            $"input{Year}/{(UseTestInput ? "test" : "day")}{DayNumber,2:00}.in");

    public abstract object Part1();
    public abstract object Part2();

    private void AllParts(bool verbose = true)
    {
        Console.WriteLine($"{Year} Day {DayNumber,2}: {PuzzleName}");
        var s = Stopwatch.StartNew();
        var part1 = Part1();
        s.Stop();
        Console.Write($"Part 1: {part1,-25} ");
        Console.WriteLine(verbose ? $"{s.ScaleMilliseconds()}ms elapsed" : "");

        s.Reset();

        s.Start();
        var part2 = Part2();
        s.Stop();
        Console.Write($"Part 2: {part2,-25} ");
        Console.WriteLine(verbose ? $"{s.ScaleMilliseconds()}ms elapsed" : "");

        Console.WriteLine();
    }

    public static void RunFromArgs(string[] args)
    {
        var days = Assembly.GetEntryAssembly()?.GetTypes()
            .Where(t => t.BaseType == typeof(Day))
            .Select(t => (Activator.CreateInstance(t) as Day)!)
            .OrderBy(d => d.DayNumber)
            .ToList();

        if (days == null || !days.Any())
        {
            throw new ApplicationException("no days found");
        }
            

        if (args.Length == 1 && int.TryParse(args[0], out var dayNum))
        {
            var day = days.FirstOrDefault(d => d.DayNumber == dayNum);
            if (day != null) day.AllParts();
            else Console.WriteLine($"Day {dayNum} invalid or not yet implemented");
        }
        else
        {
            foreach (var d in days) d.AllParts();
        }
    }
}
