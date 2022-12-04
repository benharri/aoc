using AOC2016;

namespace AOC.Test;

[TestClass]
public class Test2016
{
    [DataTestMethod]
    [DataRow(typeof(Day01), "", "")]
    public void CheckAllDays(Type dayType, string part1, string part2)
    {
        Common.CheckDay(dayType, part1, part2);
    }
}
