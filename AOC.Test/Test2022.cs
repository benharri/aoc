using AOC2022;
namespace AOC.Test;

[TestClass]
public class Test2022
{
    private const string Day10Actual = """
         ████ ███   ██  ███  █    ████ ████ █  █
            █ █  █ █  █ █  █ █    █       █ █  █
           █  █  █ █  █ █  █ █    ███    █  █  █
          █   ███  ████ ███  █    █     █   █  █
         █    █ █  █  █ █ █  █    █    █    █  █
         ████ █  █ █  █ █  █ ████ █    ████  ██ 
        """;

    private const string Day10Test = """
         ██  ██  ██  ██  ██  ██  ██  ██  ██  ██ 
         ███   ███   ███   ███   ███   ███   ███
         ████    ████    ████    ████    ████   
         █████     █████     █████     █████    
         ██████      ██████      ██████      ███
        ████████       ███████       ███████    
        """;

    [DataTestMethod]
    [DataRow(typeof(Day01), "70509", "208567")]
    [DataRow(typeof(Day02), "11449", "13187")]
    [DataRow(typeof(Day03), "7917", "2585")]
    [DataRow(typeof(Day04), "503", "827")]
    [DataRow(typeof(Day05), "TGWSMRBPN", "TZLTLWRNF")]
    [DataRow(typeof(Day06), "1356", "2564")]
    [DataRow(typeof(Day07), "919137", "2877389")]
    [DataRow(typeof(Day08), "1776", "234416")]
    [DataRow(typeof(Day09), "6406", "2643")]
    [DataRow(typeof(Day10), "14220", Day10Actual)]
    [DataRow(typeof(Day11), "61503", "14081365540")]
    [DataRow(typeof(Day12), "352", "345")]
    [DataRow(typeof(Day13), "5682", "20304")]
    [DataRow(typeof(Day14), "674", "24958")]
    // [DataRow(typeof(Day15), "4724228", "13622251246513")] // TODO: optimize
    public void CheckAllDays(Type dayType, string part1, string part2) =>
        Common.CheckDay(dayType, part1, part2);

    [DataTestMethod]
    [DataRow(typeof(Day01), "24000", "45000")]
    [DataRow(typeof(Day02), "15", "12")]
    [DataRow(typeof(Day03), "157", "70")]
    [DataRow(typeof(Day04), "2", "4")]
    [DataRow(typeof(Day05), "CMZ", "MCD")]
    [DataRow(typeof(Day06), "7", "19")]
    [DataRow(typeof(Day07), "95437", "24933642")]
    [DataRow(typeof(Day08), "21", "8")]
    [DataRow(typeof(Day09), "88", "36")]
    [DataRow(typeof(Day10), "13140", Day10Test)]
    [DataRow(typeof(Day11), "10605", "2713310158")]
    [DataRow(typeof(Day12), "31", "29")]
    [DataRow(typeof(Day13), "13", "140")]
    [DataRow(typeof(Day14), "24", "93")]
    [DataRow(typeof(Day15), "26", "56000011")]
    public void CheckTestInputs(Type dayType, string part1, string part2) =>
        Common.CheckDay(dayType, part1, part2, true);
}
