using AOC2022;
namespace AOC.Test;

[TestClass]
public class Test2022
{
    [DataTestMethod]
    [DataRow(typeof(Day01), "70509", "208567")]
    [DataRow(typeof(Day02), "11449", "13187")]
    [DataRow(typeof(Day03), "7917", "2585")]
    [DataRow(typeof(Day04), "503", "827")]
    [DataRow(typeof(Day05), "TGWSMRBPN", "TZLTLWRNF")]
    [DataRow(typeof(Day06), "1356", "2564")]
    public void CheckAllDays(Type dayType, string part1, string part2)
    {
        Common.CheckDay(dayType, part1, part2);
    }

    [DataTestMethod]
    [DataRow(typeof(Day01), "24000", "45000")]
    [DataRow(typeof(Day02), "15", "12")]
    [DataRow(typeof(Day03), "157", "70")]
    [DataRow(typeof(Day04), "2", "4")]
    [DataRow(typeof(Day05), "CMZ", "MCD")]
    [DataRow(typeof(Day06), "7", "19")]
    [DataRow(typeof(Day07), "95437", "")]
    public void CheckTestInputs(Type dayType, string part1, string part2)
    {
        Common.CheckDay(dayType, part1, part2, true);
    }
}
