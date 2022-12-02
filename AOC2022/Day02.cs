namespace AOC2022;

/// <summary>
/// Day 2: <a href="https://adventofcode.com/2022/day/2"/>
/// </summary>
public sealed class Day02 : Day
{
    private readonly List<string[]> _rounds;

    public Day02() : base(2022, 2, "Rock Paper Scissors")
    {
        _rounds = Input.Select(line => line.Split(' ')).ToList();
    }

    public override object Part1()
    {
        var score = 0;
        foreach (var round in _rounds)
        {
            score += round[1][0] - 'W';

            if (round[1][0] == 'X' && round[0][0] == 'C' ||
                round[1][0] == 'Y' && round[0][0] == 'A' ||
                round[1][0] == 'Z' && round[0][0] == 'B') score += 6;
            
            else if (round[0][0] - 'A' == round[1][0] - 'X') score += 3;
        }

        return score;
    }

    public override object Part2()
    {
        var score = 0;
        foreach (var round in _rounds)
        {
            var c = round[0][0];
            switch (round[1][0])
            {
                case 'X': // lose
                    if (c == 'A') score += 3;
                    if (c == 'B') score++;
                    if (c == 'C') score += 2;
                    break;
                case 'Y': // draw
                    score += c - 'A' + 4;
                    break;
                case 'Z': // win
                    score += 6;
                    if (c == 'A') score += 2;
                    if (c == 'B') score += 3;
                    if (c == 'C') score++;
                    break;
            }
        }

        return score;
    }
}