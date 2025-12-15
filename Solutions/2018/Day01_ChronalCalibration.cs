namespace Solutions._2018;

/// <summary>
/// Day 1: <a href="https://adventofcode.com/2018/day/1"/>
/// </summary>
public sealed class Day01ChronalCalibration() : Day(2018, 1, "Chronal Calibration")
{
    private readonly List<int> _frequencies = [];

    public override void ProcessInput() => _frequencies.AddRange(Input.Select(int.Parse));

    public override object Part1() => _frequencies.Sum();

    public override object Part2()
    {
        var seen = new HashSet<int>();
        var freq = 0;
        return _frequencies.Repeat().Any(f => !seen.Add(freq += f)) ? freq : 0;
    }
}
