using Solutions;

// ReSharper disable StringLiteralTypo

namespace Tests;

public class DayTests
{
    [Test, MethodDataSource<DayData>(nameof(DayData.GetData))]
    public async Task CheckAllDays(Day day, string part1, string part2)
    {
        if (!day.UseTestInput && !File.Exists(day.FileName)) Skip.Test("Real input unavailable");

        Util.TimeAndPrint(day.ProcessInput, "Input processing");

        // part 1
        await Assert.That(Util.TimeAndPrint(day.Part1, "P1")).IsEqualTo(part1).IgnoringWhitespace();

        // part 2
        await Assert.That(Util.TimeAndPrint(day.Part2, "P2")).IsEqualTo(part2).IgnoringWhitespace();
    }
}
