using MoreLinq;

namespace Solutions._2024;

/// <summary>
/// Day 5: <a href="https://adventofcode.com/2024/day/5"/>
/// </summary>
public sealed class Day05PrintQueue() : Day(2024, 5, "Print Queue")
{
    private readonly List<string[]> _updates = [];
    private readonly List<List<string>> _orderedUpdates = [];

    public override void ProcessInput()
    {
        var s = Input.Split("").ToList();
        _updates.AddRange(s[1].Select(update => update.Split(',')));
        _orderedUpdates.AddRange(_updates
            .Select(u => u.OrderBy(y => y, new PrintOrderComparer(s[0].Select(rule => rule.Split('|')).ToList())))
            .Select(x => x.ToList())
            .ToList());
    }

    public override object Part1() =>
        _orderedUpdates.Where((x, i) => x.SequenceEqual(_updates[i])).Sum(x => int.Parse(x[x.Count / 2]));

    public override object Part2() =>
        _orderedUpdates.Where((x, i) => !x.SequenceEqual(_updates[i])).Sum(x => int.Parse(x[x.Count / 2]));
}

public class PrintOrderComparer(List<string[]> rules) : IComparer<string>
{
    public int Compare(string? x, string? y)
    {
        var first = rules.First(r => r.Contains(x) && r.Contains(y))[0];
        if (first == x) return -1;
        return first == y ? 1 : 0;
    }
}
