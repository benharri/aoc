namespace Solutions._2022;

/// <summary>
/// Day 9: <a href="https://adventofcode.com/2022/day/9"/>
/// </summary>
public sealed class Day09RopeBridge() : Day(2022, 9, "Rope Bridge")
{
    private readonly List<(char direction, int count)> _steps = [];

    public override void ProcessInput() =>
        _steps.AddRange(Input.Select(line => (line[0], int.Parse(line[2..]))));

    private int CountTailPositions(int ropeLength)
    {
        var rope = Enumerable.Range(0, ropeLength).Select(_ => (x: 0, y: 0)).ToArray();
        var visited = new HashSet<Point2d<int>>();

        foreach (var step in _steps.SelectMany(step => Enumerable.Range(0, step.count), (step, _) => step))
        {
            switch (step.direction)
            {
                case 'U': rope[0].y++; break;
                case 'D': rope[0].y--; break;
                case 'L': rope[0].x--; break;
                case 'R': rope[0].x++; break;
            }

            foreach (var i in Enumerable.Range(1, ropeLength - 1))
            {
                int dx = rope[i - 1].x - rope[i].x, dy = rope[i - 1].y - rope[i].y;
                if (Math.Max(Math.Abs(dx), Math.Abs(dy)) > 1)
                {
                    rope[i].x += Math.Sign(dx);
                    rope[i].y += Math.Sign(dy);
                }
            }

            visited.Add(rope.Last());
        }

        return visited.Count;
    }

    public override object Part1() => CountTailPositions(2);

    public override object Part2() => CountTailPositions(10);
}
