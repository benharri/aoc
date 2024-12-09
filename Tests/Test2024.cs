using Solutions._2024;

namespace Tests;

[TestClass]
public class Test2024
{
    [DataTestMethod]
    [DataRow(typeof(Day01), "1319616", "27267728")]
    [DataRow(typeof(Day02), "321", "386")]
    [DataRow(typeof(Day03), "163931492", "76911921")]
    [DataRow(typeof(Day04), "2573", "1850")]
    public void CheckAllDays(Type dayType, string part1, string part2) =>
        Common.CheckDay(dayType, part1, part2);

    [DataTestMethod]
    [DataRow(typeof(Day01), "11", "31")]
    [DataRow(typeof(Day02), "2", "4")]
    [DataRow(typeof(Day03), "161", "48")]
    [DataRow(typeof(Day04), "18", "9")]
    public void CheckTestInputs(Type dayType, string part1, string part2) =>
        Common.CheckDay(dayType, part1, part2, true);
}
