using MoreLinq;

namespace AOC2023;

/// <summary>
/// Day  4: <a href="https://adventofcode.com/2023/day/ 4"/>
/// </summary>
public sealed class Day04() : Day(2023,  4, "Scratchcards")
{
    private IEnumerable<(int id, List<int> winningNums, List<int> drawnNums)> _cards;

    public override void ProcessInput()
    {
        _cards = Input.Select(line =>
        {
            var s = line.Split(": ");
            var id = int.Parse(s[0].Replace("Card ", ""));
            var s2 = s[1].Split('|');
            var f = s2[0].Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            var g = s2[1].Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            return (id, f.Select(int.Parse).ToList(), g.Select(int.Parse).ToList());
        });
    }

    public override object Part1() =>
        _cards.Sum(c =>
        {
            var count = c.winningNums.Intersect(c.drawnNums).Count();
            if (count == 0) return 0;
            return Math.Pow(2, count - 1);
        });

    public override object Part2()
    {
        return "";
    }
}
