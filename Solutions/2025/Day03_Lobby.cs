namespace Solutions._2025;

/// <summary>
/// Day 3: <a href="https://adventofcode.com/2025/day/3"/>
/// </summary>
public sealed class Day03Lobby() : Day(2025, 3, "Lobby")
{
    public override object Part1() => Input.Sum(LargestJoltage);

    private static int LargestJoltage(string line)
    {
        var max = 0;
        for (var i = 0; i < line.Length - 1; i++)
        {
            for (var j = i + 1; j < line.Length; j++)
            {
                var joltage = ((line[i] - '0') * 10) + line[j] - '0';
                if (joltage > max) max = joltage;
            }
        }

        return max;
    }

    public override object Part2() => Input.Sum(Largest12DigitJoltage);

    private static long Largest12DigitJoltage(string line)
    {
        var max = 0L;

        return max;
    }
}
