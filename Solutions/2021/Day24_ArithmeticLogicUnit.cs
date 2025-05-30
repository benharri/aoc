namespace Solutions._2021;

/// <summary>
/// Day 24: <a href="https://adventofcode.com/2021/day/24"/>
/// </summary>
public sealed class Day24ArithmeticLogicUnit() : Day(2021, 24, "Arithmetic Logic Unit")
{
    private readonly Dictionary<int, (int x, int y)> _keys = [];

    public override void ProcessInput()
    {
        var lines = Input.ToList();
        var pairs = Enumerable.Range(0, 14)
            .Select(i => (int.Parse(lines[i * 18 + 5][6..]), int.Parse(lines[i * 18 + 15][6..])))
            .ToList();

        var stack = new Stack<(int, int)>();
        foreach (var ((x, y), i) in pairs.Select((pair, i) => (pair, i)))
            if (x > 0)
                stack.Push((i, y));
            else
            {
                var (j, jj) = stack.Pop();
                _keys[i] = (j, jj + x);
            }
    }

    public override object Part1()
    {
        var output = new Dictionary<int, int>();

        foreach (var (key, (x, y)) in _keys)
        {
            output[key] = Math.Min(9, 9 + y);
            output[x] = Math.Min(9, 9 - y);
        }

        return long.Parse(output.OrderBy(x => x.Key).Select(x => x.Value).Join());
    }

    public override object Part2()
    {
        var output = new Dictionary<int, int>();

        foreach (var (key, (x, y)) in _keys)
        {
            output[key] = Math.Max(1, 1 + y);
            output[x] = Math.Max(1, 1 - y);
        }

        return long.Parse(output.OrderBy(x => x.Key).Select(x => x.Value).Join());
    }
}
