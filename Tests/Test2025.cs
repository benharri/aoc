using Solutions._2025;

namespace Tests;

public class Test2025
{
    [Test]
    [Arguments(typeof(Day01SecretEntrance), "1105", "")]
    [Arguments(typeof(Day02GiftShop), "20223751480", "30260171216")]
    [Arguments(typeof(Day03Lobby), "17155", "")]
    [Arguments(typeof(Day04PrintingDepartment), "1419", "8739")]
    [Arguments(typeof(Day05Cafeteria), "756", "355555479253787")]
    [Arguments(typeof(Day06TrashCompactor), "6757749566978", "10603075273949")]
    [Arguments(typeof(Day07Laboratories), "1642", "47274292756692")]
    public async Task CheckAllDays(Type dayType, string part1, string part2) =>
        await Common.CheckDay(dayType, part1, part2);

    [Test]
    [Arguments(typeof(Day01SecretEntrance), "3", "6")]
    [Arguments(typeof(Day02GiftShop), "1227775554", "4174379265")]
    [Arguments(typeof(Day03Lobby), "357", "3121910778619")]
    [Arguments(typeof(Day04PrintingDepartment), "13", "43")]
    [Arguments(typeof(Day05Cafeteria), "3", "14")]
    [Arguments(typeof(Day06TrashCompactor), "4277556", "3263827")]
    [Arguments(typeof(Day07Laboratories), "21" , "40")]
    public async Task CheckTestInputs(Type dayType, string part1, string part2) =>
        await Common.CheckDay(dayType, part1, part2, true);
}
