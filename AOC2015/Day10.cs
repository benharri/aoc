namespace AOC2015;

/// <summary>
/// Day 10: <see href="https://adventofcode.com/2015/day/10"/>
/// </summary>
public sealed class Day10 : Day
{
    private string _seed;

    public Day10() : base(2015, 10, "Puzzle Name")
    {
        _seed = Input.First();
    }

    public override object Part1()
    {
        for (var i = 0; i < 40; i++)
            _seed = string.Concat(LookAndSay(_seed));

        return _seed.Length;
    }

    public override object Part2()
    {
        for (var i = 0; i < 10; i++)
            _seed = string.Concat(LookAndSay(_seed));

        return _seed.Length;
    }

    public static IEnumerable<int> LookAndSay(string data)
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