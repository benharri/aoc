namespace AOC2022;

/// <summary>
/// Day 1: <see href="https://adventofcode.com/2022/day/1"/>
/// </summary>
public sealed class Day01 : Day
{
    private readonly List<List<int>> _elfCalories = new();

    public Day01() : base(2022, 1, "Day 1 Puzzle Name")
    {
        var elf = new List<int>();

        foreach (var line in Input)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                _elfCalories.Add(elf);
                elf = new();
            }
            else
                elf.Add(int.Parse(line));
        }

        if (elf.Any()) _elfCalories.Add(elf);
    }

    public override object Part1()
    {
        return _elfCalories.OrderByDescending(e => e.Sum()).First().Sum();
    }

    public override object Part2()
    {
        return _elfCalories.OrderByDescending(e => e.Sum()).Take(3).Sum(e => e.Sum());
    }
}