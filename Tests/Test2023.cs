using Solutions._2023;

namespace Tests;

[TestClass]
public class Test2023
{
    [DataTestMethod]
    [DataRow(typeof(Day01), "54331", "54518")]
    [DataRow(typeof(Day02), "2476", "54911")]
    [DataRow(typeof(Day03), "522726", "81721933")]
    [DataRow(typeof(Day04), "20117", "13768818")]
    [DataRow(typeof(Day06), "505494", "23632299")]
    [DataRow(typeof(Day07), "250370104", "251735672")]
    public void CheckAllDays(Type dayType, string part1, string part2) =>
        Common.CheckDay(dayType, part1, part2);

    [DataTestMethod]
    [DataRow(typeof(Day01), "142", "142")] // unfortunately p2 example is different
    [DataRow(typeof(Day02), "8", "2286")]
    [DataRow(typeof(Day03), "4361", "467835")]
    [DataRow(typeof(Day04), "13", "30")]
    // [DataRow(typeof(Day05), "35", "")]
    [DataRow(typeof(Day06), "288", "71503")]
    [DataRow(typeof(Day07), "6440", "5905")]
    public void CheckTestInputs(Type dayType, string part1, string part2) =>
        Common.CheckDay(dayType, part1, part2, true);
}
