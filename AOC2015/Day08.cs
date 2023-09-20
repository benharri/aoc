namespace AOC2015;

/// <summary>
/// Day 8: <a href="https://adventofcode.com/2015/day/8"/>
/// </summary>
public sealed partial class Day08() : Day(2015, 8, "Matchsticks")
{
    [GeneratedRegex("""^"(\\x..|\\.|.)*"$""")]
    private static partial Regex CharSet();

    public override void ProcessInput()
    {
    }

    private static int CharCount(string arg) => CharSet().Match(arg).Groups[1].Captures.Count;
    private static int EncodedCount(string arg) => 2 + arg.Sum(c => c is '\\' or '\"' ? 2 : 1);

    public override object Part1() => Input.Sum(line => line.Length) - Input.Sum(CharCount);

    public override object Part2() => Input.Sum(EncodedCount) - Input.Sum(line => line.Length);
}
