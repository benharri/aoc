namespace AOC2015;

public class Day01() : Day(2015, 1, "Not Quite Lisp")
{
    public override void ProcessInput()
    {
    }

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
