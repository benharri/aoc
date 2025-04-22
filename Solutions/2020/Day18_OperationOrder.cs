namespace Solutions._2020;

/// <summary>
/// Day 18: <a href="https://adventofcode.com/2020/day/18" />
/// </summary>
public sealed class Day18OperationOrder() : Day(2020, 18, "Operation Order")
{
    private List<string>? _expressions;

    public override void ProcessInput() =>
        _expressions = Input.Select(line => line.Replace(" ", "")).ToList();

    private static long Calculate(string expr, Func<char, int> precedence)
    {
        var postfixNotation = new StringBuilder();
        var postfixStack = new Stack<char>();

        foreach (var c in expr)
            if (char.IsAsciiDigit(c))
            {
                postfixNotation.Append(c);
            }
            else
                switch (c)
                {
                    case '(':
                        postfixStack.Push(c);
                        break;
                    case ')':
                        {
                            while (postfixStack.Count > 0 && postfixStack.Peek() != '(')
                                postfixNotation.Append(postfixStack.Pop());

                            postfixStack.TryPop(out _);
                            break;
                        }
                    default:
                        {
                            while (postfixStack.Count > 0 && precedence(c) <= precedence(postfixStack.Peek()))
                                postfixNotation.Append(postfixStack.Pop());

                            postfixStack.Push(c);
                            break;
                        }
                }

        while (postfixStack.Count > 0)
            postfixNotation.Append(postfixStack.Pop());

        var expressionStack = new Stack<long>();

        foreach (var c in postfixNotation.ToString())
            if (char.IsAsciiDigit(c))
            {
                expressionStack.Push((long)char.GetNumericValue(c));
            }
            else
            {
                var a = expressionStack.Pop();
                var b = expressionStack.Pop();

                switch (c)
                {
                    case '+':
                        expressionStack.Push(a + b);
                        break;
                    case '*':
                        expressionStack.Push(a * b);
                        break;
                }
            }

        return expressionStack.Pop();
    }

    public override object Part1() =>
        _expressions!.Sum(expr => Calculate(expr, c => c is '+' or '*' ? 1 : 0));

    public override object Part2() =>
        _expressions!.Sum(expr => Calculate(expr, c => c switch { '+' => 2, '*' => 1, _ => 0 }));
}
