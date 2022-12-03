using System.ComponentModel;

namespace AOC2022;

/// <summary>
/// Day 3: <see href="https://adventofcode.com/2022/day/3"/>
/// </summary>
public sealed class Day03 : Day
{
    public Day03() : base(2022, 3, "Rucksack Reorganization")
    {
    }

    public override object Part1()
    {
        var priority = 0;
        foreach (var line in Input)
        {
            var misPacked = line[..(line.Length / 2)].Intersect(line[(line.Length / 2)..]).Single();
            priority += misPacked - (char.IsUpper(misPacked) ? '&' : '`');
        }

        return priority;
    }

    public override object Part2()
    {
        var priority = 0;
        foreach (var group in Input.Chunk(3))
        {
            var missing = group[0].Intersect(group[1].Intersect(group[2])).Single();
            priority += missing - (char.IsUpper(missing) ? '&' : '`');
        }
        
        return priority;
    }
}
