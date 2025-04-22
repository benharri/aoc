using Solutions;

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
    public static async Task CheckDay(Type dayType, string part1, string part2, bool testInput = false)
    {
        Day.UseTestInput = testInput;

        var day = Activator.CreateInstance(dayType) as Day;
        await Assert.That(day).IsNotNull();
        await Assert.That(File.Exists(day!.FileName)).IsTrue();

        day.PrintProcessInput();

        // part 1
        var part1Actual = day.PrintPart1();
        await Assert.That(part1Actual).IsEqualTo(part1);
        //Assert.AreEqual(part1, part1Actual.ToString(), $"Incorrect answer for {day} Part 1");

        // part 2
        var part2Actual = day.PrintPart2();
        await Assert.That(part2Actual).IsEqualTo(part2);
    }
}
