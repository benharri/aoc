namespace Solutions._2020;

/// <summary>
///     Day 13: <a href="https://adventofcode.com/2020/day/13" />
/// </summary>
public sealed class Day13ShuttleSearch() : Day(2020, 13, "Shuttle Search")
{
    private long[]? _buses;
    private long _earliest;
    private string[]? _fullSchedule;

    public override void ProcessInput()
    {
        _earliest = long.Parse(Input.First());
        _fullSchedule = Input.Last().Split(',');
        _buses = _fullSchedule.Where(c => c != "x").Select(long.Parse).ToArray();
    }

    public override object Part1()
    {
        for (var i = _earliest; ; i++)
            if (_buses!.Any(b => i % b == 0))
            {
                var bus = _buses!.First(b => i % b == 0);
                return bus * (i - _earliest);
            }
    }

    public override object Part2()
    {
        var i = 0;
        long result = 1, multiplier = 1;

        foreach (var id in _fullSchedule!)
        {
            if (id != "x")
            {
                var increment = long.Parse(id);
                while (((result += multiplier) + i) % increment != 0)
                {
                }

                multiplier *= increment;
            }

            i++;
        }

        return result;
    }
}
