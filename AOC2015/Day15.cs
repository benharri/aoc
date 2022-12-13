namespace AOC2015;

/// <summary>
/// Day 15: <a href="https://adventofcode.com/2015/day/15"/>
/// </summary>
public sealed partial class Day15 : Day
{
    private int _best;
    private int _best500Cals;

    public Day15() : base(2015, 15, "Science for Hungry People")
    {
    }

    [GeneratedRegex(@"-?\d+")]
    private static partial Regex Digits();

    private static Ingredient ParseIngredient(string line)
    {
        var nums = Digits().Matches(line.Split(':')[1]).Select(match => int.Parse(match.Value)).ToList();
        return new(nums[0], nums[1], nums[2], nums[3], nums[4]);
    }

    public override void ProcessInput()
    {
        var ingredients = Input.Select(ParseIngredient).ToList();
        var quantities = new int[ingredients.Count];
        _best = 0;

        while (true)
        {
            for (var i = 0; i < ingredients.Count; i++)
            {
                quantities[i]++;
                if (quantities[i] > 100)
                    quantities[i] = 0;
                else break;
            }

            var quantityApplied = quantities.Take(ingredients.Count - 1).Sum();
            if (quantityApplied == 0) break;
            if (quantityApplied > 100) continue;

            quantities[^1] = 100 - quantityApplied;

            int cap = 0, dur = 0, fla = 0, tex = 0, cal = 0;
            for (var j = 0; j < ingredients.Count; j++)
            {
                var q = quantities[j];
                var i = ingredients[j];

                cap += q * i.Capacity;
                dur += q * i.Durability;
                fla += q * i.Flavor;
                tex += q * i.Texture;
                cal += q * i.Calories;
            }

            var total = Math.Max(0, cap) * Math.Max(0, dur) * Math.Max(0, fla) * Math.Max(0, tex);

            if (total > _best) _best = total;
            if (total > _best500Cals && cal == 500) _best500Cals = total;
        }
    }

    public override object Part1() => _best;

    public override object Part2() => _best500Cals;

    private record Ingredient(int Capacity, int Durability, int Flavor, int Texture, int Calories);
}
