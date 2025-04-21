using Solutions._2024;

namespace Tests;

[TestClass]
public class Test2024
{
    [DataTestMethod]
    [DataRow(typeof(Day01HistorianHysteria), "1319616", "27267728")]
    [DataRow(typeof(Day02RedNosedReports), "321", "386")]
    [DataRow(typeof(Day03MullItOver), "163931492", "76911921")]
    [DataRow(typeof(Day04CeresSearch), "2573", "1850")]
    public void CheckAllDays(Type dayType, string part1, string part2) =>
        Common.CheckDay(dayType, part1, part2);

    [DataTestMethod]
    [DataRow(typeof(Day01HistorianHysteria), "11", "31")]
    [DataRow(typeof(Day02RedNosedReports), "2", "4")]
    [DataRow(typeof(Day03MullItOver), "161", "48")]
    [DataRow(typeof(Day04CeresSearch), "18", "9")]
    public void CheckTestInputs(Type dayType, string part1, string part2) =>
        Common.CheckDay(dayType, part1, part2, true);
}
