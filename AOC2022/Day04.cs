namespace AOC2022;

/// <summary>
/// Day 4: <a href="https://adventofcode.com/2022/day/4"/>
/// </summary>
public sealed class Day04 : Day
{
    private readonly List<List<int>> _ranges = new();

    public Day04() : base(2022, 4, "Camp Cleanup")
    {
        foreach (var line in Input)
            _ranges.Add(line.Split(',').SelectMany(q => q.Split('-')).Select(int.Parse).ToList());
    }

    public override object Part1() =>
        _ranges.Count(r =>
            (r[0] >= r[2] && r[0] <= r[3] && r[1] >= r[2] && r[1] <= r[3]) ||
            (r[2] >= r[0] && r[2] <= r[1] && r[3] >= r[0] && r[3] <= r[1]));

    public override object Part2() =>
        _ranges.Count(r => (r[0] >= r[2] && r[0] <= r[3]) ||
                           (r[1] >= r[2] && r[1] <= r[3]) ||
                           (r[2] >= r[0] && r[2] <= r[1]) ||
                           (r[3] >= r[0] && r[3] <= r[1]));
}