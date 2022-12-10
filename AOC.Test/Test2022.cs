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
    [DataRow(typeof(Day07), "95437", "24933642")]
    [DataRow(typeof(Day08), "21", "8")]
    [DataRow(typeof(Day09), "88", "36")]
    [DataRow(typeof(Day10), "13140", Day10Test)]
    public void CheckTestInputs(Type dayType, string part1, string part2)
    {
        Common.CheckDay(dayType, part1, part2, true);
    }
}
