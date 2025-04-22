using Solutions._2023;
// ReSharper disable MemberCanBeMadeStatic.Global

namespace Tests;

public class Test2023
{
    [Test]
    [Arguments(typeof(Day01Trebuchet), "54331", "54518")]
    [Arguments(typeof(Day02CubeConundrum), "2476", "54911")]
    [Arguments(typeof(Day03GearRatios), "522726", "81721933")]
    [Arguments(typeof(Day04Scratchcards), "20117", "13768818")]
    [Arguments(typeof(Day06WaitForIt), "505494", "23632299")]
    [Arguments(typeof(Day07CamelCards), "250370104", "251735672")]
    public async Task CheckAllDays(Type dayType, string part1, string part2) =>
        await Common.CheckDay(dayType, part1, part2);

    [Test]
    [Arguments(typeof(Day01Trebuchet), "142", "142")] // unfortunately p2 example is different
    [Arguments(typeof(Day02CubeConundrum), "8", "2286")]
    [Arguments(typeof(Day03GearRatios), "4361", "467835")]
    [Arguments(typeof(Day04Scratchcards), "13", "30")]
    [Arguments(typeof(Day06WaitForIt), "288", "71503")]
    [Arguments(typeof(Day07CamelCards), "6440", "5905")]
    public async Task CheckTestInputs(Type dayType, string part1, string part2) =>
        await Common.CheckDay(dayType, part1, part2, true);
}
