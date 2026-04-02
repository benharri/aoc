using MoreLinq;

namespace Solutions._2024;

/// <summary>
/// Day 5: <a href="https://adventofcode.com/2024/day/5"/>
/// </summary>
public sealed class Day05PrintQueue() : Day(2024, 5, "Print Queue")
{
    private readonly List<(string, string)> _rules = [];
    private readonly List<string[]> _updates = [];

    public override void ProcessInput()
    {
        var s = Input.Split("").ToList();
        _rules.AddRange(s[0].Select(rule =>
        {
            var split = rule.Split('|');
            return (split[0], split[1]);
        }));
        _updates.AddRange(s[1].Select(update => update.Split(',')));
    }

    public override object Part1()
    {
        var correctOrder = _updates.Where(update => _rules.All(r => !update.Contains(r.Item1) || !update.Contains(r.Item2) ||
                                                                    update.IndexOf(r.Item1) < update.IndexOf(r.Item2)));
        return correctOrder.Sum(update => int.Parse(update[update.Length / 2]));
    }

    public override object Part2() => "";
}
