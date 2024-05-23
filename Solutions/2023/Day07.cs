namespace Solutions._2023;

/// <summary>
/// <a href="https://adventofcode.com/2023/day/7">Day 7</a>
/// </summary>
public class Day07() : Day(2023, 7, "Camel Cards")
{
    private List<(string hand, long bid)>? _hands;

    public override void ProcessInput() =>
        _hands = Input.Select(line =>
        {
            var s = line.Split(' ', 2);
            return (s[0], long.Parse(s[1]));
        }).ToList();
    
    private static int PokerHandStrength(string argHand)
    {
        var s = argHand.GroupBy(c => c).OrderByDescending(g => g.Count()).ToList();
        return s.Count - s.First().Count();
    }
    
    private static int TieBreakerAtIndex(string s, int at) => "23456789TJKQA".IndexOf(s[at]);
    
    public override object Part1()
    {
        var orderedHands = _hands!
            .OrderByDescending(h => PokerHandStrength(h.hand))
            .ThenBy(h => TieBreakerAtIndex(h.hand, 0))
            .ThenBy(h => TieBreakerAtIndex(h.hand, 1))
            .ThenBy(h => TieBreakerAtIndex(h.hand, 2))
            .ThenBy(h => TieBreakerAtIndex(h.hand, 3))
            .ThenBy(h => TieBreakerAtIndex(h.hand, 4));

        return orderedHands
            .Select((hand, rank) => hand.bid * (rank + 1))
            .Sum();
    }

    public override object Part2() => "";
}
