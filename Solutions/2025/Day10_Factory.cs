using Microsoft.Z3;
using System.Globalization;
using System.Numerics;

namespace Solutions._2025;

/// <summary>
/// Day 10: <a href="https://adventofcode.com/2025/day/10"/>
/// </summary>
public sealed class Day10Factory() : Day(2025, 10, "Factory")
{
    private readonly List<Machine> _machines = [];

    private readonly record struct Machine(int TargetState, List<int[]> Buttons, List<int> Joltages)
    {
        public int[] ButtonMasks => Buttons.Select(b => b.Sum(i => 1 << i)).ToArray();
        public static Machine FromLine(string line)
        {
            var split = line.Split(' ');
            return new(
                int.Parse(split[0][1..^1].Replace('.', '0').Replace('#', '1').Reverse().Join(), NumberStyles.BinaryNumber),
                split[1..^1].Select(b => b[1..^1].Split(',').Select(int.Parse).ToArray()).ToList(),
                split[^1][1..^1].Split(',').Select(int.Parse).ToList()
            );
        }
    }

    public override void ProcessInput() => _machines.AddRange(Input.Select(Machine.FromLine));

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
                    if ((mask & 1) == 1)
                    {
                        // press the buttons!
                        pressedButtons ^= machine.ButtonMasks[i];
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

    public override object Part2() => _machines.Sum(MinimumButtonPresses);

    private static long MinimumButtonPresses(Machine machine)
    {
        using var ctx = new Context();
        using var opt = ctx.MkOptimize();

        var presses = Enumerable.Range(0, machine.Buttons.Count)
            .Select(i =>
            {
                var ic = ctx.MkIntConst($"p{i}");
                opt.Add(ctx.MkGe(ic, ctx.MkInt(0)));
                return ic;
            })
            .ToArray();

        for (var i = 0; i < machine.Joltages.Count; i++)
        {
            var affecting = presses.Where((_, j) => machine.Buttons[j].Contains(i)).ToArray();
            if (affecting.Length == 0) continue;

            opt.Add(ctx.MkEq(ctx.MkAdd(affecting.Cast<ArithExpr>()), ctx.MkInt(machine.Joltages[i])));
        }

        opt.MkMinimize(ctx.MkAdd(presses.Cast<ArithExpr>()));
        opt.Check();

        return presses.Sum(p => ((IntNum)opt.Model.Eval(p, true)).Int64);
    }
}
