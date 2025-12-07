namespace Solutions._2025;

/// <summary>
/// Day 7: <a href="https://adventofcode.com/2025/day/7"/>
/// </summary>
public sealed class Day07Laboratories() : Day(2025, 7, "Laboratories")
{
    public override object Part1()
    {
        var inp = Input.ToArray();
        var tachyons = new bool[inp[0].Length];
        
        tachyons[inp[0].IndexOf('S')] = true;
        var count = 0;
        foreach (var line in inp.Skip(1))
        {
            for (var i = 0; i < tachyons.Length; i++)
            {
                if (tachyons[i] && line[i] == '^')
                {
                    tachyons[i] = false;
                    tachyons[i - 1] = tachyons[i + 1] = true;
                    count++;
                }
            }
        }
        
        return count;
    }

    public override object Part2() => "";
}
