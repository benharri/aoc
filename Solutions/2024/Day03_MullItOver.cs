namespace Solutions._2024;

/// <summary>
/// <a href="https://adventofcode.com/2024/day/3">Day 3</a>
/// </summary>
public partial class Day03MullItOver() : Day(2024, 3, "Mull It Over")
{
    private string _input = "";

    [GeneratedRegex(@"mul\((\d{1,3}),(\d{1,3})\)")]
    private static partial Regex MulRegex();

    [GeneratedRegex(@"don't\(\)|do\(\)|mul\((\d{1,3}),(\d{1,3})\)")]
    private static partial Regex DoDontRegex();

    public override void ProcessInput() => _input = string.Join("", Input);

    public override object Part1() =>
        MulRegex().Matches(_input)
            .Sum(m => int.Parse(m.Groups[1].ValueSpan) * int.Parse(m.Groups[2].ValueSpan));

    public override object Part2()
    {
        var sum = 0;
        var enabled = true;

        foreach (Match m in DoDontRegex().Matches(_input))
        {
            if (m.ValueSpan is "do()") enabled = true;
            if (m.ValueSpan is "don't()") enabled = false;
            if (enabled && m.ValueSpan.StartsWith("mul("))
                sum += int.Parse(m.Groups[1].ValueSpan) * int.Parse(m.Groups[2].ValueSpan);
        }

        return sum;
    }
}
