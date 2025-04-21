namespace Solutions._2020;

/// <summary>
///     Day 23: <a href="https://adventofcode.com/2020/day/23" />
/// </summary>
public sealed class Day23CrabCups() : Day(2020, 23, "Crab Cups")
{
    private readonly Dictionary<long, long> _cups = [];
    private ImmutableList<long>? _initialCups;
    private long[]? _move;
    private long _current;

    public override void ProcessInput()
    {
        _initialCups = Input.First().Select(c => long.Parse(c.ToString())).ToImmutableList();
        _current = _initialCups.First();
        _move = new long[3];
    }

    private void DoMoves(int turns)
    {
        for (var turn = 0; turn < turns; turn++)
        {
            var dest = _current - 1;
            if (dest == 0) dest = _cups.Count;

            for (var i = 0; i <= 2; i++)
            {
                var id = _cups[_current];
                var removedNext = _cups[id];
                _cups.Remove(id);
                _cups[_current] = removedNext;

                _move![i] = id;
            }

            while (_move!.Contains(dest))
            {
                dest--;
                if (dest == 0) dest = _cups.Count + 3;
            }

            for (var i = 0; i <= 2; i++)
            {
                var id = _cups[dest];
                _cups[dest] = _move![i];
                _cups.Add(_move[i], id);
                dest = _cups[dest];
            }

            _current = _cups[_current];
        }
    }

    public override object Part1()
    {
        for (var i = 0; i < _initialCups!.Count; i++)
            _cups[_initialCups[i]] = _initialCups[(i + 1) % _initialCups.Count];

        DoMoves(100);

        _current = 1;
        var result = new StringBuilder();
        while (_cups[_current] != 1)
        {
            result.Append(_cups[_current]);
            _current = _cups[_current];
        }

        return result;
    }

    public override object Part2()
    {
        _cups.Clear();
        for (var i = 0; i < _initialCups!.Count; i++)
            _cups[_initialCups[i]] = _initialCups[(i + 1) % _initialCups.Count];

        // add a million cups
        _cups[_initialCups.Last()] = 10;
        for (var i = 10; i < 1_000_000; i++)
            _cups.Add(i, i + 1);
        _cups[1_000_000] = _current = _initialCups.First();

        DoMoves(10_000_000);

        return (ulong)_cups[1] * (ulong)_cups[_cups[1]];
    }
}
