namespace Solutions._2022;

/// <summary>
/// Day 14: <a href="https://adventofcode.com/2022/day/14"/>
/// </summary>
public sealed class Day14RegolithReservoir() : Day(2022, 14, "Regolith Reservoir")
{
    private readonly (int x, int y) _start = (500, 0);
    private int _bottom;
    private HashSet<(int x, int y)>? _walls;

    public override void ProcessInput()
    {
        _walls = Input.Select(ParsePath).SelectMany(PathPoints).ToHashSet();
        _bottom = _walls.Select(p => p.y).Max();
    }

    private static HashSet<(int x, int y)> PourSand((int x, int y) start, int bottom, Func<(int x, int y), bool> wall)
    {
        HashSet<(int x, int y)> sand = [];

        while (true)
        {
            var sandPos = PlaceSandGrain(start, bottom, p => wall(p) || sand.Contains(p));
            if (!sandPos.HasValue) break;
            sand.Add(sandPos.Value);
        }

        return sand;
    }

    private static (int x, int y)? PlaceSandGrain((int x, int y) start, int bottom, Func<(int x, int y), bool> blocked)
    {
        if (blocked(start)) return null;

        var pos = start;
        while (pos.y <= bottom)
        {
            var next = NextPositions(pos).Where(p => !blocked(p)).Select(p => ((int x, int y)?)p).FirstOrDefault();
            if (!next.HasValue) return pos;
            pos = next.Value;
        }

        return null;
    }

    private static IEnumerable<(int x, int y)> NextPositions((int x, int y) point)
    {
        yield return point with { y = point.y + 1 };
        yield return new(point.x - 1, point.y + 1);
        yield return new(point.x + 1, point.y + 1);
    }

    private static IEnumerable<(int x, int y)> PathPoints(IEnumerable<(int x, int y)> path) =>
        path.Zip(path.Skip(1)).SelectMany(pair => LinePoints(pair.First, pair.Second));

    private static IEnumerable<(int x, int y)> LinePoints((int x, int y) start, (int x, int y) end)
    {
        if (start.x == end.x)
            return Enumerable.Range(Math.Min(start.y, end.y), Math.Abs(end.y - start.y) + 1)
                .Select(y => (start.x, y));

        if (start.y == end.y)
            return Enumerable.Range(Math.Min(start.x, end.x), Math.Abs(end.x - start.x) + 1)
                .Select(x => (x, start.y));

        return [];
    }

    private static IEnumerable<(int x, int y)> ParsePath(string input) =>
        input.Split(" -> ")
            .Select(p => p.Split(',', 2))
            .Select(p => (int.Parse(p[0]), int.Parse(p[1])));

    public override object Part1() =>
        PourSand(_start, _bottom, _walls!.Contains).Count;

    public override object Part2() =>
        PourSand(_start, int.MaxValue, p => p.y == _bottom + 2 || _walls!.Contains(p)).Count;
}
