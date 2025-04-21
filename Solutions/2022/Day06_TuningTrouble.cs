namespace Solutions._2022;

/// <summary>
/// Day 6: <a href="https://adventofcode.com/2022/day/6"/>
/// </summary>
public sealed class Day06TuningTrouble() : Day(2022, 6, "Tuning Trouble")
{
    private string? _signal;

    public override void ProcessInput() =>
        _signal = Input.First();

    private int DistinctSubstringIndex(int n) =>
        Enumerable.Range(0, _signal!.Length).First(i => _signal.Substring(i, n).Distinct().Count() == n) + n;

    public override object Part1() => DistinctSubstringIndex(4);
    public override object Part2() => DistinctSubstringIndex(14);
}
