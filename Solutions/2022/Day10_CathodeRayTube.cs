namespace Solutions._2022;

/// <summary>
/// Day 10: <a href="https://adventofcode.com/2022/day/10"/>
/// </summary>
public sealed class Day10CathodeRayTube() : Day(2022, 10, "Cathode-Ray Tube")
{
    private readonly List<int> _interestingSignals = [];
    private readonly List<char> _charMap = Enumerable.Range(0, 6 * 40).Select(_ => ' ').ToList();

    public override void ProcessInput()
    {
        int x = 1, cycle = 1;
        foreach (var line in Input)
        {
            CpuTick(ref cycle, x);
            if (!line.StartsWith("addx")) continue;

            CpuTick(ref cycle, x);
            x += int.Parse(line.Split(' ')[1]);
        }
    }

    private void CpuTick(ref int cycle, int x)
    {
        if ((cycle - 20) % 40 == 0)
            _interestingSignals.Add(x * cycle);
        if (new[] { x - 1, x, x + 1 }.Contains((cycle - 1) % 40))
            _charMap[cycle] = '█';
        cycle++;
    }

    public override object Part1() => _interestingSignals.Sum();
    public override object Part2() => _charMap.Chunk(40).Select(s => new string(s)).Join("\n");
}
