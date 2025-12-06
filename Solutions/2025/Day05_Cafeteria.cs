using MoreLinq;

namespace Solutions._2025;

/// <summary>
/// Day 5: <a href="https://adventofcode.com/2025/day/5"/>
/// </summary>
public sealed class Day05Cafeteria() : Day(2025, 5, "Cafeteria")
{
    private List<(long start, long end)> _ranges = [];
    private List<long> _ids = [];

    public override void ProcessInput()
    {
        var split = Input.Split("").ToList();
        
        _ranges = split[0]
            .Select(i =>
            {
                var rangeSplit = i.Split('-').Select(long.Parse).ToList();
                return (start: rangeSplit[0], end: rangeSplit[1] + 1);
            })
            .OrderBy(r => r.start)
            .ToList();
        
        _ids = split[1].Select(long.Parse).ToList();
    }

    public override object Part1() =>
        _ids.Count(i => _ranges.Any(r => i >= r.start && i <= r.end));

    public override object Part2()
    {
        List<(long start, long end)> merged = [_ranges[0]];
        foreach (var range in _ranges.Skip(1))
        {
            var current = merged[^1];
            if (Math.Max(current.start, range.start) < Math.Min(current.end, range.end))
            {
                merged[^1] = (Math.Min(current.start, range.start), Math.Max(current.end, range.end));
            }
            else
            {
                merged.Add(range);
            }
        }

        return merged.Sum(r => r.end - r.start);
    }
}
