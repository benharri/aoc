using MoreLinq;

namespace AOC2015;

/// <summary>
/// Day 19: <a href="https://adventofcode.com/2015/day/19"/>
/// </summary>
public sealed class Day19() : Day(2015, 19, "Medicine for Rudolph")
{
    private IEnumerable<string[]>? _rules;
    private string? _compound;

    public override void ProcessInput()
    {
        var i = Input.Split("").ToList();
        _rules = i[0].Select(r => r.Split(" => "));
        _compound = i[1].Single();
    }

    private int CountSubstring(string needle)
    {
        var count = 0;
        for (var i = _compound!.IndexOf(needle, StringComparison.InvariantCulture);
             i >= 0;
             ++count, i = _compound.IndexOf(needle, i + 1, StringComparison.InvariantCulture))
        {
        }

        return count;
    }

    public override object Part1()
    {
        HashSet<string> compounds = [];
        foreach (var rule in _rules!)
            foreach (var match in Regex.EnumerateMatches(_compound, rule[0]))
                compounds.Add(_compound!.Remove(match.Index, rule[0].Length).Insert(match.Index, rule[1]));

        return compounds.Count;
    }

    public override object Part2() =>
        _compound!.Count(char.IsUpper)
        - CountSubstring("Rn")
        - CountSubstring("Ar")
        - 2 * CountSubstring("Y")
        - 1;
}
