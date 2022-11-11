using AOC2015;

namespace AOC.Test;

[TestClass]
public class Test2015
{
    [DataTestMethod]
    [DataRow(typeof(Day01), "232", "1783")]
    [DataRow(typeof(Day02),"1586300", "3737498")]
    public void TestAllDays(Type dayType, string part1, string part2)
    {
        Common.CheckDay(dayType, part1, part2);
    }

    [DataTestMethod]
    [DataRow(typeof(Day02), "58", "34")]
    public void CheckTestInputs(Type dayType, string part1, string part2)
    {
        Day.UseTestInput = true;
        Common.CheckDay(dayType, part1, part2);
        Day.UseTestInput = false;
    }
}