namespace Solutions._2025;

/// <summary>
/// Day 8: <a href="https://adventofcode.com/2025/day/8"/>
/// </summary>
public sealed class Day08Playground() : Day(2025, 8, "Playground")
{
    private readonly PriorityQueue<(Point3d<int> one, Point3d<int> two), double> _priorityQueue = new();
    private HashSet<Point3d<int>> _boxes = [];
    private readonly List<HashSet<Point3d<int>>> _circuits = [];
    private long _largest3CircuitsMagnitude, _lastBoxXOffset;

    public override void ProcessInput()
    {
        _boxes = Input.Select(Point3d<int>.FromLine).ToHashSet();
        foreach (var p in _boxes.Pairs())
            _priorityQueue.Enqueue(p, p.First.EuclideanDistance(p.Second));

        var connections = 0;
        var toMake = UseTestInput ? 10 : 1000;
        while (_priorityQueue.TryDequeue(out var p, out _))
        {
            if (connections == toMake)
            {
                _largest3CircuitsMagnitude = _circuits.OrderByDescending(x => x.Count).Take(3).Aggregate(1L, (l, set) => l * set.Count);
            }

            var existingCircuits = _circuits.Where(c => c.Contains(p.one) || c.Contains(p.two)).ToList();
            switch (existingCircuits.Count)
            {
                case 0:
                    _circuits.Add([p.one, p.two]);
                    break;
                case 1:
                    var circuit = existingCircuits[0];
                    if (circuit.Contains(p.one) && circuit.Contains(p.two)) { /* do nothing */ }
                    else if (!circuit.Add(p.one)) circuit.Add(p.two);

                    break;
                case 2:
                    existingCircuits[0].UnionWith(existingCircuits[1]);
                    _circuits.Remove(existingCircuits[1]);
                    break;
            }

            if (++connections > toMake && _circuits.Count == 1)
            {
                _lastBoxXOffset = p.one.X * p.two.X;
                break;
            }
        }
    }

    public override object Part1() => _largest3CircuitsMagnitude;

    public override object Part2() => _lastBoxXOffset;
}
