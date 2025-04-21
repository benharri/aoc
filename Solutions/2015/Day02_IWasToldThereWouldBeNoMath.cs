namespace Solutions._2015;

/// <summary>
/// Day 2: <a href="https://adventofcode.com/2015/day/2"/>
/// </summary>
public sealed class Day02IWasToldThereWouldBeNoMath() : Day(2015, 2, "I Was Told There Would Be No Math")
{
    private List<List<int>>? _gifts;

    public override void ProcessInput() =>
        _gifts = Input.Select(line => line.Split('x').Select(int.Parse).ToList()).ToList();

    public override object Part1() =>
        _gifts!.Sum(gift =>
        {
            var biggestDimension = gift.IndexOf(gift.Max());

            var surfaceArea = 2 * gift[0] * gift[1] + 2 * gift[1] * gift[2] + 2 * gift[0] * gift[2];

            var smallestSideArea = 1;
            for (var i = 0; i < gift.Count; i++)
            {
                if (i == biggestDimension) continue;
                smallestSideArea *= gift[i];
            }

            return surfaceArea + smallestSideArea;
        });

    public override object Part2() =>
        _gifts!.Sum(gift =>
        {
            var biggestDimension = gift.IndexOf(gift.Max());
            var bowArea = gift.Aggregate(1, (i, i1) => i * i1);

            var smallestSide = 0;
            for (var i = 0; i < gift.Count; i++)
            {
                if (i == biggestDimension) continue;
                smallestSide += 2 * gift[i];
            }

            return smallestSide + bowArea;
        });
}
