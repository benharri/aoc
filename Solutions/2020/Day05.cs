namespace Solutions._2020;

/// <summary>
///     Day 5: <a href="https://adventofcode.com/2020/day/5" />
/// </summary>
public sealed class Day05() : Day(2020, 5, "Binary Boarding")
{
    private ImmutableHashSet<int>? _ids;

    public override void ProcessInput() =>
        _ids = Input
            .Select(s =>
                Convert.ToInt32(s.Replace('F', '0').Replace('B', '1').Replace('L', '0').Replace('R', '1'), 2))
            .OrderBy(i => i)
            .ToImmutableHashSet();

    public override object Part1() => _ids!.Last();

    public override object Part2() =>
        // arithmetic sum of full series
        (_ids!.Count + 1) * (_ids.First() + _ids.Last()) / 2 - _ids.Sum();
}
