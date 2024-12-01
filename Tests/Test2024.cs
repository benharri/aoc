using Solutions._2024;
namespace Tests;

[TestClass]
public class Test2024
{
    [DataTestMethod]
    [DataRow(typeof(Day01), "1319616", "27267728")]
    public void CheckAllDays(Type dayType, string part1, string part2) =>
        Common.CheckDay(dayType, part1, part2);
    
    [DataTestMethod]
    [DataRow(typeof(Day01), "11", "31")]
    public void CheckTestInputs(Type dayType, string part1, string part2) =>
        Common.CheckDay(dayType, part1, part2, true);
}