namespace Solutions._2024;

/// <summary>
/// <a href="https://adventofcode.com/2024/day/3">Day 3</a>
/// </summary>
public partial class Day03() : Day(2024, 3, "Mull It Over")
{
    [GeneratedRegex(@"mul\((\d{1,3}),(\d{1,3})\)")]
    private static partial Regex MulRegex();
    
    public override object Part1() =>
        MulRegex().Matches(string.Join("", Input))
            .Sum(m => int.Parse(m.Groups[1].ValueSpan) * int.Parse(m.Groups[2].ValueSpan));

    public override object Part2() => "";
    
    
}
