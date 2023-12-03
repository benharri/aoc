namespace AOC2023;

/// <summary>
/// Day  3: <a href="https://adventofcode.com/2023/day/ 3"/>
/// </summary>
public sealed partial class Day03() : Day(2023, 3, "Gear Ratios")
{
    [GeneratedRegex(@"\d+")]
    private static partial Regex DigitsRegex();

    private List<string> _input;

    public override void ProcessInput()
    {
        _input = Input.ToList();
    }

    public override object Part1()
    {
        var sum = 0;

        for (var i = 0; i < _input.Count; i++)
        {
            var numbers = DigitsRegex()
                .Matches(_input[i])
                .Select(f => (index: f.Index, value: int.Parse(f.Value), length: f.Length));

            foreach (var num in numbers)
            {
                bool found = false;
                for (var y = i - 1; y <= i + 1; y++)
                {
                    if (found) break;
                    if (y < 0 || y >= _input.Count) continue;

                    for (var x = num.index - 1; x <= num.index + num.length; x++)
                    {
                        if (found) break;
                        if (x < 0 || x >= _input[i].Length) continue;

                        var c = _input[y][x];
                        if (c == '.' || char.IsDigit(c)) continue;
                        sum += num.value;
                        found = true;
                    }
                }
            }
        }

        return sum;
    }
}
