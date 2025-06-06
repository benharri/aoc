namespace Solutions._2020;

/// <summary>
/// Day 15: <a href="https://adventofcode.com/2020/day/15" />
/// </summary>
public sealed class Day15RambunctiousRecitation() : Day(2020, 15, "Rambunctious Recitation")
{
    private int[]? _turns;
    private int _current;
    private int _i;

    public override void ProcessInput()
    {
        var initial = Input.First().Split(',').Select(int.Parse).ToArray();
        _turns = new int[30_000_000];

        // seed array with initial values
        for (_i = 1; _i < initial.Length + 1; _i++)
            _turns[initial[_i - 1]] = _i;
    }

    public override object Part1()
    {
        for (; _i != 2020; _i++)
        {
            var next = _turns![_current] > 0 ? _i - _turns[_current] : 0;
            _turns[_current] = _i;
            _current = next;
        }

        return _current;
    }

    public override object Part2()
    {
        for (; _i != 30_000_000; _i++)
        {
            var next = _turns![_current] > 0 ? _i - _turns[_current] : 0;
            _turns[_current] = _i;
            _current = next;
        }

        return _current;
    }
}
