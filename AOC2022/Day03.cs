namespace AOC2022;

/// <summary>
/// Day 3: <a href="https://adventofcode.com/2022/day/3"/>
/// </summary>
public sealed class Day03() : Day(2022, 3, "Rucksack Reorganization")
{
    public override object Part1() =>
        Input.Sum(rucksack => RankItem(rucksack.Chunk(rucksack.Length / 2).Aggregate<IEnumerable<char>>((a, b) => a.Intersect(b)).Single()));

    public override object Part2() =>
        Input.Chunk(3).Sum(group => RankItem(group.Aggregate<IEnumerable<char>>((a, b) => a.Intersect(b)).Single()));

    private static int RankItem(char item) => item - (char.IsUpper(item) ? '&' : '`');
}
