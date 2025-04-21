namespace Solutions._2018;

/// <summary>
/// Day 2: <a href="https://adventofcode.com/2018/day/2"/>
/// </summary>
public sealed class Day02InventoryManagementSystem() : Day(2018, 2, "Inventory Management System")
{
    private static bool HasNChars(string line, int count)
    {
        for (var i = 'a'; i <= 'z'; i++)
            if (line.Count(c => c == i) == count)
                return true;

        return false;
    }

    public override object Part1() =>
        Input.Count(l => HasNChars(l, 2)) * Input.Count(l => HasNChars(l, 3));

    public override object Part2()
    {
        var input = Input.ToImmutableList();

        foreach (var id1 in input)
            foreach (var id2 in input.Where(line2 => id1.HammingDistance(line2) == 1))
                return id1.Remove(id1.Zip(id2).Indexed().First(i => i.Value.First != i.Value.Second).Key, 1);

        throw new("Correct IDs not found");
    }
}
