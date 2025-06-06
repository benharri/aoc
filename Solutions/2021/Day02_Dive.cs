namespace Solutions._2021;

/// <summary>
/// Day 2: <a href="https://adventofcode.com/2021/day/2"/>
/// </summary>
public sealed class Day02Dive() : Day(2021, 2, "Dive!")
{
    public override object Part1()
    {
        int horiz = 0, depth = 0;
        foreach (var line in Input)
        {
            var s = line.Split(' ');
            var x = int.Parse(s[1]);
            switch (s[0])
            {
                case "forward":
                    horiz += x;
                    break;
                case "down":
                    depth += x;
                    break;
                case "up":
                    depth -= x;
                    break;
            }
        }

        return horiz * depth;
    }

    public override object Part2()
    {
        int aim = 0, depth = 0, horiz = 0;
        foreach (var line in Input)
        {
            var s = line.Split(' ');
            var x = int.Parse(s[1]);
            switch (s[0])
            {
                case "forward":
                    horiz += x;
                    depth += aim * x;
                    break;
                case "down":
                    aim += x;
                    break;
                case "up":
                    aim -= x;
                    break;
            }
        }

        return horiz * depth;
    }
}
