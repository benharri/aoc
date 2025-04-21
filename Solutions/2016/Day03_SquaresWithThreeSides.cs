namespace Solutions._2016;

/// <summary>
/// Day 3: <a href="https://adventofcode.com/2016/day/3"/>
/// </summary>
public sealed class Day03SquaresWithThreeSides() : Day(2016, 3, "Squares With Three Sides")
{
    private List<int[]> _triangles = null!;

    public override void ProcessInput() =>
        _triangles = Input
            .Select(line => line.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray())
            .ToList();

    public override object Part1() =>
        _triangles.Count(ValidTriangle);

    private static bool ValidTriangle(params int[] triangle) =>
        triangle[0] + triangle[1] > triangle[2] &&
        triangle[0] + triangle[2] > triangle[1] &&
        triangle[1] + triangle[2] > triangle[0];

    public override object Part2()
    {
        var cnt = 0;
        foreach (var chunk in _triangles.Chunk(3))
        {
            if (ValidTriangle(chunk[0][0], chunk[1][0], chunk[2][0])) cnt++;
            if (ValidTriangle(chunk[0][1], chunk[1][1], chunk[2][1])) cnt++;
            if (ValidTriangle(chunk[0][2], chunk[1][2], chunk[2][2])) cnt++;
        }

        return cnt;
    }
}
