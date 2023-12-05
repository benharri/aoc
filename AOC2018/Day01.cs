namespace AOC2018;

/// <summary>
/// Day 1: <a href="https://adventofcode.com/2018/day/1"/>
/// </summary>
public sealed class Day01() : Day(2018, 1, "Chronal Calibration")
{
    public override object Part1() => Input.Select(int.Parse).Sum();

    public override object Part2()
    {
        var frequencies = new HashSet<int>();
        var freq = 0;
        return Input.Select(int.Parse).Repeat().Any(f => !frequencies.Add(freq += f)) ? freq : 0;
    }
}
