namespace AOC2015;

/// <summary>
/// Day 20: <a href="https://adventofcode.com/2015/day/20"/>
/// </summary>
public sealed class Day20() : Day(2015, 20, "Infinite Elves and Infinite Houses")
{
    private int _input;

    public override void ProcessInput() =>
        _input = int.Parse(Input.First());

    public override object Part1()
    {
        var houses = new int[1_000_000];
        for (var i = 1; i < houses.Length; i++)
        {
            for (var j = i; j < houses.Length; j += i)
            {
                houses[j] += i * 10;
            }
        }

        for (var i = 1; i < houses.Length; i++)
        {
            if (houses[i] >= _input) return i;
        }

        return "";
    }

    public override object Part2()
    {
        var min = int.MaxValue;
        var houses = new int[1_000_000];
        for (var i = 1; i < houses.Length; i++)
        {
            for (int j = i, c = 0; j < houses.Length && c < 50; j += i, c++)
            {
                if ((houses[j] += i * 11) >= _input)
                    min = Math.Min(min, j);
            }
        }

        return min;
    }
}
