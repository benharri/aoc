namespace AOC2023;

public class Day01() : Day(2023, 1, "Puzzle Name")
{
	private static readonly List<string> _singleDigits = 
		["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];

	public override void ProcessInput()
	{
	}

	public override object Part1() =>
		Input.Sum(line => (line.First(char.IsDigit) - '0') * 10 + (line.Last(char.IsDigit) - '0'));

	public override object Part2()
	{
		return Input.Sum(line =>
		{
			List<int> digits = new();

			for (var i = 0; i < line.Length; i++)
			{
				if (char.IsDigit(line[i]))
				{
					digits.Add(item: line[i] - '0');
					continue;
				}

				foreach (var (digit, spelled) in _singleDigits.Indexed())
				{
					if (i + spelled.Length - 1 >= line.Length || line[i..(i + spelled.Length)] != spelled)
						continue;

					digits.Add(digit);
					break;
				}
			}

			return digits.First() * 10 + digits.Last();
		});
	}
}