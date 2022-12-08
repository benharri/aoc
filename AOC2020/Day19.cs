namespace AOC2020;

/// <summary>
///     Day 19: <a href="https://adventofcode.com/2020/day/19" />
/// </summary>
public sealed class Day19 : Day
{
    private string[]? _messages;
    private Dictionary<string, string[][]>? _rules;
    private Stack<string>? _stack;

    public Day19() : base(2020, 19, "Monster Messages")
    {
    }

    public override void ProcessInput()
    {
        _rules = Input.TakeWhile(l => !string.IsNullOrWhiteSpace(l))
            .Select(l => l.Split(':'))
            .Select(a => (key: a[0],
                val: a[1].Split('|', StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Split(' ', StringSplitOptions.RemoveEmptyEntries)).ToArray()))
            .ToDictionary(a => a.key, a => a.val);

        _messages = Input.Skip(_rules.Count + 1).ToArray();
        _stack = new();
    }

    private string MakeRegexExpression(string key)
    {
        if (_stack!.Count(s => s == key) > 10) return "x";
        _stack!.Push(key);

        var sub = string.Join("|", _rules![key].Select(test => test.Length switch
        {
            1 => test[0][0] == '"' ? test[0].Trim('"') : MakeRegexExpression(test[0]),
            _ => string.Join(string.Empty, test.Select(MakeRegexExpression))
        }));
        _stack.Pop();
        return _rules[key].Length > 1 ? $"({sub})" : sub;
    }

    public override object Part1()
    {
        var exp = new Regex($"^{MakeRegexExpression("0")}$");
        return _messages!.Count(m => exp.IsMatch(m));
    }

    public override object Part2()
    {
        // fix rules 8 and 11
        _rules!["8"] = new[] { new[] { "42" }, new[] { "42", "8" } };
        _rules["11"] = new[] { new[] { "42", "31" }, new[] { "42", "11", "31" } };
        var exp = new Regex($"^{MakeRegexExpression("0")}$");
        return _messages!.Count(m => exp.IsMatch(m));
    }
}
