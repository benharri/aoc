namespace Solutions._2015;

/// <summary>
/// Day 1: <a href="https://adventofcode.com/2015/day/1"/>
/// </summary>
public class Day01NotQuiteLisp() : Day(2015, 1, "Not Quite Lisp")
{
    public override object Part1()
    {
        var floor = 0;
        foreach (var c in Input.First())
            switch (c)
            {
                case '(': floor++; break;
                case ')': floor--; break;
            }

        return floor;
    }

    public override object Part2()
    {
        var floor = 0;
        var line = Input.First();
        for (var i = 0; i < line.Length; i++)
        {
            switch (line[i])
            {
                case '(': floor++; break;
                case ')': floor--; break;
            }

            if (floor < 0) return i + 1;
        }

        return 0;
    }
}
