using MoreLinq;

namespace Solutions._2022;

/// <summary>
/// Day 14: <a href="https://adventofcode.com/2022/day/14"/>
/// </summary>
public sealed class Day14RegolithReservoir() : Day(2022, 14, "Regolith Reservoir")
{
    private readonly Point2d<int> _start = (500, 0);
    private int _bottom;
    private HashSet<Point2d<int>> _walls = [];

    public override void ProcessInput()
    {
        _walls = Input
            .Select(input => input.Split(" -> ").Select(Point2d<int>.FromLine))
            .SelectMany(path => path.Pairwise((p1, p2) => p1.LinePointsTo(p2)).SelectMany(p => p))
            .ToHashSet();
        _bottom = _walls.Max(p => p.Y);
    }

    private static int PourSand(Point2d<int> start, int bottom, Func<Point2d<int>, bool> wall)
    {
        HashSet<Point2d<int>> sand = [];

        while (true)
        {
            var sandPos = PlaceSandGrain(start, bottom, p => wall(p) || sand.Contains(p));
            if (!sandPos.HasValue) break;
            sand.Add(sandPos.Value);
        }

        return sand.Count;
    }

    private static Point2d<int>? PlaceSandGrain(Point2d<int> start, int bottom, Func<Point2d<int>, bool> blocked)
    {
        if (blocked(start)) return null;

        var pos = start;
        while (pos.Y <= bottom)
        {
            var next = NextPositions(pos).FirstOrDefault(p => !blocked(p));
            if (next == default) return pos;
            pos = next;
        }

        return null;
    }

    private static IEnumerable<Point2d<int>> NextPositions(Point2d<int> point)
    {
        yield return point with { Y = point.Y + 1 };
        yield return new(point.X - 1, point.Y + 1);
        yield return new(point.X + 1, point.Y + 1);
    }



    public override object Part1() =>
        PourSand(_start, _bottom, _walls.Contains);

    public override object Part2() =>
        PourSand(_start, int.MaxValue, p => p.Y == _bottom + 2 || _walls.Contains(p));
}
