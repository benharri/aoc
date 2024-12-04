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
        List<string> info = [];
        for (var y = 0; y < grid.Length; y++)
        {
            Console.WriteLine();
            for (var x = 0; x < grid[0].Length; x++)
            {
                Console.Write(grid[y][x]);
                if (grid[y][x] == 'X')
                {
                    var magnitude = 1;
                    foreach (var (dx, dy) in Directions)
                    {
                        var newY = y + (dy * magnitude);
                        var newX = x + (dx * magnitude);
                        
                        if (newX < 0 || newX >= grid[0].Length || newY < 0 || newY >= grid.Length)
                        {
                            continue;
                        }
                        
                        while (grid[newY][newX] == "XMAS"[magnitude])
                        {
                            if (++magnitude == 4)
                            {
                                info.Add($"found starting at x{x},y{y} with direction dx{dx},dy{dy}");
                                count++;
                                magnitude = 1;
                                break;
                            }
                        }
                    }
                }
            }
        }

        Console.WriteLine();
        foreach (var i in info) Console.WriteLine(i);

        return count;
    }

    public override object Part2() => "";
}
