namespace Solutions._2025;

/// <summary>
/// Day 7: <a href="https://adventofcode.com/2025/day/7"/>
/// </summary>
public sealed class Day07Laboratories() : Day(2025, 7, "Laboratories")
{
    private string[] _input = [];
    private readonly Dictionary<Point2d<int>, long> _timelines = [];

    public override void ProcessInput() => _input = Input.ToArray();

    public override object Part1()
    {
        var tachyons = new bool[_input[0].Length];
        
        tachyons[_input[0].IndexOf('S')] = true;
        var count = 0;
        foreach (var line in _input.Skip(1))
        {
            for (var i = 0; i < tachyons.Length; i++)
            {
                if (tachyons[i] && line[i] == '^')
                {
                    tachyons[i] = false;
                    tachyons[i - 1] = tachyons[i + 1] = true;
                    count++;
                }
            }
        }
        
        return count;
    }

    public override object Part2() => SplitTheTimeline((_input[0].IndexOf('S'), 0));

    private long SplitTheTimeline(Point2d<int> point)
    {
        // bail when already computed or at the end
        if (_timelines.TryGetValue(point, out var timelines)) return timelines;
        if (_input.Length == point.Y + 1) return 1;

        // recurse left and right if we're at a splitter
        return _timelines[point] = _input[point.Y + 1][point.X] == '^'
            ? SplitTheTimeline((point.X + 1, point.Y + 1)) + SplitTheTimeline((point.X - 1, point.Y + 1))
            : SplitTheTimeline((point.X, point.Y + 1));
    }
}
