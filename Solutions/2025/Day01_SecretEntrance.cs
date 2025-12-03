namespace Solutions._2025;

/// <summary>
/// Day 1: <a href="https://adventofcode.com/2025/day/1"/>
/// </summary>
public sealed class Day01SecretEntrance() : Day(2025, 1, "Secret Entrance")
{
    public override object Part1()
    {
        int current = 50, zeroCount = 0;
        
        foreach (var line in Input)
        {
            var value = int.Parse(line[1..]);
            
            switch (line[0])
            {
                case 'L': current -= value; break;
                case 'R': current += value; break;
            }

            current %= 100;

            if (current == 0) zeroCount++;
        }

        return zeroCount;
    }

    public override object Part2()
    {
        int current = 50, counter = 0;

        foreach (var turn in Input.Select(l => l.Replace("R", "").Replace("L", "-")).Select(int.Parse))
        {
            var next = current + turn;
            switch (next)
            {
                case <= 0:
                    counter += Math.Abs(next / 100);

                    if (next % 100 == 0)
                        counter++;

                    if (current == 0)
                        counter--;
                    break;
                case >= 100:
                    counter += next / 100;
                    break;
            }

            current = (next + 100) % 100;
        }

        return counter;
    }
}
