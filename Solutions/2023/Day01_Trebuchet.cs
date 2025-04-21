namespace Solutions._2023;

/// <summary>
/// <a href="https://adventofcode.com/2023/day/2">Day 1</a>
/// </summary>
public class Day01Trebuchet() : Day(2023, 1, "Trebuchet?!")
{
    private static readonly List<string> SingleDigits =
        ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];

    public override object Part1() =>
        Input.Sum(line => (line.First(char.IsAsciiDigit) - '0') * 10 + (line.Last(char.IsAsciiDigit) - '0'));

    public override object Part2() =>
        Input.Sum(line =>
        {
            List<int> digits = [];

            for (var i = 0; i < line.Length; i++)
            {
                if (char.IsAsciiDigit(line[i]))
                {
                    digits.Add(item: line[i] - '0');
                    continue;
                }

                foreach (var (digit, spelled) in SingleDigits.Indexed())
                {
                    if (i + spelled.Length - 1 < line.Length && line[i..(i + spelled.Length)] == spelled)
                    {
                        digits.Add(digit);
                        break;
                    }
                }
            }

            return digits.First() * 10 + digits.Last();
        });
}
