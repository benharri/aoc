namespace Solutions._2020;

/// <summary>
///     Day 6: <a href="https://adventofcode.com/2020/day/6" />
/// </summary>
public sealed class Day06CustomCustoms() : Day(2020, 6, "Custom Customs")
{
    private int _countPart1;
    private int _countPart2;

    public override void ProcessInput()
    {
        var alphabet = "abcedfghijklmnopqrstuvwxyz".ToCharArray();
        _countPart1 = 0;
        _countPart2 = 0;
        var s = new HashSet<char>();
        var lines = new HashSet<string>();
        foreach (var line in Input)
        {
            if (line == "")
            {
                _countPart1 += s.Count;
                _countPart2 += alphabet.Count(a => lines.All(l => l.Contains(a)));
                s.Clear();
                lines.Clear();
                continue;
            }

            foreach (var c in line)
                s.Add(c);
            lines.Add(line);
        }

        if (s.Count != 0)
        {
            _countPart1 += s.Count;
            _countPart2 += alphabet.Count(a => lines.All(l => l.Contains(a)));
        }
    }

    public override object Part1() => _countPart1;

    public override object Part2() => _countPart2;
}
