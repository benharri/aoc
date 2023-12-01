namespace AOC2019;

public sealed class Day10() : Day(2019, 10, "Monitoring Station")
{
    private HashSet<(int x, int y)>? _asteroids;
    private (int x, int y) _best = (x: -1, y: -1);
    private int _bestCanSee;

    public override void ProcessInput() =>
        _asteroids = Input
            .Select((r, y) => r.Select((c, x) => (x, y, isAsteroid: c == '#')).ToArray())
            .SelectMany(r => r)
            .Where(a => a.isAsteroid)
            .Select(a => (a.x, a.y))
            .ToHashSet();

    public override object Part1()
    {
        foreach (var asteroid in _asteroids!)
        {
            var canSee = _asteroids
                .Except(new[] { asteroid })
                .Select(a => (x: a.x - asteroid.x, y: a.y - asteroid.y))
                .GroupBy(a => Math.Atan2(a.y, a.x))
                .Count();

            if (canSee > _bestCanSee)
            {
                _best = asteroid;
                _bestCanSee = canSee;
            }
        }

        return _bestCanSee;
    }

    public override object Part2()
    {
        return _asteroids!
            .Where(a => a != _best)
            .Select(a =>
            {
                var xDist = a.x - _best.x;
                var yDist = a.y - _best.y;
                var angle = Math.Atan2(xDist, yDist);
                return (a.x, a.y, angle, dist: Math.Sqrt(xDist * xDist + yDist * yDist));
            })
            .ToLookup(a => a.angle)
            .OrderByDescending(a => a.Key)
            .Select(a => new Queue<(int x, int y, double angle, double dist)>(a.OrderBy(b => b.dist)))
            .Repeat()
            .SelectMany(GetValue)
            .Skip(199)
            .Take(1)
            .Select(a => a.x * 100 + a.y)
            .Single();

        static IEnumerable<(int x, int y, double angle, double dist)> GetValue(
            Queue<(int x, int y, double angle, double dist)> q)
        {
            if (q.Count > 0) yield return q.Dequeue();
        }
    }
}
