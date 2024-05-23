namespace Solutions._2020;

/// <summary>
///     Day 21: <a href="https://adventofcode.com/2020/day/21" />
/// </summary>
public sealed class Day21() : Day(2020, 21, "Allergen Assessment")
{
    private IEnumerable<(string[] Allergens, string[] Ingredients)>? _parsedFoods;
    private IEnumerable<(string Allergen, string Ingredient)>? _dangerousFoods;

    public override void ProcessInput()
    {
        _parsedFoods = Input.Select(line => line.TrimEnd(')').Split(" (contains "))
            .Select(split => (Allergens: split[1].Split(", "), Ingredients: split[0].Split(' ')));

        _dangerousFoods = _parsedFoods
            .SelectMany(i => i.Allergens.Select(allergen => (Allergen: allergen, i.Ingredients)))
            .GroupBy(
                pair => pair.Allergen,
                pair => pair.Ingredients.Select(i => i),
                // group by intersection of ingredients
                (allergen, collection) =>
                    (Allergen: allergen, Ingredients: collection.Aggregate((acc, it) => acc.Intersect(it)))
            )
            .OrderBy(food => food.Ingredients.Count())
            .Aggregate(
                Enumerable.Empty<(string Allergen, string Ingredient)>(),
                (poisons, pair) =>
                    poisons.Concat(new[] {(
                        allergen: pair.Allergen,
                        ingredient: pair.Ingredients.Except(poisons.Select(i => i.Ingredient)).First()
                    )})
            );
    }

    public override object Part1() =>
        _parsedFoods!
            .SelectMany(i => i.Ingredients)
            .Count(i => !_dangerousFoods!.Select(t => t.Ingredient).Contains(i));

    public override object Part2() =>
        string.Join(',', _dangerousFoods!
            .OrderBy(i => i.Allergen)
            .Select(i => i.Ingredient));
}
