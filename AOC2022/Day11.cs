using MoreLinq;

namespace AOC2022;

/// <summary>
/// Day 11: <a href="https://adventofcode.com/2022/day/11"/>
/// </summary>
public sealed class Day11 : Day
{
    private Monkey[]? _monkeys;
    private long _lcm;

    public Day11() : base(2022, 11, "Monkey in the Middle")
    {
    }

    private void DoRound(bool part1 = true)
    {
        foreach (var monkey in _monkeys!)
        {
            while (monkey.Items.Any())
            {
                var item = monkey.Items.Dequeue();
                item = monkey.Operation(item);
                if (part1) item /= 3;
                item %= _lcm;
                
                monkey.InspectionCount++;
                var dest = item % monkey.ModTest == 0 ? monkey.TrueDest : monkey.FalseDest;
                _monkeys[dest].Items.Enqueue(item);
            }
        }
    }

    public override void ProcessInput()
    {
        _monkeys = Input.Split("").Select(Monkey.FromLines).ToArray();
        _lcm = _monkeys!.Aggregate(1L, (i, monkey) => i * monkey.ModTest);
    }

    private long MonkeyBusiness() =>
        _monkeys!.OrderByDescending(m => m.InspectionCount).Take(2)
            .Aggregate(1L, (i, monkey) => i * monkey.InspectionCount);

    public override object Part1()
    {
        foreach (var _ in Enumerable.Range(0, 20)) DoRound();
        return MonkeyBusiness();
    }

    public override object Part2()
    {
        ProcessInput();
        foreach (var _ in Enumerable.Range(0, 10_000)) DoRound(part1: false);
        return MonkeyBusiness();
    }

    private class Monkey
    {
        public Queue<long> Items { get; private set; } = new();
        public Func<long, long> Operation { get; private set; } = _ => 0L;
        public long ModTest { get; private set; }
        public int TrueDest { get; private set; }
        public int FalseDest { get; private set; }
        public long InspectionCount { get; set; }

        public static Monkey FromLines(IEnumerable<string> lines)
        {
            var m = new Monkey { InspectionCount = 0 };
            foreach (var line in lines.Select(l => l.Trim()))
            {
                if (line.StartsWith("Starting items: "))
                    m.Items = new(line.Split("Starting items: ")[1].Split(", ").Select(long.Parse));
                else if (line.StartsWith("Operation: "))
                {
                    var s = line.Split("Operation: new = old ")[1];
                    if (long.TryParse(s[2..], out var amount))
                        m.Operation = s[0] switch
                        {
                            '*' => i => i * amount,
                            '+' => i => i + amount,
                            _ => throw new ArgumentOutOfRangeException(line, "invalid operation")
                        };
                    else m.Operation = i => i * i;
                }
                else if (line.StartsWith("Test: "))
                    m.ModTest = long.Parse(line.Split("Test: divisible by ")[1]);
                else if (line.StartsWith("If true: "))
                    m.TrueDest = int.Parse(line.Split(' ')[5]);
                else if (line.StartsWith("If false: "))
                    m.FalseDest = int.Parse(line.Split(' ')[5]);
            }

            return m;
        }
    }
}