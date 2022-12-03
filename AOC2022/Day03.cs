namespace AOC2022;

/// <summary>
/// Day 3: <a href="https://adventofcode.com/2022/day/3"/>
/// </summary>
public sealed class Day03 : Day
{
    public Day03() : base(2022, 3, "Rucksack Reorganization")
    {
    }

    public override object Part1() =>
        Input.Sum(line => RankItem(line[..(line.Length / 2)].Intersect(line[(line.Length / 2)..]).Single()));

    public override object Part2() =>
        Input.Chunk(3).Sum(group => RankItem(group.Aggregate<IEnumerable<char>>((a, b) => a.Intersect(b)).Single()));

    private static int RankItem(char item) => item - (char.IsUpper(item) ? '&' : '`');
}