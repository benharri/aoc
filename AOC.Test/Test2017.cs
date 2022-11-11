using AOC2017;

namespace AOC.Test;

[TestClass]
public class Test2017
{
    [DataTestMethod]
    [DataRow(typeof(Day01), "", "")]
    public void TestAllDays(Type dayType, string part1, string part2)
    {
        Common.CheckDay(dayType, part1, part2);
    }
}