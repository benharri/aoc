namespace AOC2022;

/// <summary>
/// Day 8: <a href="https://adventofcode.com/2022/day/8"/>
/// </summary>
public sealed class Day08() : Day(2022, 8, "Treetop Tree House")
{
    private int[][]? _trees;

    public override void ProcessInput() =>
        _trees = Input.Select(line => line.Select(c => c - '0').ToArray()).ToArray();

    private (bool isVisible, int scenicScore) ScoreCoord(int x, int y)
    {
        var height = _trees![y][x];
        bool top = true, left = true, bottom = true, right = true;
        int upMoves = 0, leftMoves = 0, downMoves = 0, rightMoves = 0;

        for (var i = y - 1; i >= 0; i--)
        {
            upMoves++;
            if (height <= _trees[i][x])
            {
                top = false;
                break;
            }
        }

        for (var i = y + 1; i < _trees[y].Length; i++)
        {
            downMoves++;
            if (height <= _trees[i][x])
            {
                bottom = false;
                break;
            }
        }

        for (var i = x - 1; i >= 0; i--)
        {
            leftMoves++;
            if (height <= _trees[y][i])
            {
                left = false;
                break;
            }
        }

        for (var i = x + 1; i < _trees.Length; i++)
        {
            rightMoves++;
            if (height <= _trees[y][i])
            {
                right = false;
                break;
            }
        }

        return (top || left || bottom || right, upMoves * leftMoves * downMoves * rightMoves);
    }

    public override object Part1() =>
        Enumerable.Range(0, _trees!.Length)
            .Sum(y => Enumerable.Range(0, _trees[0].Length).Count(x => ScoreCoord(x, y).isVisible));

    public override object Part2()
    {
        var max = 0;
        for (var y = 0; y < _trees!.Length; y++)
            for (var x = 0; x < _trees[0].Length; x++)
            {
                var (_, score) = ScoreCoord(x, y);
                if (score > max) max = score;
            }

        return max;
    }
}
