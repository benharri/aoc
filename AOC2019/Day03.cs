namespace AOC2019;

public sealed class Day03 : Day
{
    private readonly IEnumerable<(int, int)> _intersections;
    private readonly List<Dictionary<(int, int), int>> _wires;

    public Day03() : base(2019, 3, "Crossed Wires")
    {
        _wires = Input.Select(ParseWire).ToList();
        _intersections = _wires[0].Keys.Intersect(_wires[1].Keys);
    }

    public override object Part1() => 
        _intersections.Min(x => Math.Abs(x.Item1) + Math.Abs(x.Item2));

    public override object Part2() =>
        // add 2 to count (0, 0) on both lines
        _intersections.Min(x => _wires[0][x] + _wires[1][x]) + 2;

    private static Dictionary<(int, int), int> ParseWire(string line)
    {
        var r = new Dictionary<(int, int), int>();
        int x = 0, y = 0, c = 0;

        foreach (var step in line.Split(','))
        {
            int i = 0, d = int.Parse(step[1..]);
            switch (step[0])
            {
                case 'U':
                    for (; i < d; i++) r.TryAdd((x, ++y), c++);
                    break;
                case 'D':
                    for (; i < d; i++) r.TryAdd((x, --y), c++);
                    break;
                case 'R':
                    for (; i < d; i++) r.TryAdd((++x, y), c++);
                    break;
                case 'L':
                    for (; i < d; i++) r.TryAdd((--x, y), c++);
                    break;
            }
        }

        return r;
    }
}
