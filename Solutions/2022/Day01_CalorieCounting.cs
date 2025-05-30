using MoreLinq.Extensions;

namespace Solutions._2022;

/// <summary>
/// Day 1: <a href="https://adventofcode.com/2022/day/1"/>
/// </summary>
public sealed class Day01CalorieCounting() : Day(2022, 1, "Calorie Counting")
{
    private List<List<int>>? _elfCalories;

    public override void ProcessInput() =>
        _elfCalories = Input
            .Split("")
            .Select(e => e.Select(int.Parse).ToList())
            .OrderByDescending(e => e.Sum())
            .ToList();

    public override object Part1() => _elfCalories!.First().Sum();

    public override object Part2() => _elfCalories!.Take(3).Sum(e => e.Sum());
}
