using MoreLinq;

namespace Solutions._2025;

/// <summary>
/// Day 9: <a href="https://adventofcode.com/2025/day/9"/>
/// </summary>
public sealed class Day09MovieTheater() : Day(2025, 9, "Movie Theater")
{
    private record struct Line(Point2d<long> From, Point2d<long> To);

    private readonly List<Point2d<long>> _redTiles = [];
    private readonly List<Line> _lines = [];

    public override void ProcessInput()
    {
        _redTiles.AddRange(Input.Select(Point2d<long>.FromLine));
        _lines.AddRange(_redTiles.Pairwise((p1, p2) => new Line(p1, p2)));
        _lines.Add(new(_redTiles.Last(), _redTiles.First()));
    }

    public override object Part1() =>
        _redTiles.Pairs().Max(tuple => tuple.First.AreaBetween(tuple.Second));

    public override object Part2()
    {
        var max = 0L;
        for (var i = 0; i < _redTiles.Count; i++)
        {
            var localMax = 0L;
            for (var j = i + 1; j < _redTiles.Count; j++)
            {
                var area = _redTiles[i].AreaBetween(_redTiles[j]);
                if (area > localMax)
                {
                    var hasIntersection = false;
                    for (var l = 0; l < _lines.Count && !hasIntersection; l++)
                    {
                        var (xMin1, xMax1) = MinMax(_lines[l].From.X, _lines[l].To.X);
                        var (yMin1, yMax1) = MinMax(_lines[l].From.Y, _lines[l].To.Y);
                        var (xMin2, xMax2) = MinMax(_redTiles[i].X, _redTiles[j].X);
                        var (yMin2, yMax2) = MinMax(_redTiles[i].Y, _redTiles[j].Y);
                        hasIntersection |= xMax2 > xMin1 && xMin2 < xMax1 && yMax2 > yMin1 && yMin2 < yMax1;
                    }

                    localMax = hasIntersection ? localMax : area;
                }
            }

            max = Math.Max(localMax, max);
        }

        return max;
    }

    private static (long min, long max) MinMax(long a, long b) => a < b ? (a, b) : (b, a);
}
