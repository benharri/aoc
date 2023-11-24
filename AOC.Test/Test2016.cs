using AOC2016;

namespace AOC.Test;

[TestClass]
public class Test2016
{
    [DataTestMethod]
    [DataRow(typeof(Day01), "300", "159")]
    [DataRow(typeof(Day02), "76792", "A7AC3")]
    [DataRow(typeof(Day03), "993", "")]
    public void CheckAllDays(Type dayType, string part1, string part2)
    {
        Common.CheckDay(dayType, part1, part2);
    }

    [DataTestMethod]
    [DataRow(typeof(Day02), "1985", "5DB3")]
    public void CheckTestInputs(Type dayType, string part1, string part2)
    {
        Common.CheckDay(dayType, part1, part2, true);
    }
}
