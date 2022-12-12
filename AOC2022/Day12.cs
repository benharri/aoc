namespace AOC2022;

/// <summary>
/// Day 12: <a href="https://adventofcode.com/2022/day/12"/>
/// </summary>
public sealed class Day12 : Day
{
    private readonly Dictionary<(int x, int y), int> _grid = new();
    private static readonly List<(int x, int y)> Directions = new() { (-1, 0), (1, 0), (0, -1), (0, 1) };
    private (int x, int y) _startCoord, _destCoord;

    public Day12() : base(2022, 12, "Hill Climbing Algorithm")
    {
    }

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

    private int ShortestDistance((int x, int y) startCoord)
    {
        var queue = new Queue<(int x, int y, int steps)>();
        var seen = new HashSet<(int x, int y)> { startCoord };
        queue.Enqueue((startCoord.x, startCoord.y, 0));

        while (queue.Any())
        {
            var (x, y, steps) = queue.Dequeue();
            if (_destCoord == (x, y)) return steps;

            foreach (var subPath in Directions
                         .Select(direction => (x + direction.x, y + direction.y))
                         .Where(s => _grid.ContainsKey(s))
                         .Where(s => _grid[s] <= _grid[(x, y)] + 1)
                         .Where(s => seen.Add(s)))
                queue.Enqueue((subPath.Item1, subPath.Item2, steps + 1));
        }

        return int.MaxValue;
    }

    public override object Part1() => ShortestDistance(_startCoord);
    public override object Part2() => _grid.WhereValue(v => v == 0).Min(g => ShortestDistance(g.Key));
}