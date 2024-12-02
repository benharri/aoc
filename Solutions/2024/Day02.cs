using MoreLinq;

namespace Solutions._2024;

/// <summary>
/// <a href="https://adventofcode.com/2024/day/2">Day  2</a>
/// </summary>
public sealed class Day02() : Day(2024, 2, "")
{
    public override object Part1() =>
        Input.Select(line => line.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList())
            .Select(i => i.Pairwise((x, y) => y - x).ToList())
            .Count(pairs => pairs.All(c => Math.Abs(c) is >= 1 and <= 3) &&
                            (pairs.All(c => c > 0) || pairs.All(c => c < 0)));

    public override object Part2() => "";
}
