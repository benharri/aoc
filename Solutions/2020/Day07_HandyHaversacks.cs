namespace Solutions._2020;

/// <summary>
///     Day 7: <a href="https://adventofcode.com/2020/day/7" />
/// </summary>
public sealed class Day07HandyHaversacks() : Day(2020, 7, "Handy Haversacks")
{
    private Dictionary<string, IEnumerable<(int Weight, string Name)?>>? _rules;

    public override void ProcessInput() =>
        _rules = Input
            .Select(rule =>
            {
                var spl = rule.Split(" bags contain ", 2);
                var outer = string.Join(' ', spl[0].Split(' ').Take(2));
                var inner = spl[1].Split(", ").Select(ParseQuantity).Where(i => i != null);
                return (outer, inner);
            })
            .ToDictionary(t => t.outer, t => t.inner);

    private static (int, string)? ParseQuantity(string arg)
    {
        if (arg == "no other bags.") return null;
        var words = arg.Split(' ');
        return (int.Parse(words[0]), string.Join(' ', words[1..3]));
    }

    private int Weight(string node) =>
        1 + _rules![node]
            .Where(i => i.HasValue)
            .Select(i => i!.Value)
            .Sum(i => i.Weight * Weight(i.Name));

    public override object Part1()
    {
        // breadth-first search with Queue
        Queue<string> start = new(["shiny gold"]);
        var p = new HashSet<string>();
        string node;
        while (true)
        {
            node = start.Dequeue();
            foreach (var (container, contained) in _rules!)
                if (contained.Any(i => i.HasValue && i.Value.Name == node) && p.Add(container))
                    start.Enqueue(container);

            if (start.Count == 0) break;
        }

        return p.Count;
    }

    public override object Part2() => Weight("shiny gold") - 1;
}
