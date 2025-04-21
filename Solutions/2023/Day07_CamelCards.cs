namespace Solutions._2023;

public class Day07_CamelCards() : Day(2023, 7, "Camel Cards")
{
    private List<(Hand hand, long bid)> _hands = [];
    private const string OrderedCards = "23456789TJQKA";

    public override void ProcessInput() =>
        _hands = Input
            .Select(line =>
            {
                var split = line.Split(' ');
                return (new Hand(split[0]), long.Parse(split[1]));
            })
            .ToList();

    public override object Part1() =>
        _hands
            .OrderBy(d => d.hand, new HandComparer(r => r))
            .Select((hand, i) => hand.bid * (i + 1))
            .Sum();

    public override object Part2() =>
        _hands
            .OrderBy(d => d.hand,
                new HandComparer(rank => rank == OrderedCards.IndexOf('J') ? 0 : rank + 1, useWilds: true))
            .Select((hand, i) => hand.bid * (i + 1))
            .Sum();

    private class HandComparer(Func<int, int> rankFunc, bool useWilds = false) : IComparer<Hand>
    {
        public int Compare(Hand? x, Hand? y)
        {
            if (x == null || y == null) return 0;

            var result = x.GetHandType(useWilds).CompareTo(y.GetHandType(useWilds));
            if (result != 0) return result;

            for (var i = 0; i < x.Cards.Count; i++)
            {
                result = rankFunc(x.Cards[i]).CompareTo(rankFunc(y.Cards[i]));
                if (result != 0) return result;
            }

            return 0;
        }
    }

    [Flags]
    public enum HandType
    {
        HighCard, OnePair, TwoPair, ThreeOfAKind, FullHouse, FourOfAKind, FiveOfAKind,
    }

    public class Hand(string value)
    {
        public List<int> Cards => value.Select(c => OrderedCards.IndexOf(c)).ToList();

        public HandType GetHandType(bool useWilds = false)
        {
            int maxRank = 0, pairs = 0, wildCount = 0;
            var ranks = new int[13];

            foreach (var card in Cards)
            {
                if (useWilds && card == OrderedCards.IndexOf('J'))
                {
                    wildCount++;
                    continue;
                }

                var count = ++ranks[card];
                maxRank = Math.Max(count, maxRank);

                switch (count)
                {
                    case 2: pairs++; break;
                    case 3: pairs--; break;
                }
            }

            return maxRank switch
            {
                5 => HandType.FiveOfAKind,
                4 => wildCount > 0 ? HandType.FiveOfAKind : HandType.FourOfAKind,
                3 => wildCount switch
                {
                    2 => HandType.FiveOfAKind,
                    1 => HandType.FourOfAKind,
                    _ => pairs > 0 ? HandType.FullHouse : HandType.ThreeOfAKind,
                },
                2 => pairs switch
                {
                    > 1 => wildCount > 0 ? HandType.FullHouse : HandType.TwoPair,
                    1 => wildCount switch
                    {
                        1 => HandType.ThreeOfAKind,
                        2 => HandType.FourOfAKind,
                        _ => wildCount > 2 ? HandType.FiveOfAKind : HandType.OnePair,
                    },
                    _ => HandType.HighCard,
                },
                _ => wildCount switch
                {
                    1 => HandType.OnePair,
                    2 => HandType.ThreeOfAKind,
                    3 => HandType.FourOfAKind,
                    4 => HandType.FiveOfAKind,
                    5 => HandType.FiveOfAKind,
                    _ => HandType.HighCard,
                },
            };
        }
    }
}
