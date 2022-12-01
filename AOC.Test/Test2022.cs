using AOC2022;
namespace AOC.Test;

[TestClass]
public class Test2022
{
    [DataTestMethod]
    [DataRow(typeof(Day01), "70509", "208567")]
    public void CheckAllDays(Type dayType, string part1, string part2)
    {
        Common.CheckDay(dayType, part1, part2);
    }
}