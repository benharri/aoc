using AOC2015;

namespace AOC.Test;

[TestClass]
public class Test2015
{
    [DataTestMethod]
    [DataRow(typeof(Day01), "232", "1783")]
    [DataRow(typeof(Day02),"1586300", "3737498")]
    [DataRow(typeof(Day03), "2081", "2341")]
    // [DataRow(typeof(Day04), "346386", "9958218")]
    [DataRow(typeof(Day05), "258", "53")]
    // [DataRow(typeof(Day06), "543903", "14687245")]
    [DataRow(typeof(Day07), "3176", "14710")]
    [DataRow(typeof(Day08), "1342", "2074")]
    [DataRow(typeof(Day09), "117", "909")]
    public void TestAllDays(Type dayType, string part1, string part2)
    {
        Common.CheckDay(dayType, part1, part2);
    }

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
    public void CheckTestInputs(Type dayType, string part1, string part2)
    {
        Day.UseTestInput = true;
        Common.CheckDay(dayType, part1, part2);
        Day.UseTestInput = false;
    }
}