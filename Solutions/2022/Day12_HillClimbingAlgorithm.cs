namespace Solutions._2022;

/// <summary>
/// Day 12: <a href="https://adventofcode.com/2022/day/12"/>
/// </summary>
public sealed class Day12HillClimbingAlgorithm() : Day(2022, 12, "Hill Climbing Algorithm")
{
    private readonly Dictionary<Point2d<int>, int> _grid = [];
    private static readonly List<Point2d<int>> Directions = [(-1, 0), (1, 0), (0, -1), (0, 1)];
    private Point2d<int> _startCoord, _destCoord;

    public override void ProcessInput()
    {
        foreach (var (y, line) in Input.Indexed())
        foreach (var (x, c) in line.Indexed())
            switch (c)
            {
                case 'S':
                    _startCoord = (x, y);
                    _grid[(x, y)] = 0;
                    break;
                case 'E':
                    _destCoord = (x, y);
                    _grid[(x, y)] = 25;
                    break;
                default:
                    _grid[(x, y)] = c - 'a';
                    break;
            }
    }

    private int ShortestDistance(Point2d<int> startCoord, Point2d<int>? destCoord, int? destVal = null)
    {
        var queue = new Queue<(Point2d<int>, int steps)>();
        var seen = new HashSet<Point2d<int>> { startCoord };
        queue.Enqueue((startCoord, 0));

        while (queue.Count != 0)
        {
            var ((x, y), steps) = queue.Dequeue();
            if (destCoord == (x, y) || (destVal != null && _grid[(x, y)] == destVal)) return steps;

            foreach (var subPath in Directions
                         .Select(direction => (x + direction.X, y + direction.Y))
                         .Where(s => _grid.ContainsKey(s))
                         .Where(s => _grid[s] >= _grid[(x, y)] - 1)
                         .Where(s => seen.Add(s)))
                queue.Enqueue((subPath, steps + 1));
        }

        throw new("Path not found");
    }

    public override object Part1() => ShortestDistance(_destCoord, _startCoord);
    public override object Part2() => ShortestDistance(_destCoord, null, 0);
}
