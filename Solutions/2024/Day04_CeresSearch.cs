namespace Solutions._2024;

/// <summary>
/// <a href="https://adventofcode.com/2024/day/4">Day 4</a>
/// </summary>
public sealed class Day04CeresSearch() : Day(2024, 4, "Ceres Search")
{
    private char[][] _grid = [];

    private static readonly List<(int dx, int dy)> Directions =
    [
        (-1, -1), (-1, 0), (-1, 1),
        (0, -1), (0, 1),
        (1, -1), (1, 0), (1, 1),
    ];

    private static bool OutOfBounds(char[][] grid, int x, int y) =>
        x < 0 || x >= grid[0].Length || y < 0 || y >= grid.Length;

    public override void ProcessInput() => _grid = Input.Select(line => line.ToArray()).ToArray();

    public override object Part1()
    {
        var count = 0;

        for (var y = 0; y < _grid.Length; y++)
        for (var x = 0; x < _grid[0].Length; x++)
            if (_grid[y][x] == 'X')
            {
                foreach (var (dx, dy) in Directions)
                {
                    int magnitude = 1, newY = y + dy, newX = x + dx;
                    if (OutOfBounds(_grid, newX, newY)) continue;

                    while (_grid[newY][newX] == "XMAS"[magnitude])
                    {
                        if (++magnitude > 3)
                        {
                            count++;
                            break;
                        }

                        newY += dy;
                        newX += dx;

                        if (OutOfBounds(_grid, newX, newY)) break;
                    }
                }
            }

        return count;
    }


    public override object Part2()
    {
        var count = 0;

        for (var y = 1; y < _grid.Length - 1; y++)
        for (var x = 1; x < _grid[0].Length - 1; x++)
            if (_grid[y][x] == 'A')
                if (((_grid[y - 1][x - 1] == 'M' && _grid[y + 1][x + 1] == 'S')
                     || (_grid[y - 1][x - 1] == 'S' && _grid[y + 1][x + 1] == 'M'))
                    && ((_grid[y + 1][x - 1] == 'M' && _grid[y - 1][x + 1] == 'S')
                        || (_grid[y + 1][x - 1] == 'S' && _grid[y - 1][x + 1] == 'M')))
                    count++;

        return count;
    }
}
