using Solutions._2022;
// ReSharper disable MemberCanBeMadeStatic.Global

namespace Tests;

public class Test2022
{
    [Test]
    [Arguments(typeof(Day01CalorieCounting), "70509", "208567")]
    [Arguments(typeof(Day02RockPaperScissors), "11449", "13187")]
    [Arguments(typeof(Day03RucksackReorganization), "7917", "2585")]
    [Arguments(typeof(Day04CampCleanup), "503", "827")]
    [Arguments(typeof(Day05SupplyStacks), "TGWSMRBPN", "TZLTLWRNF")]
    [Arguments(typeof(Day06TuningTrouble), "1356", "2564")]
    [Arguments(typeof(Day07NoSpaceLeftOnDevice), "919137", "2877389")]
    [Arguments(typeof(Day08TreetopTreeHouse), "1776", "234416")]
    [Arguments(typeof(Day09RopeBridge), "6406", "2643")]
    [Arguments(typeof(Day10CathodeRayTube), "14220",
        """
         ████ ███   ██  ███  █    ████ ████ █  █
            █ █  █ █  █ █  █ █    █       █ █  █
           █  █  █ █  █ █  █ █    ███    █  █  █
          █   ███  ████ ███  █    █     █   █  █
         █    █ █  █  █ █ █  █    █    █    █  █
         ████ █  █ █  █ █  █ ████ █    ████  ██ 
        """)]
    [Arguments(typeof(Day11MonkeyInTheMiddle), "61503", "14081365540")]
    [Arguments(typeof(Day12HillClimbingAlgorithm), "352", "345")]
    [Arguments(typeof(Day13DistressSignal), "5682", "20304")]
    [Arguments(typeof(Day14RegolithReservoir), "674", "24958")]
    // [Arguments(typeof(Day15BeaconExclusionZone), "4724228", "13622251246513")] // TODO: optimize
    public async Task CheckAllDays(Type dayType, string part1, string part2) =>
        await Common.CheckDay(dayType, part1, part2);

    [Test]
    [Arguments(typeof(Day01CalorieCounting), "24000", "45000")]
    [Arguments(typeof(Day02RockPaperScissors), "15", "12")]
    [Arguments(typeof(Day03RucksackReorganization), "157", "70")]
    [Arguments(typeof(Day04CampCleanup), "2", "4")]
    [Arguments(typeof(Day05SupplyStacks), "CMZ", "MCD")]
    [Arguments(typeof(Day06TuningTrouble), "7", "19")]
    [Arguments(typeof(Day07NoSpaceLeftOnDevice), "95437", "24933642")]
    [Arguments(typeof(Day08TreetopTreeHouse), "21", "8")]
    [Arguments(typeof(Day09RopeBridge), "88", "36")]
    [Arguments(typeof(Day10CathodeRayTube), "13140",
        """
         ██  ██  ██  ██  ██  ██  ██  ██  ██  ██ 
         ███   ███   ███   ███   ███   ███   ███
         ████    ████    ████    ████    ████   
         █████     █████     █████     █████    
         ██████      ██████      ██████      ███
        ████████       ███████       ███████    
        """)]
    [Arguments(typeof(Day11MonkeyInTheMiddle), "10605", "2713310158")]
    [Arguments(typeof(Day12HillClimbingAlgorithm), "31", "29")]
    [Arguments(typeof(Day13DistressSignal), "13", "140")]
    [Arguments(typeof(Day14RegolithReservoir), "24", "93")]
    [Arguments(typeof(Day15BeaconExclusionZone), "26", "56000011")]
    // [Arguments(typeof(Day16), "1651", "")]
    public async Task CheckTestInputs(Type dayType, string part1, string part2) =>
        await Common.CheckDay(dayType, part1, part2, true);
}
