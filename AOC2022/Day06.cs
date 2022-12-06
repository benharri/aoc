namespace AOC2022;

/// <summary>
/// Day 6: <a href="https://adventofcode.com/2022/day/6"/>
/// </summary>
public sealed class Day06 : Day
{
    private readonly string _signal;
    public Day06() : base(2022, 6, "Tuning Trouble")
    {
        _signal = Input.First();
    }

    public override object Part1() =>
        Enumerable.Range(0, _signal.Length).First(i => _signal.Substring(i, 4).Distinct().Count() == 4) + 4;

    public override object Part2() =>
        Enumerable.Range(0, _signal.Length).First(i => _signal.Substring(i, 14).Distinct().Count() == 14) + 14;
}
