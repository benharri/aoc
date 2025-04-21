namespace Solutions._2021;

/// <summary>
/// Day 14: <a href="https://adventofcode.com/2021/day/14"/>
/// </summary>
public sealed class Day14ExtendedPolymerization() : Day(2021, 14, "Extended Polymerization")
{
    private string? _template;
    private Dictionary<string, string>? _substitutionPairs;

    public override void ProcessInput()
    {
        _template = Input.First();
        _substitutionPairs = Input.Skip(2).Select(l => l.Split(" -> ")).ToDictionary(k => k[0], v => v[1]);
    }

    private string DoStep(string input)
    {
        var result = new StringBuilder();

        for (var i = 0; i < input.Length - 1; i++)
        {
            var k = input.Substring(i, 2);
            if (_substitutionPairs!.TryGetValue(k, out var value))
            {
                result.Append(k[0]);
                result.Append(value);
            }
            else
            {
                result.Append(k);
            }
        }

        result.Append(input[^1]);

        return result.ToString();
    }

    private long Solve(int steps)
    {
        var moleculeCounts = new Dictionary<string, long>();
        foreach (var i in Enumerable.Range(0, _template!.Length - 1))
        {
            var k = _template.Substring(i, 2);
            moleculeCounts[k] = moleculeCounts.GetValueOrDefault(k) + 1;
        }

        foreach (var _ in Enumerable.Range(0, steps))
        {
            var updated = new Dictionary<string, long>();
            foreach (var (molecule, count) in moleculeCounts)
            {
                var (a, n, b) = (molecule[0], _substitutionPairs![molecule], molecule[1]);
                updated[$"{a}{n}"] = updated.GetValueOrDefault($"{a}{n}") + count;
                updated[$"{n}{b}"] = updated.GetValueOrDefault($"{n}{b}") + count;
            }

            moleculeCounts = updated;
        }

        var elementCounts = new Dictionary<char, long>();
        foreach (var (molecule, count) in moleculeCounts)
        {
            var a = molecule[0];
            elementCounts[a] = elementCounts.GetValueOrDefault(a) + count;
        }

        // don't forget the last letter of the original template
        elementCounts[_template.Last()]++;

        return elementCounts.Values.Max() - elementCounts.Values.Min();
    }

    public override object Part1()
    {
        var s = Enumerable.Range(0, 10).Aggregate(_template, (current, _) => DoStep(current!));

        var most = s!.ToCharArray()
            .GroupBy(c => c)
            .OrderByDescending(g => g.Count())
            .Select(g => g.Count())
            .ToList();

        return most.First() - most.Last();
    }

    public override object Part2() => Solve(40);
}
