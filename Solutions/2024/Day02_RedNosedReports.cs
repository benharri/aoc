using MoreLinq;

namespace Solutions._2024;

/// <summary>
/// <a href="https://adventofcode.com/2024/day/2">Day 2</a>
/// </summary>
public sealed class Day02RedNosedReports() : Day(2024, 2, "Red-Nosed Reports")
{
    public override object Part1() =>
        Input.Select(line => line.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList())
            .Select(i => i.Pairwise((x, y) => y - x).ToList())
            .Count(pairs => pairs.All(c => Math.Abs(c) is >= 1 and <= 3) &&
                            (pairs.All(c => c > 0) || pairs.All(c => c < 0)));

    public override object Part2()
    {
        var result = 0;

        foreach (var line in Input)
        {
            var ints = line.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            for (var i = 0; i < ints.Count; i++)
            {
                var intsCopy = ints.ToList();
                intsCopy.RemoveAt(i);

                var pairs = intsCopy.Pairwise((x, y) => y - x).ToList();
                if (pairs.All(c => Math.Abs(c) is >= 1 and <= 3) &&
                    (pairs.All(c => c > 0) || pairs.All(c => c < 0)))
                {
                    result++;
                    break;
                }
            }
        }

        return result;
    }
}
