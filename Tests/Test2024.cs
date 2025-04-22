using Solutions._2024;

namespace Tests;

public class Test2024
{
    [Test]
    [Arguments(typeof(Day01HistorianHysteria), "1319616", "27267728")]
    [Arguments(typeof(Day02RedNosedReports), "321", "386")]
    [Arguments(typeof(Day03MullItOver), "163931492", "76911921")]
    [Arguments(typeof(Day04CeresSearch), "2573", "1850")]
    public void CheckAllDays(Type dayType, string part1, string part2) =>
        _ = Common.CheckDay(dayType, part1, part2);

    [Test]
    [Arguments(typeof(Day01HistorianHysteria), "11", "31")]
    [Arguments(typeof(Day02RedNosedReports), "2", "4")]
    [Arguments(typeof(Day03MullItOver), "161", "48")]
    [Arguments(typeof(Day04CeresSearch), "18", "9")]
    public void CheckTestInputs(Type dayType, string part1, string part2) =>
        _ = Common.CheckDay(dayType, part1, part2, true);
}
