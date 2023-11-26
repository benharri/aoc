namespace AOC2016;

/// <summary>
/// Day 8: <a href="https://adventofcode.com/2016/day/8"/>
/// </summary>
public sealed class Day08() : Day(2016, 8, "Two-Factor Authentication")
{
    public override void ProcessInput()
    {
    }

    private static string PrintGrid(char[,] screen)
    {
        var sb = new StringBuilder();
        for (var y = 0; y <= screen.GetUpperBound(0); y++)
        {
            for (var x = 0; x <= screen.GetUpperBound(1); x++)
                sb.Append(screen[y, x]);

            sb.AppendLine();
        }

        return sb.ToString();
    }

    private static void DrawRectangle(char[,] screen, int width, int height)
    {
        foreach (var y in Enumerable.Range(0, height))
        foreach (var x in Enumerable.Range(0, width))
            screen[y, x] = '\u2588';
    }

    private static void Coltate(char[,] screen, int index, int extent)
    {
        for (var count = 0; count < extent; count++)
        {
            var tmp = screen[screen.GetUpperBound(0), index];
            for (var i = screen.GetUpperBound(0); i > 0; i--)
            {
                screen[i, index] = screen[i - 1, index];
            }

            screen[0, index] = tmp;
        }
    }

    private static void Rowtate(char[,] screen, int index, int extent)
    {
        for (var count = 0; count < extent; count++)
        {
            var tmp = screen[index, screen.GetUpperBound(1)];
            for (var i = screen.GetUpperBound(1); i > 0; i--)
            {
                screen[index, i] = screen[index, i - 1];
            }

            screen[index, 0] = tmp;
        }
    }

    public override object Part1()
    {
        return Input.Where(line => line.StartsWith("rect")).Sum(rect =>
        {
            var s = rect.Split('x', ' ').Skip(1).Select(int.Parse).ToList();
            return s[0] * s[1];
        });
    }

    public override object Part2()
    {
        var screen = new char[6, 50];
        for (var y = 0; y < 6; y++)
        for (var x = 0; x < 50; x++)
            screen[y, x] = '\u2592';

        foreach (var line in Input)
        {
            var s = line.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            switch (s[0])
            {
                case "rect":
                    var a = s[1].Split('x');
                    DrawRectangle(screen, int.Parse(a[0]), int.Parse(a[1]));
                    break;
                case "rotate":
                    var index = int.Parse(s[2][2..]);
                    var extent = int.Parse(s[4]);

                    if (s[1] == "column")
                        Coltate(screen, index, extent);
                    else
                        Rowtate(screen, index, extent);

                    break;
            }
            // Console.WriteLine(PrintGrid(screen));
        }

        return Environment.NewLine + PrintGrid(screen);
    }
}