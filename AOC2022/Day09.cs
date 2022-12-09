namespace AOC2022;

/// <summary>
/// Day 9: <a href="https://adventofcode.com/2022/day/9"/>
/// </summary>
public sealed class Day09 : Day
{
    private List<(char direction, int count)>? _steps;
    
    public Day09() : base(2022, 9, "Rope Bridge")
    {
    }
    
    public override void ProcessInput()
    {
        _steps = Input.Select(line => (line[0], int.Parse(line[2..]))).ToList();
    }
    
    private static (int x, int y) MoveTail((int x, int y) tail, (int x, int y) head)
    {
        int dx = head.x - tail.x, dy = head.y - tail.y;
        if (Math.Max(Math.Abs(dx), Math.Abs(dy)) > 1)
        {
            tail.x += Math.Sign(dx);
            tail.y += Math.Sign(dy);
        }

        return tail;
    }
    
    private int CountTailPositions(int ropeLength)
    {
        var rope = Enumerable.Range(0, ropeLength).Select(_ => (x: 0, y: 0)).ToArray();
        var visited = new HashSet<(int x, int y)>();

        foreach (var step in _steps!)
        {
            int dx = 0, dy = 0;
            switch (step.direction)
            {
                case 'U': dy = 1;  break;
                case 'D': dy = -1; break;
                case 'L': dx = -1; break;
                case 'R': dx = 1;  break;
            }

            foreach (var _ in Enumerable.Range(0, step.count))
            {
                rope[0].x += dx;
                rope[0].y += dy;
                foreach (var i in Enumerable.Range(1, ropeLength - 1))
                {
                    rope[i] = MoveTail(rope[i], rope[i - 1]);
                    visited.Add(rope.Last());
                }
            }
        }

        return visited.Count;
    }

    public override object Part1() => CountTailPositions(2);

    public override object Part2() => CountTailPositions(10);
}
