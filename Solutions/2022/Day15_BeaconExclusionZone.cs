namespace Solutions._2022;

/// <summary>
/// Day 15: <a href="https://adventofcode.com/2022/day/15"/>
/// </summary>
public sealed partial class Day15BeaconExclusionZone() : Day(2022, 15, "Beacon Exclusion Zone")
{
    private List<Sensor>? _sensors;

    [GeneratedRegex(@"-?\d+")]
    private static partial Regex DigitsRegex();

    public override void ProcessInput()
    {
        _sensors = Input.Select(Sensor.FromString).ToList();
    }

    public override object Part1()
    {
        var targetRow = UseTestInput ? 10 : 2_000_000;

        var taken = _sensors!
            .Where(t => t.ClosestBeaconPosition.y == targetRow)
            .Select(t => t.ClosestBeaconPosition.x);

        return _sensors!
            .SelectMany(s => s.GetSlice(targetRow).Values)
            .Except(taken)
            .Count();
    }

    public override object Part2()
    {
        var size = UseTestInput ? 20 : 4_000_000;
        var limit = new SensorRange(0, size);

        for (var y = 0; y <= size; y++)
        {
            var y1 = y;
            var covered = _sensors!.Select(s => s.GetSlice(y1));
            var gap = FindGap(covered, limit);
            if (gap is { } x)
                return (x * 4_000_000L) + y;
        }

        return 0;
    }

    private static int? FindGap(IEnumerable<SensorRange> covered, SensorRange limit)
    {
        var ordered = covered
            .Select(r => r.Intersect(limit))
            .Where(r => !r.IsEmpty)
            .OrderBy(r => r.Min)
            .ThenBy(r => r.Max);

        var max = limit.Min - 1;
        foreach (var r in ordered)
        {
            if (max + 1 < r.Min) return max + 1;
            max = Math.Max(max, r.Max);
        }

        return max < limit.Max ? max + 1 : null;
    }

    private readonly record struct SensorRange(int Min, int Max)
    {
        private static readonly SensorRange Empty = new(0, -1);
        public bool IsEmpty => Min > Max;

        public IEnumerable<int> Values =>
            IsEmpty ? [] : Enumerable.Range(Min, Max - Min + 1);

        private bool Overlaps(SensorRange other) =>
            !IsEmpty && !other.IsEmpty && Min <= other.Max && Max >= other.Min;

        public SensorRange Intersect(SensorRange other) =>
            Overlaps(other) ? new(Math.Max(Min, other.Min), Math.Min(Max, other.Max)) : Empty;
    }

    private record Sensor((int x, int y) Position, (int x, int y) ClosestBeaconPosition)
    {
        private int ManhattanDistance =>
            Math.Abs(Position.x - ClosestBeaconPosition.x) + Math.Abs(Position.y - ClosestBeaconPosition.y);

        public SensorRange GetSlice(int y)
        {
            var dy = Math.Abs(y - Position.y);
            if (dy > ManhattanDistance) return new(0, -1);

            var dx = ManhattanDistance - dy;
            return new(Position.x - dx, Position.x + dx);
        }

        public static Sensor FromString(string line)
        {
            var coords = DigitsRegex().Matches(line).Select(p => int.Parse(p.Value)).ToList();
            return new((coords[0], coords[1]), (coords[2], coords[3]));
        }
    }
}
