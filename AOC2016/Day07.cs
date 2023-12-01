namespace AOC2016;

/// <summary>
/// Day 7: <a href="https://adventofcode.com/2016/day/7"/>
/// </summary>
public sealed partial class Day07() : Day(2016, 7, "Internet Protocol Version 7")
{
    [GeneratedRegex(@"\[[^\]]*\]")]
    private static partial Regex BracketsRegex();

    [GeneratedRegex(@"\[(\w*)\]")]
    private static partial Regex InsideBracketsRegex();

    public override void ProcessInput()
    {
    }

    private static bool SupportsTls(string input) =>
        !InsideBracketsRegex().Matches(input).Any(m => CheckAbba(m.ValueSpan)) &&
        BracketsRegex().Split(input).Any(v => CheckAbba(v));

    private static bool CheckAbba(ReadOnlySpan<char> input)
    {
        for (var i = 0; i < input.Length - 3; i++)
        {
            if (input[i] == input[i + 3] &&
                input[i + 1] == input[i + 2] &&
                input[i] != input[i + 1])
                return true;
        }

        return false;
    }

    private static bool SupportsSsl(string input)
    {
        foreach (var ip in BracketsRegex().Split(input))
            foreach (var aba in CheckAba(ip))
                foreach (var m in InsideBracketsRegex().Matches(input).Cast<Match>())
                    if (m.Value.Contains($"{aba[1]}{aba[0]}{aba[1]}"))
                        return true;

        return false;
    }

    private static IEnumerable<string> CheckAba(string input)
    {
        for (var i = 0; i < input.Length - 2; i++)
            if (input[i] == input[i + 2] && input[i] != input[i + 1])
                yield return input.Substring(i, 3);
    }

    public override object Part1() => Input.Count(SupportsTls);
    public override object Part2() => Input.Count(SupportsSsl);
}
