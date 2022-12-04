namespace AOC.Test;

public static class Common
{
    public static void CheckDay(Type dayType, string part1, string part2)
    {
        var s = Stopwatch.StartNew();
        var day = Activator.CreateInstance(dayType) as Day;
        s.Stop();
        Assert.IsNotNull(day, "failed to instantiate day object");
        Assert.IsTrue(File.Exists(day.FileName), $"File.Exists(day.FileName) {day.FileName}");
        Console.Write($"{day.Year} Day {day.DayNumber,2}: {day.PuzzleName,-25} ");
        Console.WriteLine($"{s.ScaleMilliseconds()} ms elapsed in constructor");

        // part 1
        s.Reset();
        s.Start();
        var part1Actual = day.Part1().ToString();
        s.Stop();
        Console.Write($"Part 1: {part1Actual,-30} ");
        Console.WriteLine($"{s.ScaleMilliseconds()} ms elapsed");
        Assert.AreEqual(part1, part1Actual, $"Incorrect answer for Day {day.DayNumber} Part1");

        // part 2
        s.Reset();
        s.Start();
        var part2Actual = day.Part2().ToString();
        s.Stop();
        Console.Write($"Part 2: {part2Actual,-30} ");
        Console.WriteLine($"{s.ScaleMilliseconds()} ms elapsed");
        Assert.AreEqual(part2, part2Actual, $"Incorrect answer for Day {day.DayNumber} Part2");
    }
}
