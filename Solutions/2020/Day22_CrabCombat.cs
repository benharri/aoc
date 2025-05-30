namespace Solutions._2020;

/// <summary>
/// Day 22: <a href="https://adventofcode.com/2020/day/22" />
/// </summary>
public sealed class Day22CrabCombat() : Day(2020, 22, "Crab Combat")
{
    private readonly Queue<int> _deck1 = new();
    private readonly Queue<int> _deck2 = new();

    public override void ProcessInput() => Reset();

    private void Reset()
    {
        _deck1.Clear();
        _deck2.Clear();

        var player = 0;
        foreach (var line in Input)
        {
            if (line == "") continue;
            if (line.StartsWith("Player"))
            {
                player++;
                continue;
            }

            (player == 1 ? _deck1 : _deck2).Enqueue(int.Parse(line));
        }
    }

    private (Queue<int> deck1, Queue<int> deck2) Play(Queue<int> deck1, Queue<int> deck2, bool recursive = false)
    {
        var seen1 = new HashSet<string>();
        var seen2 = new HashSet<string>();

        while (deck1.Count != 0 && deck2.Count != 0)
        {
            if (recursive)
            {
                var deck1Hash = deck1.Join(",");
                var deck2Hash = deck2.Join(",");

                if (seen1.Contains(deck1Hash) || seen2.Contains(deck2Hash))
                {
                    // player1 wins
                    return (deck1, new());
                }

                seen1.Add(deck1Hash);
                seen2.Add(deck2Hash);
            }

            var play1 = deck1.Dequeue();
            var play2 = deck2.Dequeue();
            int winner;

            if (recursive && deck1.Count >= play1 && deck2.Count >= play2)
            {
                // play again
                var (r1, r2) = Play(deck1.Take(play1), deck2.Take(play2), recursive);
                winner = r1.Count > r2.Count ? 1 : 2;
            }
            else
                winner = play1 > play2 ? 1 : 2;

            if (winner == 1)
            {
                deck1.Enqueue(play1);
                deck1.Enqueue(play2);
            }
            else
            {
                deck2.Enqueue(play2);
                deck2.Enqueue(play1);
            }
        }

        return (deck1, deck2);
    }

    private (Queue<int> deck1, Queue<int> deck2) Play(IEnumerable<int> enumerable1, IEnumerable<int> enumerable2,
        bool recursive) =>
        Play(new(enumerable1), new(enumerable2), recursive);

    private static int CalculateScore(Queue<int> deck) =>
        deck.Reverse().Zip(Enumerable.Range(1, deck.Count), (a, b) => a * b).Sum();

    public override object Part1()
    {
        var (deck1, deck2) = Play(_deck1, _deck2);
        return CalculateScore(deck1.Count == 0 ? deck2 : deck1);
    }

    public override object Part2()
    {
        Reset();
        var (deck1, deck2) = Play(_deck1, _deck2, recursive: true);
        return CalculateScore(deck1.Count == 0 ? deck2 : deck1);
    }
}
