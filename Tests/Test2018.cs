using Solutions._2018;

namespace Tests;

public class Test2018
{
    [Test]
    [Arguments(typeof(Day01ChronalCalibration), "582", "488")]
    [Arguments(typeof(Day02InventoryManagementSystem), "5166", "cypueihajytordkgzxfqplbwn")]
    [Arguments(typeof(Day03NoMatterHowYouSliceIt), "119551", "1124")]
    public void CheckAllDays(Type dayType, string part1, string part2) =>
        _ = Common.CheckDay(dayType, part1, part2);
}
