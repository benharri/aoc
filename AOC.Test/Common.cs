namespace AOC.Test;

public static class Common
{
    public static void CheckDay(Type dayType, string part1, string part2, bool testInput = false)
    {
        Day.UseTestInput = testInput;
        var day = Activator.CreateInstance(dayType) as Day;
        
        Assert.IsNotNull(day, "Failed to instantiate day object");
        Assert.IsTrue(File.Exists(day.FileName), $"File.Exists(day.FileName) {day.FileName}");

        var s = Stopwatch.StartNew();
        day.ProcessInput();
        s.Stop();
        
        Console.WriteLine(
            $"{day.Year} Day {day.DayNumber,2}: {day.PuzzleName,-40} {s.ScaleMilliseconds()} ms elapsed processing input");

        // part 1
        s.Restart();
        var part1Actual = day.Part1();
        s.Stop();
        Console.WriteLine($"Part 1: {part1Actual,-45} {s.ScaleMilliseconds()} ms elapsed");
        Assert.AreEqual(part1, part1Actual.ToString(), $"Incorrect answer for Day {day.DayNumber} Part 1");

        // part 2
        s.Restart();
        var part2Actual = day.Part2();
        s.Stop();
        Console.WriteLine($"Part 2: {part2Actual,-45} {s.ScaleMilliseconds()} ms elapsed");
        Assert.AreEqual(part2, part2Actual.ToString(), $"Incorrect answer for Day {day.DayNumber} Part 2");
    }
}