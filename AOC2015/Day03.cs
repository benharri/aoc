namespace AOC2015;

/// <summary>
/// Day 3: <a href="https://adventofcode.com/2015/day/3"/>
/// </summary>
public sealed class Day03() : Day(2015, 3, "Perfectly Spherical Houses in a Vacuum")
{
    public override void ProcessInput()
    {
    }

    public override object Part1()
    {
        int x = 0, y = 0;
        Dictionary<(int x, int y), int> map = new() { [(0, 0)] = 1 };

        foreach (var c in Input.First())
        {
            switch (c)
            {
                case '>': x++; break;
                case '<': x--; break;
                case '^': y++; break;
                case 'v': y--; break;
            }

            if (map.ContainsKey((x, y))) map[(x, y)]++;
            else map[(x, y)] = 1;
        }

        return map.Count(m => m.Value >= 1);
    }

    public override object Part2()
    {
        int x1 = 0, y1 = 0, x2 = 0, y2 = 0;
        Dictionary<(int x, int y), int> map = new() { [(0, 0)] = 1 };
        var santaTurn = true;

        foreach (var c in Input.First())
        {
            if (santaTurn)
            {
                switch (c)
                {
                    case '>': x1++; break;
                    case '<': x1--; break;
                    case '^': y1++; break;
                    case 'v': y1--; break;
                }

                if (map.ContainsKey((x1, y1))) map[(x1, y1)]++;
                else map[(x1, y1)] = 1;
            }
            else
            {
                switch (c)
                {
                    case '>': x2++; break;
                    case '<': x2--; break;
                    case '^': y2++; break;
                    case 'v': y2--; break;
                }

                if (map.ContainsKey((x2, y2))) map[(x2, y2)]++;
                else map[(x2, y2)] = 1;
            }

            santaTurn = !santaTurn;
        }

        return map.Count(m => m.Value >= 1);
    }
}
