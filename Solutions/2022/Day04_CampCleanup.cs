namespace Solutions._2022;

/// <summary>
/// Day 4: <a href="https://adventofcode.com/2022/day/4"/>
/// </summary>
public sealed class Day04CampCleanup() : Day(2022, 4, "Camp Cleanup")
{
    private List<(Range r1, Range r2)>? _ranges;

    public override void ProcessInput() =>
        _ranges = Input
            .Select(line => line.Split(',').SelectMany(q => q.Split('-')).Select(int.Parse).ToList())
            .Select(p => (new Range(p[0], p[1]), new Range(p[2], p[3])))
            .ToList();

    public override object Part1() =>
        _ranges!.Count(r => r.r1.Contains(r.r2) || r.r2.Contains(r.r1));

    public override object Part2() =>
        _ranges!.Count(r => r.r1.Overlaps(r.r2));
}
