namespace AOC2022;

/// <summary>
/// Day 2: <a href="https://adventofcode.com/2022/day/2"/>
/// </summary>
public sealed class Day02 : Day
{
    private List<string[]>? _rounds;

    public Day02() : base(2022, 2, "Rock Paper Scissors")
    {
    }

    public override void ProcessInput() =>
        _rounds = Input.Select(line => line.Split(' ')).ToList();

    public override object Part1()
    {
        var score = 0;
        foreach (var round in _rounds!)
        {
            var me = round[1][0];
            var elf = round[0][0];
            score += me - 'W';
            
            if (me == 'X' && elf == 'C' ||
                me == 'Y' && elf == 'A' ||
                me == 'Z' && elf == 'B') score += 6;
            
            else if (elf - 'A' == me - 'X') score += 3;
        }

        return score;
    }

    public override object Part2()
    {
        var score = 0;
        foreach (var round in _rounds!)
        {
            var c = round[0][0];
            switch (round[1][0])
            {
                case 'X': // lose
                    score += "BCA".IndexOf(c) + 1;
                    break;
                case 'Y': // draw
                    score += c - 'A' + 4;
                    break;
                case 'Z': // win
                    score += "CAB".IndexOf(c) + 7;
                    break;
            }
        }

        return score;
    }
}
