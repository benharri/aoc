namespace Solutions._2020;

/// <summary>
/// Day 10: <a href="https://adventofcode.com/2020/day/10" />
/// </summary>
public sealed class Day10AdapterArray() : Day(2020, 10, "Adapter Array")
{
    private int[]? _adapters;
    private long[]? _memo;

    public override void ProcessInput()
    {
        var parsed = Input.Select(int.Parse).ToArray();
        // add socket and device to the list
        _adapters = parsed.Concat([0, parsed.Max() + 3]).OrderBy(i => i).ToArray();
        _memo = new long[_adapters.Length];
    }

    private long Connections(int i)
    {
        if (i == _adapters!.Length - 1) _memo![i] = 1;
        if (_memo![i] > 0) return _memo[i];

        for (var j = i + 1; j <= i + 3 && j < _adapters.Length; j++)
            if (_adapters[j] - _adapters[i] <= 3)
                _memo[i] += Connections(j);

        return _memo[i];
    }

    public override object Part1()
    {
        var ones = 0;
        var threes = 0;

        for (var i = 0; i < _adapters!.Length - 1; i++)
            switch (_adapters[i + 1] - _adapters[i])
            {
                case 1:
                    ones++;
                    break;
                case 3:
                    threes++;
                    break;
                default: throw new("something went wrong");
            }

        return ones * threes;
    }

    public override object Part2() => Connections(0);
}
