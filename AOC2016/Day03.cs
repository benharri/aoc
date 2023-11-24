namespace AOC2016;

/// <summary>
/// Day 3: <a href="https://adventofcode.com/2016/day/3"/>
/// </summary>
public sealed class Day03() : Day(2016, 3, "Squares With Three Sides")
{
    private List<List<int>> _triangles = null!;

    public override void ProcessInput()
    {
        _triangles = Input
            .Select(line => line.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList())
            .ToList();
    }

    public override object Part1() =>
        _triangles.Count(triangle => triangle[0] + triangle[1] > triangle[2] &&
                                     triangle[0] + triangle[2] > triangle[1] &&
                                     triangle[1] + triangle[2] > triangle[0]);

    public override object Part2() => "";
}