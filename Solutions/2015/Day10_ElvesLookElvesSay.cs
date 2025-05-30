namespace Solutions._2015;

/// <summary>
/// Day 10: <a href="https://adventofcode.com/2015/day/10"/>
/// </summary>
public sealed class Day10ElvesLookElvesSay() : Day(2015, 10, "Elves Look, Elves Say")
{
    private string? _seed;

    public override void ProcessInput() => _seed = Input.First();

    public override object Part1()
    {
        for (var i = 0; i < 40; i++)
            _seed = string.Concat(LookAndSay(_seed!));

        return _seed!.Length;
    }

    public override object Part2()
    {
        for (var i = 0; i < 10; i++)
            _seed = string.Concat(LookAndSay(_seed!));

        return _seed!.Length;
    }

    private static IEnumerable<int> LookAndSay(string data)
    {
        var currentDigit = data[0];
        int count = 1, place = 1;

        while (place < data.Length)
        {
            if (data[place] == currentDigit) count++;
            else
            {
                yield return count;
                yield return currentDigit - '0';
                currentDigit = data[place];
                count = 1;
            }

            place++;
        }

        yield return count;
        yield return currentDigit - '0';
    }
}
