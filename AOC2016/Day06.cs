namespace AOC2016;

/// <summary>
/// Day 6: <a href="https://adventofcode.com/2016/day/6"/>
/// </summary>
public sealed class Day06() : Day(2016, 6, "Signals and Noise")
{
    private List<string>? _input;

    public override void ProcessInput() => _input = Input.ToList();

    public override object Part1()
    {
        var answer = new char[_input![0].Length];

        for (var i = 0; i < _input[0].Length; i++)
        {
            answer[i] = _input
                .Select(l => l[i])
                .GroupBy(c => c)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .First();
        }

        return new string(answer);
    }

    public override object Part2()
    {
        var answer = new char[_input![0].Length];

        for (var i = 0; i < _input[0].Length; i++)
        {
            answer[i] = _input
                .Select(l => l[i])
                .GroupBy(c => c)
                .OrderBy(g => g.Count())
                .Select(g => g.Key)
                .First();
        }

        return new string(answer);
    }
}
