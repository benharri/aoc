using Solutions._2015;

namespace Tests;

[TestClass]
public class Test2015
{
    [DataTestMethod]
    [DataRow(typeof(Day01), "232", "1783")]
    [DataRow(typeof(Day02), "1586300", "3737498")]
    [DataRow(typeof(Day03), "2081", "2341")]
    [DataRow(typeof(Day04), "346386", "9958218")]
    [DataRow(typeof(Day05), "258", "53")]
    // [DataRow(typeof(Day06), "543903", "14687245")] // TODO: optimize
    [DataRow(typeof(Day07), "3176", "14710")]
    [DataRow(typeof(Day08), "1342", "2074")]
    [DataRow(typeof(Day09), "117", "909")]
    [DataRow(typeof(Day10), "492982", "6989950")]
    [DataRow(typeof(Day11), "hepxxyzz", "heqaabcc")]
    [DataRow(typeof(Day12), "111754", "65402")]
    [DataRow(typeof(Day13), "733", "725")]
    [DataRow(typeof(Day14), "2655", "1059")]
    [DataRow(typeof(Day15), "222870", "117936")]
    [DataRow(typeof(Day16), "103", "405")]
    [DataRow(typeof(Day17), "1304", "18")]
    [DataRow(typeof(Day18), "1061", "1006")]
    [DataRow(typeof(Day19), "576", "207")]
    [DataRow(typeof(Day20), "665280", "705600")]
    [DataRow(typeof(Day21), "78", "148")]
    // [DataRow(typeof(Day22), "", "")]
    [DataRow(typeof(Day23), "255", "334")]
    // [DataRow(typeof(Day24), "", "")]
    [DataRow(typeof(Day25), "9132360", "")]
    public void CheckAllDays(Type dayType, string part1, string part2) =>
        Common.CheckDay(dayType, part1, part2);

    [DataTestMethod]
    [DataRow(typeof(Day01), "-1", "5")]
    [DataRow(typeof(Day02), "58", "34")]
    [DataRow(typeof(Day03), "2", "11")]
    // [DataRow(typeof(Day04), "609043", "6742839")]
    [DataRow(typeof(Day05), "1", "1")]
    [DataRow(typeof(Day06), "1000000", "1000000")]
    // [DataRow(typeof(Day07), "", "")] // test input doesn't have "a" wire
    [DataRow(typeof(Day08), "12", "19")]
    [DataRow(typeof(Day09), "605", "982")]
    [DataRow(typeof(Day10), "237746", "3369156")]
    [DataRow(typeof(Day13), "330", "286")]
    [DataRow(typeof(Day15), "62842880", "57600000")]
    [DataRow(typeof(Day19), "4", "2")]
    public void CheckTestInputs(Type dayType, string part1, string part2) =>
        Common.CheckDay(dayType, part1, part2, true);
}
