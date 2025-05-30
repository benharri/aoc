namespace Solutions._2015;

/// <summary>
/// Day 5: <a href="https://adventofcode.com/2015/day/5"/>
/// </summary>
public sealed partial class Day05DoesntHeHaveInternElvesForThis() : Day(2015, 5, "Doesn't He Have Intern-Elves For This?")
{
    private static readonly List<char> Vowels = ['a', 'e', 'i', 'o', 'u'];
    private List<string> _strings = [];

    [GeneratedRegex(@"(.)\1")]
    private static partial Regex DoubleLetter();

    [GeneratedRegex(@"(.).\1")]
    private static partial Regex LetterSandwich();

    [GeneratedRegex(@"(..).*\1")]
    private static partial Regex TwoPairs();

    public override void ProcessInput() =>
        _strings = Input.Where(line => !string.IsNullOrEmpty(line)).ToList();

    public override object Part1() =>
        _strings.Count(s =>
        {
            // bad substrings
            if (s.Contains("ab") || s.Contains("cd") || s.Contains("pq") || s.Contains("xy"))
                return false;

            // must have at least 3 vowels
            if (s.Count(c => Vowels.Contains(c)) < 3) return false;

            // must have a double-letter somewhere
            return DoubleLetter().Matches(s).Count >= 1;
        });

    public override object Part2() =>
        _strings.Count(s => LetterSandwich().Matches(s).Count >= 1 && TwoPairs().Matches(s).Count == 1);
}
