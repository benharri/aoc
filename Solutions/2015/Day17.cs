namespace Solutions._2015;

/// <summary>
/// Day 17: <a href="https://adventofcode.com/2015/day/17"/>
/// </summary>
public sealed class Day17() : Day(2015, 17, "No Such Thing as Too Much")
{
    private List<int>? _containers;
    private IEnumerable<List<int>>? _combinations;

    public override void ProcessInput()
    {
        _containers = Input.Select(int.Parse).ToList();
        _combinations = Enumerable.Range(1, (1 << _containers.Count) - 1)
            .Select(i => _containers.Where((_, index) => ((1 << index) & i) != 0).ToList());
    }

    public override object Part1() => _combinations!.Count(c => c.Sum() == 150);

    public override object Part2()
    {
        var successfulCombinations = _combinations!.Where(c => c.Sum() == 150).ToList();
        var minCount = successfulCombinations.Min(c => c.Count);
        return successfulCombinations.Count(c => c.Count == minCount);
    }
}
