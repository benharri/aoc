using MoreLinq;

namespace Solutions._2025;

/// <summary>
/// Day 12: <a href="https://adventofcode.com/2025/day/12"/>
/// </summary>
public sealed class Day12ChristmasTreeFarm() : Day(2025, 12, "Christmas Tree Farm")
{
    public override object Part1()
    {
        var sections = Input.Split("").Select(l => l.ToList()).ToList();
        var presentShapes = sections[..^1]
            .Select(line => (Id: int.Parse(line[0].Trim(':')), Size: line[1..].Sum(l => l.Count(c => c == '#'))))
            .ToList();

        return sections[^1]
            .Select(line =>
            {
                var s = line.Split(": ");
                var size = s[0].Split('x').Select(int.Parse).ToList();
                return (Area: size[0] * size[1], Amounts: s[1].Split(' ').Select(int.Parse));
            })
            .Count(r => r.Area >= r.Amounts.Select((amount, id) => amount * presentShapes[id].Size).Sum());
    }

    public override object Part2() => "";
}
