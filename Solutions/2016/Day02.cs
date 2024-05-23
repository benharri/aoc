namespace Solutions._2016;

/// <summary>
/// Day 2: <a href="https://adventofcode.com/2016/day/2"/>
/// </summary>
public sealed class Day02() : Day(2016, 2, "Bathroom Security")
{
    public override object Part1()
    {
        List<int> answer = [];
        var location = (x: 1, y: 1);

        foreach (var line in Input)
        {
            location = line.Aggregate(location, (c, instruction) => instruction switch
            {
                'U' => c with { y = c.y == 0 ? c.y : c.y - 1 },
                'D' => c with { y = c.y == 2 ? c.y : c.y + 1 },
                'L' => c with { x = c.x == 0 ? c.x : c.x - 1 },
                'R' => c with { x = c.x == 2 ? c.x : c.x + 1 },
                _ => throw new ArgumentException("invalid direction", nameof(instruction))
            });

            answer.Add(1 + location.x + location.y * 3);
        }

        return string.Join("", answer);
    }

    public override object Part2()
    {
        var keyPad = new[,]
        {
            { '\0', '\0', '1', '\0', '\0' },
            { '\0', '2', '3', '4', '\0' },
            { '5', '6', '7', '8', '9' },
            { '\0', 'A', 'B', 'C', '\0' },
            { '\0', '\0', 'D', '\0', '\0' },
        };
        var location = (x: 0, y: 2);
        List<char> answer = [];

        foreach (var line in Input)
        {
            location = line.Aggregate(location, (c, instruction) => instruction switch
            {
                'U' => c with { y = c.y == 0 || keyPad[c.y - 1, c.x] == '\0' ? c.y : c.y - 1 },
                'D' => c with { y = c.y == 4 || keyPad[c.y + 1, c.x] == '\0' ? c.y : c.y + 1 },
                'L' => c with { x = c.x == 0 || keyPad[c.y, c.x - 1] == '\0' ? c.x : c.x - 1 },
                'R' => c with { x = c.x == 4 || keyPad[c.y, c.x + 1] == '\0' ? c.x : c.x + 1 },
                _ => throw new ArgumentException("invalid direction", nameof(instruction))
            });

            answer.Add(keyPad[location.y, location.x]);
        }

        return string.Join("", answer);
    }
}
