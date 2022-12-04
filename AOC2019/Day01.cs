namespace AOC2019;

public sealed class Day01 : Day
{
    private readonly IEnumerable<int> _masses;

    public Day01() : base(2019, 1, "The Tyranny of the Rocket Equation")
    {
        _masses = Input.Select(int.Parse);
    }

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
