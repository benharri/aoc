using AOC2016;

namespace AOC.Test;

[TestClass]
public class Test2016
{
    [DataTestMethod]
    [DataRow(typeof(Day01), "300", "159")]
    [DataRow(typeof(Day02), "76792", "A7AC3")]
    [DataRow(typeof(Day03), "993", "1849")]
    [DataRow(typeof(Day04), "361724", "482")]
    //[DataRow(typeof(Day05), "F77A0E6E", "999828EC")] // TODO: optimize day 5
    [DataRow(typeof(Day06), "gyvwpxaz", "jucfoary")]
    public void CheckAllDays(Type dayType, string part1, string part2) =>
        Common.CheckDay(dayType, part1, part2);

    [DataTestMethod]
    [DataRow(typeof(Day02), "1985", "5DB3")]
    //[DataRow(typeof(Day05), "18F47A30", "05ACE8E3")]
    [DataRow(typeof(Day06), "easter", "advent")]
    public void CheckTestInputs(Type dayType, string part1, string part2) =>
        Common.CheckDay(dayType, part1, part2, true);
}
