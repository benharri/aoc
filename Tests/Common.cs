using Solutions;

[assembly: Parallelize(Workers = 0, Scope = ExecutionScope.ClassLevel)]
namespace Tests;

public static class Common
{
    /// <summary>
    /// Asserts expected solutions for a given day.
    /// </summary>
    /// <param name="dayType">The derived day class</param>
    /// <param name="part1">Correct part 1 solution</param>
    /// <param name="part2">Correct part 2 solution</param>
    /// <param name="testInput">Correct answers are for the test input</param>
    public static void CheckDay(Type dayType, string part1, string part2, bool testInput = false)
    {
        Day.UseTestInput = testInput;
        
        var day = Activator.CreateInstance(dayType) as Day;
        Assert.IsNotNull(day, "Failed to instantiate day object");
        Assert.IsTrue(File.Exists(day.FileName), $"File.Exists(day.FileName) {day.FileName}");

        day.PrintProcessInput();

        // part 1
        var part1Actual = day.PrintPart1();
        Assert.AreEqual(part1, part1Actual.ToString(), $"Incorrect answer for {day} Part 1");

        // part 2
        var part2Actual = day.PrintPart2();
        Assert.AreEqual(part2, part2Actual.ToString(), $"Incorrect answer for {day} Part 2");
    }
}
