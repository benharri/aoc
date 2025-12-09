namespace Solutions._2025;

/// <summary>
/// Day 9: <a href="https://adventofcode.com/2025/day/9"/>
/// </summary>
public sealed class Day09MovieTheater() : Day(2025, 9, "Movie Theater")
{
    public override object Part1() =>
        Input
            .Select(Point2dL.FromLine)
            .Pairs()
            .Select(tuple => tuple.First.AreaBetween(tuple.Second))
            .Max();

    public override object Part2() => "";
}
