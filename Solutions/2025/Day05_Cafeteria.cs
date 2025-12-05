using MoreLinq;
using System.Numerics;

namespace Solutions._2025;

/// <summary>
/// Day 5: <a href="https://adventofcode.com/2025/day/5"/>
/// </summary>
public sealed class Day05Cafeteria() : Day(2025, 5, "Cafeteria")
{
    public override object Part1()
    {
        var s = Input.Split("").ToList();
        var ranges = s[0].Select(i =>
        {
            var split = i.Split('-').Select(BigInteger.Parse).ToList();
            return (start: split[0], end: split[1]);
        }).ToList();
        var ids = s[1].Select(BigInteger.Parse);
        return ids.Count(i => ranges.Any(r => i >= r.start && i <= r.end));
    }

    public override object Part2() => "";
}
