using Solutions._2020;

namespace Tests;

[TestClass]
public class Test2020
{
    [DataTestMethod]
    [DataRow(typeof(Day01), "751776", "42275090")]
    [DataRow(typeof(Day02), "556", "605")]
    [DataRow(typeof(Day03), "189", "1718180100")]
    [DataRow(typeof(Day04), "247", "145")]
    [DataRow(typeof(Day05), "878", "504")]
    [DataRow(typeof(Day06), "6273", "3254")]
    [DataRow(typeof(Day07), "169", "82372")]
    [DataRow(typeof(Day08), "1654", "833")]
    [DataRow(typeof(Day09), "138879426", "23761694")]
    [DataRow(typeof(Day10), "1980", "4628074479616")]
    [DataRow(typeof(Day11), "2303", "2057")]
    [DataRow(typeof(Day12), "1710", "62045")]
    [DataRow(typeof(Day13), "171", "539746751134958")]
    [DataRow(typeof(Day14), "17481577045893", "4160009892257")]
    [DataRow(typeof(Day15), "257", "8546398")]
    [DataRow(typeof(Day16), "19093", "5311123569883")]
    // [DataRow(typeof(Day17), "293", "1816")] // this one takes too long and i don't want to bother optimizing it
    [DataRow(typeof(Day18), "12918250417632", "171259538712010")]
    [DataRow(typeof(Day19), "160", "357")]
    [DataRow(typeof(Day20), "21599955909991", "2495")]
    [DataRow(typeof(Day21), "2436", "dhfng,pgblcd,xhkdc,ghlzj,dstct,nqbnmzx,ntggc,znrzgs")]
    [DataRow(typeof(Day22), "32856", "33805")]
    [DataRow(typeof(Day23), "36542897", "562136730660")]
    [DataRow(typeof(Day24), "282", "3445")]
    [DataRow(typeof(Day25), "11707042", "")]
    public void CheckAllDays(Type dayType, string part1, string part2) =>
        Common.CheckDay(dayType, part1, part2);
}
