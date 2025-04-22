using Solutions._2021;

namespace Tests;

public class Test2021
{
    [Test]
    [Arguments(typeof(Day01SonarSweep), "1616", "1645")]
    [Arguments(typeof(Day02Dive), "2272262", "2134882034")]
    [Arguments(typeof(Day03BinaryDiagnostic), "3009600", "6940518")]
    [Arguments(typeof(Day04GiantSquid), "8580", "9576")]
    [Arguments(typeof(Day05HydrothermalVenture), "7318", "19939")]
    [Arguments(typeof(Day06Lanternfish), "362740", "1644874076764")]
    [Arguments(typeof(Day07TheTreacheryOfWhales), "345035", "97038163")]
    [Arguments(typeof(Day08SevenSegmentSearch), "362", "1020159")]
    [Arguments(typeof(Day09SmokeBasin), "478", "1327014")]
    [Arguments(typeof(Day10SyntaxScoring), "288291", "820045242")]
    [Arguments(typeof(Day11DumboOctopus), "1613", "510")]
    [Arguments(typeof(Day12PassagePathing), "4549", "120535")]
    [Arguments(typeof(Day13TransparentOrigami), "837",
        """
        ████▒███▒▒████▒▒██▒▒█▒▒█▒▒██▒▒█▒▒█▒█▒▒█
        █▒▒▒▒█▒▒█▒▒▒▒█▒█▒▒█▒█▒█▒▒█▒▒█▒█▒▒█▒█▒▒█
        ███▒▒█▒▒█▒▒▒█▒▒█▒▒▒▒██▒▒▒█▒▒▒▒████▒█▒▒█
        █▒▒▒▒███▒▒▒█▒▒▒█▒██▒█▒█▒▒█▒▒▒▒█▒▒█▒█▒▒█
        █▒▒▒▒█▒▒▒▒█▒▒▒▒█▒▒█▒█▒█▒▒█▒▒█▒█▒▒█▒█▒▒█
        ████▒█▒▒▒▒████▒▒███▒█▒▒█▒▒██▒▒█▒▒█▒▒██▒
        """)]
    [Arguments(typeof(Day14ExtendedPolymerization), "5656", "12271437788530")]
    [Arguments(typeof(Day15Chiton), "702", "2955")]
    [Arguments(typeof(Day16PacketDecoder), "852", "19348959966392")]
    [Arguments(typeof(Day17TrickShot), "12090", "5059")]
    [Arguments(typeof(Day18Snailfish), "4289", "4807")]
    // [Arguments(typeof(Day19BeaconScanner), "338", "9862")] // takes too long and i don't feel like optimizing
    [Arguments(typeof(Day20TrenchMap), "5306", "17497")]
    [Arguments(typeof(Day21DiracDice), "512442", "346642902541848")]
    [Arguments(typeof(Day22ReactorReboot), "658691", "1228699515783640")]
    [Arguments(typeof(Day23Amphipod), "15365", "52055")]
    [Arguments(typeof(Day24ArithmeticLogicUnit), "99299513899971", "93185111127911")]
    [Arguments(typeof(Day25SeaCucumber), "417", "")]
    public void CheckAllDays(Type dayType, string part1, string part2) =>
        _ = Common.CheckDay(dayType, part1, part2);

    [Test]
    [Arguments(typeof(Day01SonarSweep), "7", "5")]
    [Arguments(typeof(Day02Dive), "150", "900")]
    [Arguments(typeof(Day03BinaryDiagnostic), "198", "230")]
    [Arguments(typeof(Day04GiantSquid), "4512", "1924")]
    [Arguments(typeof(Day05HydrothermalVenture), "5", "12")]
    [Arguments(typeof(Day06Lanternfish), "5934", "26984457539")]
    [Arguments(typeof(Day07TheTreacheryOfWhales), "37", "168")]
    [Arguments(typeof(Day08SevenSegmentSearch), "26", "61229")]
    [Arguments(typeof(Day09SmokeBasin), "15", "1134")]
    [Arguments(typeof(Day10SyntaxScoring), "26397", "288957")]
    [Arguments(typeof(Day11DumboOctopus), "1656", "195")]
    [Arguments(typeof(Day12PassagePathing), "226", "3509")]
    [Arguments(typeof(Day13TransparentOrigami), "17",
        """
        █████
        █▒▒▒█
        █▒▒▒█
        █▒▒▒█
        █████
        """)]
    [Arguments(typeof(Day14ExtendedPolymerization), "1588", "2188189693529")]
    [Arguments(typeof(Day15Chiton), "40", "315")]
    [Arguments(typeof(Day16PacketDecoder), "16", "15")]
    [Arguments(typeof(Day17TrickShot), "45", "112")]
    [Arguments(typeof(Day18Snailfish), "4140", "3993")]
    [Arguments(typeof(Day19BeaconScanner), "79", "3621")]
    [Arguments(typeof(Day20TrenchMap), "35", "3351")]
    [Arguments(typeof(Day21DiracDice), "739785", "444356092776315")]
    [Arguments(typeof(Day22ReactorReboot), "590784", "39769202357779")]
    [Arguments(typeof(Day23Amphipod), "12521", "44169")]
    [Arguments(typeof(Day25SeaCucumber), "58", "")]
    public void CheckTestInputs(Type dayType, string part1, string part2) =>
        _ = Common.CheckDay(dayType, part1, part2, true);
}
