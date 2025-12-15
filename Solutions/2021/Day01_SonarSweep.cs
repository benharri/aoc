namespace Solutions._2021;

/// <summary>
/// Day 1: <a href="https://adventofcode.com/2021/day/1"/>
/// </summary>
public sealed class Day01SonarSweep() : Day(2021, 1, "Sonar Sweep")
{
    private readonly List<int> _readings = [];

    public override void ProcessInput() =>
        _readings.AddRange(Input.Select(int.Parse));

    public override object Part1() =>
        Enumerable.Range(0, _readings.Count - 1).Count(i => _readings[i + 1] > _readings[i]);

    public override object Part2() =>
        Enumerable.Range(0, _readings.Count - 3).Count(i => _readings[i + 3] > _readings[i]);
}
