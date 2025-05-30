namespace Solutions._2021;

/// <summary>
/// Day 10: <a href="https://adventofcode.com/2021/day/10"/>
/// </summary>
public sealed class Day10SyntaxScoring() : Day(2021, 10, "Syntax Scoring")
{
    private static readonly Dictionary<char, char> MatchedBrackets = new()
    {
        {'(', ')'},
        {'[', ']'},
        {'{', '}'},
        {'<', '>'},
    };

    private static readonly Dictionary<char, long> Scores = new()
    {
        { ')', 3 },
        { ']', 57 },
        { '}', 1197 },
        { '>', 25137 },
    };

    private static readonly Dictionary<char, long> ScoresPart2 = new()
    {
        { '(', 1 },
        { '[', 2 },
        { '{', 3 },
        { '<', 4 },
    };

    private readonly List<long> _scores2 = [];

    private long _score1;

    public override void ProcessInput()
    {
        _score1 = 0L;
        foreach (var line in Input)
        {
            var corrupt = false;
            var s = new Stack<char>();

            foreach (var c in line)
            {
                if (ScoresPart2.ContainsKey(c))
                {
                    s.Push(c);
                }
                else
                {
                    if (c == MatchedBrackets[s.Pop()]) continue;
                    _score1 += Scores[c];
                    corrupt = true;
                    break;
                }
            }

            if (corrupt) continue;
            var score2 = 0L;
            while (s.Count != 0)
            {
                score2 *= 5;
                score2 += ScoresPart2[s.Pop()];
            }

            _scores2.Add(score2);
        }
    }

    public override object Part1() => _score1;

    public override object Part2()
    {
        var sorted = _scores2.OrderBy(i => i).ToList();
        return sorted[sorted.Count / 2];
    }
}
