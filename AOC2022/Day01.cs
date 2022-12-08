using MoreLinq.Extensions;

namespace AOC2022;

/// <summary>
/// Day 1: <a href="https://adventofcode.com/2022/day/1"/>
/// </summary>
public sealed class Day01 : Day
{
    private List<List<int>>? _elfCalories;

    public Day01() : base(2022, 1, "Calorie Counting")
    {
    }
    
    public override void ProcessInput()
    {
        _elfCalories = Input
            .Split("")
            .Select(e => e.Select(int.Parse).ToList())
            .OrderByDescending(e => e.Sum())
            .ToList();
    }

    public override object Part1() => _elfCalories!.First().Sum();

    public override object Part2() => _elfCalories!.Take(3).Sum(e => e.Sum());
}
