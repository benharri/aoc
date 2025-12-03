using Solutions._2025;

namespace Tests;

public class Test2025
{
    [Test]
    [Arguments(typeof(Day01SecretEntrance), "1105", "5375")]
    [Arguments(typeof(Day02GiftShop), "20223751480", "30260171216")]
    [Arguments(typeof(Day03Lobby), "17155", "")]
    public async Task CheckAllDays(Type dayType, string part1, string part2) =>
        await Common.CheckDay(dayType, part1, part2);

    [Test]
    [Arguments(typeof(Day01SecretEntrance), "3", "6")]
    [Arguments(typeof(Day02GiftShop), "1227775554", "4174379265")]
    [Arguments(typeof(Day03Lobby), "357", "3121910778619")]
    public async Task CheckTestInputs(Type dayType, string part1, string part2) =>
        await Common.CheckDay(dayType, part1, part2, true);
}
