namespace Solutions._2024;

public class Day04() : Day(2024, 4, "Ceres Search")
{
    private List<Direction> Directions =
    [
        new(-1, -1), new(-1, 0), new(-1, 1),
        new(0, -1), new(0, 1),
        new(1, -1), new(1, 0), new(1, 1),
    ];

    private class Direction(int dx, int dy)
    {
        public int Dy { get; } = dy;
        public int Dx { get; } = dx;
    }
    
    public override object Part1()
    {
        char[][] grid = Input.Select(line => line.ToArray()).ToArray();
        var count = IterateGrid(grid);
        return count;
    }

    private int IterateGrid(char[][] grid)
    {
        var count = 0;
        for (var y = 0; y < grid.Length; y++)
        {
            for (var x = 0; x < grid[y].Length; x++)
            {
                if (CheckAllDirections(grid, x, y)) count++;
            }
        }

        return count;
    }

    private bool CheckAllDirections(char[][] grid, int x, int y)
    {
        foreach (var direction in Directions)
        {
            
        }
    }

    public override object Part2() => "";
}
