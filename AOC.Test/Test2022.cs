using AOC2022;
namespace AOC.Test;

[TestClass]
public class Test2022
{
    [DataTestMethod]
    [DataRow(typeof(Day01), "70509", "208567")]
    [DataRow(typeof(Day02), "11449", "13187")]
    [DataRow(typeof(Day03), "7917", "")]
    public void CheckAllDays(Type dayType, string part1, string part2)
    {
        Common.CheckDay(dayType, part1, part2);
    }

    [DataTestMethod]
    [DataRow(typeof(Day01), "24000", "45000")]
    [DataRow(typeof(Day02), "15", "12")]
    [DataRow(typeof(Day03), "157", "70")]
    public void TestAllDays(Type dayType, string part1, string part2)
    {
        Day.UseTestInput = true;
        Common.CheckDay(dayType, part1, part2);
        Day.UseTestInput = false;
    }
}