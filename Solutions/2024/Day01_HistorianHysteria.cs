namespace Solutions._2024;

/// <summary>
/// Day 1: <a href="https://adventofcode.com/2024/day/1"/>
/// </summary>
public sealed class Day01HistorianHysteria() : Day(2024, 1, "Historian Hysteria")
{
    private readonly List<int> _list1 = [];
    private readonly List<int> _list2 = [];

    public override void ProcessInput()
    {
        var l = Input.Select(line =>
            line.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)).ToList();
        _list1.AddRange(l.Select(line => line[0]).Select(int.Parse));
        _list2.AddRange(l.Select(line => line[1]).Select(int.Parse));
    }

    public override object Part1() =>
        _list1.OrderBy(c => c).Zip(_list2.OrderBy(c => c)).Sum(i => Math.Abs(i.First - i.Second));

    public override object Part2()
    {
        var grouped = _list2.GroupBy(c => c).ToDictionary(c => c.Key, c => c.Count());

        return _list1.Sum(i =>
        {
            grouped.TryGetValue(i, out var c);
            return i * c;
        });
    }
}
