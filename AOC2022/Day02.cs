namespace AOC2022;

/// <summary>
/// Day 2: <a href="https://adventofcode.com/2022/day/2"/>
/// </summary>
public sealed class Day02() : Day(2022, 2, "Rock Paper Scissors")
{
    private int _score1;
    private int _score2;

    public override void ProcessInput()
    {
        foreach (var line in Input)
        {
            int a = line[0] - 'A', b = line[2] - 'X';
            _score1 += 1 + b + (4 + b - a) % 3 * 3;
            _score2 += 1 + b * 3 + (2 + b + a) % 3;
        }
    }

    public override object Part1() => _score1;
    public override object Part2() => _score2;
}
