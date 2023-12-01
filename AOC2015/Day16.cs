namespace AOC2015;

/// <summary>
/// Day 16: <a href="https://adventofcode.com/2015/day/16"/>
/// </summary>
public sealed partial class Day16() : Day(2015, 16, "Aunt Sue")
{
    [GeneratedRegex(@": \d\d")]
    private static partial Regex TwoDigitsRegex();

    public override void ProcessInput()
    {
    }

    private IEnumerable<string> Common() =>
        Input
            .Select(i => TwoDigitsRegex().Replace(i, ": 9"))
            .WhereMatch("children: 3")
            .WhereMatch("samoyeds: 2")
            .WhereMatch("akitas: 0")
            .WhereMatch("vizslas: 0")
            .WhereMatch("cars: 2")
            .WhereMatch("perfumes: 1");

    public override object Part1() =>
        Common()
            .WhereMatch("cats: 7")
            .WhereMatch("trees: 3")
            .WhereMatch("pomeranians: 3")
            .WhereMatch("goldfish: 5")
            .Single()
            .Split(' ', ':')[1];

    public override object Part2() =>
        Common()
            .WhereMatch("cats: [89]")
            .WhereMatch("trees: [4-9]")
            .WhereMatch("pomeranians: [012]")
            .WhereMatch("goldfish: [0-4]")
            .Single()
            .Split(' ', ':')[1];
}

public static class Day16Extensions
{
    public static IEnumerable<string> WhereMatch(this IEnumerable<string> input, string pattern) =>
        input.Where(i => !i.Contains(pattern.Split(' ')[0]) || Regex.IsMatch(i, pattern));
}
