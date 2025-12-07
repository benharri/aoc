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

    public override object Part2()
    {
        var total = 0L;

        foreach (var line in Input)
        {
            var joltage = "000000000000".ToCharArray();

            for (var i = 0; i < line.Length; i++)
            {
                for (int n = 0, m = joltage.Length - 1; n < joltage.Length; n++, m--)
                {
                    if (line[i] <= joltage[n] || line.Length - i - 1 < m) continue;

                    joltage[n] = line[i];
                    for (var j = n + 1; j < joltage.Length; j++)
                        joltage[j] = '0'; // zero out the remainder to compare properly
                    break;
                }
            }

            total += Util.ParseLongFast(joltage);
        }

        return total;
    }
}
