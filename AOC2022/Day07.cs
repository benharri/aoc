namespace AOC2022;

/// <summary>
/// Day 7: <a href="https://adventofcode.com/2022/day/7"/>
/// </summary>
public sealed class Day07 : Day
{
    public Day07() : base(2022, 7, "No Space Left On Device")
    {
    }

    public override object Part1()
    {
        var dirs = new Dictionary<string, long>();
        foreach (var line in Input)
        {
            if (line.StartsWith('$'))
            {
                // command
                
            }
        }

    }

    public override object Part2() => "";
}
