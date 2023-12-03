namespace AOC2023;

/// <summary>
/// Day  3: <a href="https://adventofcode.com/2023/day/ 3"/>
/// </summary>
public sealed class Day03() : Day(2023, 3, "Gear Ratios")
{
    private readonly List<Number> _numbers = [];
    private readonly List<Symbol> _symbols = [];

    public override void ProcessInput()
    {
        var input = Input.ToList();
        List<int> digits = [];

        for (var row = 0; row < input.Count; row++)
        {
            Number currentNumber = new();

            for (var col = 0; col < input[row].Length; col++)
            {
                var c = input[row][col];
                if (c == '.') continue;

                if (char.IsAsciiDigit(c))
                {
                    digits.Add(c - '0');
                    if (digits.Count == 1)
                        currentNumber.Start = (row, col);

                    while (col < input[row].Length - 1 && char.IsAsciiDigit(input[row][col + 1]))
                        digits.Add(input[row][++col] - '0');

                    currentNumber.End = (row, col);
                    currentNumber.Value = int.Parse(string.Concat(digits));
                    _numbers.Add(currentNumber);
                    currentNumber = new();
                    digits.Clear();
                }
                else _symbols.Add(new(input[row][col], (row, col)));
            }
        }
    }

    public override object Part1() =>
        _numbers
            .Where(n => _symbols.Any(s =>
                Math.Abs(s.Position.Row - n.Start.Row) <= 1
                && s.Position.Column >= n.Start.Column - 1
                && s.Position.Column <= n.End.Column + 1))
            .Sum(n => n.Value);

    public override object Part2() =>
        _symbols
            .Where(s => s.Value == '*')
            .Select(s => _numbers.Where(n =>
                    Math.Abs(s.Position.Row - n.Start.Row) <= 1
                    && s.Position.Column >= n.Start.Column - 1
                    && s.Position.Column <= n.End.Column + 1)
                .ToArray())
            .Where(gears => gears.Length == 2)
            .Sum(gears => gears[0].Value * gears[1].Value);

    private record struct Number(int Value, (int Row, int Column) Start, (int Row, int Column) End);

    private record struct Symbol(char Value, (int Row, int Column) Position);
}
