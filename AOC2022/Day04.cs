namespace AOC2022;

/// <summary>
/// Day 4: <a href="https://adventofcode.com/2022/day/4"/>
/// </summary>
public sealed class Day04 : Day
{
    private readonly List<List<int>> _ranges = new();

    public Day04() : base(2022, 4, "Camp Cleanup")
    {
        foreach (var line in Input)
            _ranges.Add(line.Split(',').SelectMany(q => q.Split('-')).Select(int.Parse).ToList());
    }

    public override object Part1()
    {
        var overlapping = 0;

        foreach (var range in _ranges)
        {
            int x1 = range[0], x2 = range[1], y1 = range[2], y2 = range[3];
            
            if ((x1 >= y1 && x1 <= y2 && x2 >= y1 && x2 <= y2) || (y1 >= x1 && y1 <= x2 && y2 >= x1 && y2 <= x2))
                overlapping++;
        }

        return overlapping;
    }

    public override object Part2()
    {
        var overlapping = 0;

        foreach (var range in _ranges)
        {
            int x1 = range[0], x2 = range[1], y1 = range[2], y2 = range[3];

            if ((x1 >= y1 && x1 <= y2) || (x2 >= y1 && x2 <= y2) || (y1 >= x1 && y1 <= x2) || (y2 >= x1 && y2 <= x2))
                overlapping++;
        }

        return overlapping;
    }
}
