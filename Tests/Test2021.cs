using Solutions._2021;

namespace Tests;

[TestClass]
public class Test2021
{
    [DataTestMethod]
    [DataRow(typeof(Day01), "1616", "1645")]
    [DataRow(typeof(Day02), "2272262", "2134882034")]
    [DataRow(typeof(Day03), "3009600", "6940518")]
    [DataRow(typeof(Day04), "8580", "9576")]
    [DataRow(typeof(Day05), "7318", "19939")]
    [DataRow(typeof(Day06), "362740", "1644874076764")]
    [DataRow(typeof(Day07), "345035", "97038163")]
    [DataRow(typeof(Day08), "362", "1020159")]
    [DataRow(typeof(Day09), "478", "1327014")]
    [DataRow(typeof(Day10), "288291", "820045242")]
    [DataRow(typeof(Day11), "1613", "510")]
    [DataRow(typeof(Day12), "4549", "120535")]
    [DataRow(typeof(Day13), "837",
        """
        ████▒███▒▒████▒▒██▒▒█▒▒█▒▒██▒▒█▒▒█▒█▒▒█
        █▒▒▒▒█▒▒█▒▒▒▒█▒█▒▒█▒█▒█▒▒█▒▒█▒█▒▒█▒█▒▒█
        ███▒▒█▒▒█▒▒▒█▒▒█▒▒▒▒██▒▒▒█▒▒▒▒████▒█▒▒█
        █▒▒▒▒███▒▒▒█▒▒▒█▒██▒█▒█▒▒█▒▒▒▒█▒▒█▒█▒▒█
        █▒▒▒▒█▒▒▒▒█▒▒▒▒█▒▒█▒█▒█▒▒█▒▒█▒█▒▒█▒█▒▒█
        ████▒█▒▒▒▒████▒▒███▒█▒▒█▒▒██▒▒█▒▒█▒▒██▒
        """)]
    [DataRow(typeof(Day14), "5656", "12271437788530")]
    [DataRow(typeof(Day15), "702", "2955")]
    [DataRow(typeof(Day16), "852", "19348959966392")]
    [DataRow(typeof(Day17), "12090", "5059")]
    [DataRow(typeof(Day18), "4289", "4807")]
    // [DataRow(typeof(Day19), "338", "9862")] // takes too long and i don't feel like optimizing
    [DataRow(typeof(Day20), "5306", "17497")]
    [DataRow(typeof(Day21), "512442", "346642902541848")]
    [DataRow(typeof(Day22), "658691", "1228699515783640")]
    [DataRow(typeof(Day23), "15365", "52055")]
    [DataRow(typeof(Day24), "99299513899971", "93185111127911")]
    [DataRow(typeof(Day25), "417", "")]
    public void CheckAllDays(Type dayType, string part1, string part2) =>
        Common.CheckDay(dayType, part1, part2);

    [DataTestMethod]
    [DataRow(typeof(Day01), "7", "5")]
    [DataRow(typeof(Day02), "150", "900")]
    [DataRow(typeof(Day03), "198", "230")]
    [DataRow(typeof(Day04), "4512", "1924")]
    [DataRow(typeof(Day05), "5", "12")]
    [DataRow(typeof(Day06), "5934", "26984457539")]
    [DataRow(typeof(Day07), "37", "168")]
    [DataRow(typeof(Day08), "26", "61229")]
    [DataRow(typeof(Day09), "15", "1134")]
    [DataRow(typeof(Day10), "26397", "288957")]
    [DataRow(typeof(Day11), "1656", "195")]
    [DataRow(typeof(Day12), "226", "3509")]
    [DataRow(typeof(Day13), "17",
        """
        █████
        █▒▒▒█
        █▒▒▒█
        █▒▒▒█
        █████
        """)]
    [DataRow(typeof(Day14), "1588", "2188189693529")]
    [DataRow(typeof(Day15), "40", "315")]
    [DataRow(typeof(Day16), "16", "15")]
    [DataRow(typeof(Day17), "45", "112")]
    [DataRow(typeof(Day18), "4140", "3993")]
    [DataRow(typeof(Day19), "79", "3621")]
    [DataRow(typeof(Day20), "35", "3351")]
    [DataRow(typeof(Day21), "739785", "444356092776315")]
    [DataRow(typeof(Day22), "590784", "39769202357779")]
    [DataRow(typeof(Day23), "12521", "44169")]
    [DataRow(typeof(Day25), "58", "")]
    public void CheckTestInputs(Type dayType, string part1, string part2) =>
        Common.CheckDay(dayType, part1, part2, true);
}
