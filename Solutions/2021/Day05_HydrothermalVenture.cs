namespace Solutions._2021;

/// <summary>
/// Day 5: <a href="https://adventofcode.com/2021/day/5"/>
/// </summary>
public sealed partial class Day05HydrothermalVenture() : Day(2021, 5, "Hydrothermal Venture")
{
    private int Solve(bool diagonals = false) =>
        Input
            .Select(s => NonDigits().Split(s).Select(int.Parse).ToList())
            .Where(t => diagonals || t[0] == t[2] || t[1] == t[3])
            .SelectMany(t =>
                Enumerable.Range(0, Math.Max(Math.Abs(t[0] - t[2]), Math.Abs(t[1] - t[3])) + 1)
                    .Select(i => (
                        t[0] > t[2] ? t[2] + i : t[0] < t[2] ? t[2] - i : t[2],
                        t[1] > t[3] ? t[3] + i : t[1] < t[3] ? t[3] - i : t[3])))
            .GroupBy(k => k)
            .Count(k => k.Count() > 1);

    public override object Part1() => Solve();

    public override object Part2() => Solve(diagonals: true);

    [GeneratedRegex(@"\D+")]
    private static partial Regex NonDigits();
}
