namespace Solutions._2020;

/// <summary>
///     Day 3: <a href="https://adventofcode.com/2020/day/3" />
/// </summary>
public sealed class Day03TobogganTrajectory() : Day(2020, 3, "Toboggan Trajectory")
{
    private string[]? _grid;

    public override void ProcessInput() =>
        _grid = Input.ToArray();

    private long CountSlope(int dx, int dy)
    {
        long hits = 0;
        for (int x = 0, y = 0; y < _grid!.Length; y += dy, x = (x + dx) % _grid[0].Length)
            if (_grid[y][x] == '#')
                hits++;

        return hits;
    }

    public override object Part1() => CountSlope(3, 1);

    public override object Part2()
    {
        var xSlopes = new[] { 1, 3, 5, 7, 1 };
        var ySlopes = new[] { 1, 1, 1, 1, 2 };

        return xSlopes.Zip(ySlopes)
            .Select(s => CountSlope(s.First, s.Second))
            .Aggregate((acc, i) => acc * i);
    }
}
