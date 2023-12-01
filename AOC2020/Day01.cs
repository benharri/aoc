namespace AOC2020;

/// <summary>
///     Day 1: <a href="https://adventofcode.com/2020/day/1" />
/// </summary>
public sealed class Day01() : Day(2020, 1, "Report Repair")
{
    private ImmutableHashSet<int>? _entries;

    public override void ProcessInput() =>
        _entries = Input.Select(int.Parse).ToImmutableHashSet();

    public override object Part1()
    {
        var entry = _entries!.First(e => _entries!.Contains(2020 - e));
        return entry * (2020 - entry);
    }

    public override object Part2()
    {
        foreach (var i in _entries!)
        foreach (var j in _entries)
        foreach (var k in _entries)
            if (i + j + k == 2020)
                return i * j * k;

        return default!;
    }
}
