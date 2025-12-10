using System.Globalization;
using System.Numerics;

namespace Solutions._2025;

/// <summary>
/// Day 10: <a href="https://adventofcode.com/2025/day/10"/>
/// </summary>
public sealed class Day10Factory() : Day(2025, 10, "Factory")
{
    private readonly List<Machine> _machines = [];

    private record struct Machine(int TargetState, List<int> Buttons)
    {
        public static Machine FromLine(string line)
        {
            var split = line.Split(' ');
            return new(
                int.Parse(split[0].TrimStart('[').TrimEnd(']').Replace('.', '0').Replace('#', '1').Reverse().Join(),
                    NumberStyles.BinaryNumber),
                split[1..^1]
                    .Select(b => b.TrimStart('(').TrimEnd(')').Split(',').Select(int.Parse).Sum(d => 1 << d))
                    .ToList()
            );
        }
    }

    public override void ProcessInput()
    {
        _machines.AddRange(Input.Select(Machine.FromLine));
    }

    public override object Part1()
    {
        var minPresses = 0;
        foreach (var machine in _machines)
        {
            var q = -1;
            foreach (var n in Enumerable.Range(0, 1 << machine.Buttons.Count).OrderBy(d => BitOperations.PopCount((uint)d)))
            {
                int mask = n, pressedButtons = 0, i = 0;
                while (mask != 0)
                {
                    if ((mask & 1) != 0)
                    {
                        // press the buttons!
                        pressedButtons ^= machine.Buttons[i];
                    }

                    mask >>= 1;
                    i++;
                }

                if ((pressedButtons ^ machine.TargetState) == 0)
                {
                    q = n;
                    break;
                }
            }

            if (q == -1) throw new();
            minPresses += BitOperations.PopCount((uint)q);
        }
        
        return minPresses;
    }

    public override object Part2() => "";
}
