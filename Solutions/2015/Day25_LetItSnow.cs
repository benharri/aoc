namespace Solutions._2015;

/// <summary>
/// Day 25: <a href="https://adventofcode.com/2015/day/25"/>
/// </summary>
public sealed partial class Day25LetItSnow() : Day(2015, 25, "Let It Snow")
{
    [GeneratedRegex(@"\d+")]
    private static partial Regex NumbersRegex();

    private int _row, _col;

    public override void ProcessInput()
    {
        var s = NumbersRegex().Matches(Input.First()).Select(m => int.Parse(m.Value)).ToList();
        _row = s[0];
        _col = s[1];
    }

    public override object Part1()
    {
        var index = _row + _col - 2;
        index = index * (index + 1) / 2 + _col - 1;

        return Enumerable.Range(0, index)
            .Aggregate(20151125ul, (current, _) => current * 252533 % 33554393);
    }

    public override object Part2() => "";
}
