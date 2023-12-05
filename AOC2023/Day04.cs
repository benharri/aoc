namespace AOC2023;

/// <summary>
/// <a href="https://adventofcode.com/2023/day/4">Day 4</a>
/// </summary>
public sealed class Day04() : Day(2023, 4, "Scratchcards")
{
    private readonly Dictionary<int, Card> _cards = [];

    public override void ProcessInput()
    {
        foreach (var line in Input)
        {
            var s = line.Replace("Card ", "").Split(": ", 2);
            var cardNums = s[1]
                .Split('|', 2)
                .Select(f =>
                    f.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToList()
                )
                .ToList();
            _cards[int.Parse(s[0])] = new(cardNums[0], cardNums[1]);
        }
    }

    public override object Part1() => _cards.Values.Sum(c => c.Score);

    public override object Part2()
    {
        var current = 1;
        while (_cards.ContainsKey(current))
        {
            for (var matchExtension = 1; matchExtension <= _cards[current].Matches; matchExtension++)
                _cards[current + matchExtension].Copies += _cards[current].Copies;
            current++;
        }

        return _cards.Values.Sum(v => v.Copies);
    }

    private record Card(List<int> WinningNums, List<int> DrawnNums)
    {
        public int Copies { get; set; } = 1;
        public int Matches => WinningNums.Intersect(DrawnNums).Count();
        public int Score => (int)Math.Pow(2, Matches - 1);
    }
}
