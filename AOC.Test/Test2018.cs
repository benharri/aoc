using AOC2018;

namespace AOC.Test;

[TestClass]
public class Test2018
{
    [DataTestMethod]
    [DataRow(typeof(Day01), "582", "488")]
    [DataRow(typeof(Day02), "5166", "cypueihajytordkgzxfqplbwn")]
    [DataRow(typeof(Day03), "119551", "1124")]
    public void CheckAllDays(Type dayType, string part1, string part2)
    {
        Common.CheckDay(dayType, part1, part2);
    }
}
