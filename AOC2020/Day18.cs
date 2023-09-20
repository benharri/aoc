namespace AOC2020;

/// <summary>
///     Day 18: <a href="https://adventofcode.com/2020/day/18" />
/// </summary>
public sealed class Day18() : Day(2020, 18, "Operation Order")
{
    private List<string>? _expressions;

    public override void ProcessInput()
    {
        _expressions = Input.Select(line => line.Replace(" ", "")).ToList();
    }

    private static long Calculate(string expr, Func<char, int> precedence)
    {
        var postfixNotation = new StringBuilder();
        var postfixStack = new Stack<char>();

        foreach (var c in expr)
            if (char.IsDigit(c))
            {
                postfixNotation.Append(c);
            }
            else if (c == '(')
            {
                postfixStack.Push(c);
            }
            else if (c == ')')
            {
                while (postfixStack.Count > 0 && postfixStack.Peek() != '(')
                    postfixNotation.Append(postfixStack.Pop());

                postfixStack.TryPop(out _);
            }
            else
            {
                while (postfixStack.Count > 0 && precedence(c) <= precedence(postfixStack.Peek()))
                    postfixNotation.Append(postfixStack.Pop());

                postfixStack.Push(c);
            }

        while (postfixStack.Count > 0)
            postfixNotation.Append(postfixStack.Pop());

        var expressionStack = new Stack<long>();

        foreach (var c in postfixNotation.ToString())
            if (char.IsDigit(c))
            {
                expressionStack.Push((long)char.GetNumericValue(c));
            }
            else
            {
                var a = expressionStack.Pop();
                var b = expressionStack.Pop();

                if (c == '+') expressionStack.Push(a + b);
                if (c == '*') expressionStack.Push(a * b);
            }

        return expressionStack.Pop();
    }

    public override object Part1() =>
        _expressions!.Sum(expr => Calculate(expr, c => c is '+' or '*' ? 1 : 0));

    public override object Part2() =>
        _expressions!.Sum(expr => Calculate(expr, c => c switch { '+' => 2, '*' => 1, _ => 0 }));
}
