using Solutions._2022;

namespace Tests;

[TestClass]
public class Test2022
{
    [DataTestMethod]
    [DataRow(typeof(Day01CalorieCounting), "70509", "208567")]
    [DataRow(typeof(Day02RockPaperScissors), "11449", "13187")]
    [DataRow(typeof(Day03RucksackReorganization), "7917", "2585")]
    [DataRow(typeof(Day04CampCleanup), "503", "827")]
    [DataRow(typeof(Day05SupplyStacks), "TGWSMRBPN", "TZLTLWRNF")]
    [DataRow(typeof(Day06TuningTrouble), "1356", "2564")]
    [DataRow(typeof(Day07NoSpaceLeftOnDevice), "919137", "2877389")]
    [DataRow(typeof(Day08TreetopTreeHouse), "1776", "234416")]
    [DataRow(typeof(Day09RopeBridge), "6406", "2643")]
    [DataRow(typeof(Day10CathodeRayTube), "14220",
        """
         ████ ███   ██  ███  █    ████ ████ █  █
            █ █  █ █  █ █  █ █    █       █ █  █
           █  █  █ █  █ █  █ █    ███    █  █  █
          █   ███  ████ ███  █    █     █   █  █
         █    █ █  █  █ █ █  █    █    █    █  █
         ████ █  █ █  █ █  █ ████ █    ████  ██ 
        """)]
    [DataRow(typeof(Day11MonkeyInTheMiddle), "61503", "14081365540")]
    [DataRow(typeof(Day12HillClimbingAlgorithm), "352", "345")]
    [DataRow(typeof(Day13DistressSignal), "5682", "20304")]
    [DataRow(typeof(Day14RegolithReservoir), "674", "24958")]
    // [DataRow(typeof(Day15BeaconExclusionZone), "4724228", "13622251246513")] // TODO: optimize
    public void CheckAllDays(Type dayType, string part1, string part2) =>
        Common.CheckDay(dayType, part1, part2);

    [DataTestMethod]
    [DataRow(typeof(Day01CalorieCounting), "24000", "45000")]
    [DataRow(typeof(Day02RockPaperScissors), "15", "12")]
    [DataRow(typeof(Day03RucksackReorganization), "157", "70")]
    [DataRow(typeof(Day04CampCleanup), "2", "4")]
    [DataRow(typeof(Day05SupplyStacks), "CMZ", "MCD")]
    [DataRow(typeof(Day06TuningTrouble), "7", "19")]
    [DataRow(typeof(Day07NoSpaceLeftOnDevice), "95437", "24933642")]
    [DataRow(typeof(Day08TreetopTreeHouse), "21", "8")]
    [DataRow(typeof(Day09RopeBridge), "88", "36")]
    [DataRow(typeof(Day10CathodeRayTube), "13140",
        """
         ██  ██  ██  ██  ██  ██  ██  ██  ██  ██ 
         ███   ███   ███   ███   ███   ███   ███
         ████    ████    ████    ████    ████   
         █████     █████     █████     █████    
         ██████      ██████      ██████      ███
        ████████       ███████       ███████    
        """)]
    [DataRow(typeof(Day11MonkeyInTheMiddle), "10605", "2713310158")]
    [DataRow(typeof(Day12HillClimbingAlgorithm), "31", "29")]
    [DataRow(typeof(Day13DistressSignal), "13", "140")]
    [DataRow(typeof(Day14RegolithReservoir), "24", "93")]
    [DataRow(typeof(Day15BeaconExclusionZone), "26", "56000011")]
    // [DataRow(typeof(Day16), "1651", "")]
    public void CheckTestInputs(Type dayType, string part1, string part2) =>
        Common.CheckDay(dayType, part1, part2, true);
}
