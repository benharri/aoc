namespace Solutions._2020;

/// <summary>
/// Day 17: <a href="https://adventofcode.com/2020/day/17" />
/// </summary>
public sealed class Day17ConwayCubes() : Day(2020, 17, "Conway Cubes")
{
    private static readonly int[] NeighborIndices = [-1, 0, 1];
    private readonly Dictionary<(int x, int y, int z), char> _plane = [];
    private readonly Dictionary<(int x, int y, int z, int w), char> _plane4 = [];

    public override void ProcessInput()
    {
        var input = Input.ToList();

        for (var x = 0; x < 32; x++)
        for (var y = 0; y < 32; y++)
        for (var z = 0; z < 32; z++)
            _plane[(x, y, z)] = '.';

        for (var x = 0; x < 32; x++)
        for (var y = 0; y < 32; y++)
        for (var z = 0; z < 32; z++)
        for (var w = 0; w < 32; w++)
            _plane4[(x, y, z, w)] = '.';

        for (var y = 0; y < input.Count; y++)
        for (var x = 0; x < input[y].Length; x++)
            _plane[(x, y, 0)] = input[y][x];

        for (var y = 0; y < input.Count; y++)
        for (var x = 0; x < input[y].Length; x++)
            _plane4[(x, y, 0, 0)] = input[y][x];
    }

    private static int Neighbors(Dictionary<(int x, int y, int z), char> plane, int x, int y, int z)
    {
        var neighbors = 0;

        foreach (var i in NeighborIndices)
        foreach (var j in NeighborIndices)
        foreach (var k in NeighborIndices)
        {
            if (i == 0 && j == 0 && k == 0) continue;
            if (plane[((x + i) & 31, (y + j) & 31, (z + k) & 31)] == '#') neighbors++;
        }

        return neighbors;
    }

    private static Dictionary<(int x, int y, int z), char> Iterate(
        Dictionary<(int x, int y, int z), char> prev)
    {
        var next = new Dictionary<(int x, int y, int z), char>();

        for (var z = 0; z < 32; z++)
        for (var y = 0; y < 32; y++)
        for (var x = 0; x < 32; x++)
        {
            var active = Neighbors(prev, x, y, z);
            if (prev[(x, y, z)] == '#')
                next[(x, y, z)] = active is 2 or 3 ? '#' : '.';
            else
                next[(x, y, z)] = active == 3 ? '#' : '.';
        }

        return next;
    }

    private static int Neighbors4(Dictionary<(int x, int y, int z, int w), char> plane, int x, int y,
        int z, int w)
    {
        var neighbors = 0;

        foreach (var i in NeighborIndices)
        foreach (var j in NeighborIndices)
        foreach (var k in NeighborIndices)
        foreach (var l in NeighborIndices)
        {
            if (i == 0 && j == 0 && k == 0 && l == 0) continue;
            if (plane[((x + i) & 31, (y + j) & 31, (z + k) & 31, (w + l) & 31)] == '#') neighbors++;
        }

        return neighbors;
    }

    private static Dictionary<(int x, int y, int z, int w), char> Iterate4(
        Dictionary<(int x, int y, int z, int w), char> prev)
    {
        var next = new Dictionary<(int x, int y, int z, int w), char>();

        for (var z = 0; z < 32; z++)
        for (var y = 0; y < 32; y++)
        for (var x = 0; x < 32; x++)
        for (var w = 0; w < 32; w++)
        {
            var active = Neighbors4(prev, x, y, z, w);
            if (prev[(x, y, z, w)] == '#')
                next[(x, y, z, w)] = active is 2 or 3 ? '#' : '.';
            else
                next[(x, y, z, w)] = active == 3 ? '#' : '.';
        }

        return next;
    }

    public override object Part1() =>
        Enumerable.Range(0, 6).Aggregate(_plane, (current, _) => Iterate(current)).Values.Count(v => v == '#');

    public override object Part2() =>
        Enumerable.Range(0, 6).Aggregate(_plane4, (current, _) => Iterate4(current)).Values.Count(v => v == '#');
}
