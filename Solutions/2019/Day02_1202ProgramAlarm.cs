namespace Solutions._2019;

/// <summary>
/// Day 2: <a href="https://adventofcode.com/2019/day/2"/>
/// </summary>
// ReSharper disable once InconsistentNaming
public sealed class Day02_1202ProgramAlarm() : Day(2019, 2, "1202 Program Alarm")
{
    private IEnumerable<int>? _input;

    public override void ProcessInput() =>
        _input = Input.First().Split(',').Select(int.Parse);

    private int RunIntCode(int noun, int verb)
    {
        var v = _input!.ToList();
        v[1] = noun;
        v[2] = verb;

        for (var i = 0; v[i] != 99; i += 4)
            v[v[i + 3]] = v[i] switch
            {
                1 => v[v[i + 1]] + v[v[i + 2]],
                2 => v[v[i + 1]] * v[v[i + 2]],
                _ => throw new ArgumentOutOfRangeException(nameof(verb)),
            };

        return v[0];
    }

    public override object Part1() => RunIntCode(12, 2);

    public override object Part2()
    {
        for (var i = 0; i < 100; i++)
            for (var j = 0; j < 100; j++)
                if (RunIntCode(i, j) == 19690720)
                    return 100 * i + j;

        return default!;
    }
}
