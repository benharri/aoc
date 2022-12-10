namespace AOC2022;

/// <summary>
/// Day 10: <a href="https://adventofcode.com/2022/day/10"/>
/// </summary>
public sealed class Day10 : Day
{
    private readonly List<int> _interestingSignals = new();
    private List<char>? _charMap;

    public Day10() : base(2022, 10, "Cathode-Ray Tube")
    {
    }

    public override void ProcessInput()
    {
        int x = 1, cycle = 1;
        _charMap = Enumerable.Range(0, 6 * 40).Select(_ => ' ').ToList();

        foreach (var line in Input)
        {
            if (line.StartsWith("addx"))
            {
                CpuTick(ref cycle, x);
                CpuTick(ref cycle, x);
                x += int.Parse(line.Split(' ')[1]);
            }
            else
            {
                CpuTick(ref cycle, x);
            }
        }
    }

    private void CpuTick(ref int cycle, int x)
    {
        if ((cycle - 20) % 40 == 0)
            _interestingSignals.Add(x * cycle);

        if (new[] { x - 1, x, x + 1 }.Contains((cycle - 1) % 40))
            _charMap![cycle] = '█';

        cycle++;
    }

    public override object Part1() => _interestingSignals.Sum();

    public override object Part2() =>
        _charMap!.Chunk(40).Aggregate("", (s, chars) => $"{s}{Environment.NewLine}{new string(chars)}");
}