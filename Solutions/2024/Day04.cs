namespace Solutions._2024;

/// <summary>
/// <a href="https://adventofcode.com/2024/day/4">Day 4</a>
/// </summary>
public sealed class Day04() : Day(2024, 4, "Ceres Search")
{
    private static readonly List<(int dx, int dy)> Directions =
    [
        (-1, -1), (-1, 0), (-1, 1),
        (0, -1), (0, 1),
        (1, -1), (1, 0), (1, 1),
    ];

    public override object Part1()
    {
        var grid = Input.Select(line => line.ToArray()).ToArray();
        var count = 0;

        for (var y = 0; y < grid.Length; y++)
        for (var x = 0; x < grid[0].Length; x++)
            if (grid[y][x] == 'X')
            {
                foreach (var (dx, dy) in Directions)
                {
                    int magnitude = 1, newY = y + dy, newX = x + dx;
                    if (OutOfBounds(grid, newX, newY)) continue;

                    while (grid[newY][newX] == "XMAS"[magnitude])
                    {
                        if (++magnitude > 3)
                        {
                            count++;
                            break;
                        }

                        newY += dy;
                        newX += dx;

                        if (OutOfBounds(grid, newX, newY)) break;
                    }
                }
            }

        return count;
    }

    private static bool OutOfBounds(char[][] grid, int x, int y) =>
        x < 0 || x >= grid[0].Length || y < 0 || y >= grid.Length;

    public override object Part2() => "";
}
