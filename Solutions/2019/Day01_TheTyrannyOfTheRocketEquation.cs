namespace Solutions._2019;

/// <summary>
/// Day 1: <a href="https://adventofcode.com/2019/day/1"/>
/// </summary>
public sealed class Day01TheTyrannyOfTheRocketEquation() : Day(2019, 1, "The Tyranny of the Rocket Equation")
{
    private readonly List<int> _masses = [];

    public override void ProcessInput() =>
        _masses.AddRange(Input.Select(int.Parse));

    private static int FuelCost(int weight) => weight / 3 - 2;

    private static int FullCost(int cost)
    {
        int total = 0, newCost, tmp = cost;

        while ((newCost = FuelCost(tmp)) >= 0)
        {
            total += newCost;
            tmp = newCost;
        }

        return total;
    }

    public override object Part1() => _masses.Sum(FuelCost);

    public override object Part2() => _masses.Sum(FullCost);
}
