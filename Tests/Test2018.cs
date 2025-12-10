using Solutions._2018;
// ReSharper disable MemberCanBeMadeStatic.Global

namespace Tests;

public class Test2018
{
    [Test]
    [RealInputRequired]
    [Arguments(typeof(Day01ChronalCalibration), "582", "488")]
    [Arguments(typeof(Day02InventoryManagementSystem), "5166", "cypueihajytordkgzxfqplbwn")]
    [Arguments(typeof(Day03NoMatterHowYouSliceIt), "119551", "1124")]
    public async Task CheckAllDays(Type dayType, string part1, string part2) =>
        await Common.CheckDay(dayType, part1, part2);
}
