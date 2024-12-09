namespace Solutions._2019;

public sealed class Day14() : Day(2019, 14, "Space Stoichiometry")
{
    private Dictionary<string, Reaction>? _reactions;
    private Dictionary<string, long> _available = [];

    public override void ProcessInput() =>
        _reactions = Input
            .Select(Reaction.Parse)
            .ToDictionary(r => r.Product.Name);

    private bool Consume(string chem, long quantity)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);

        _available.TryAdd(chem, 0);

        if (_available[chem] < quantity && !Produce(chem, quantity - _available[chem]))
            return false;

        _available[chem] -= quantity;
        return true;
    }

    private bool Produce(string chem, long quantity)
    {
        if (chem == "ORE")
            return false;

        var reaction = _reactions![chem];
        var reactionCount = (long)Math.Ceiling((double)quantity / reaction.Product.Quantity);

        if (reaction.Reactants.Any(reactant => !Consume(reactant.Name, reactionCount * reactant.Quantity)))
            return false;

        _available[chem] = _available.GetValueOrDefault(chem) + reactionCount * reaction.Product.Quantity;
        return true;
    }

    public override object Part1()
    {
        _available = new() { { "ORE", long.MaxValue } };
        Consume("FUEL", 1);
        return long.MaxValue - _available["ORE"];
    }

    public override object Part2()
    {
        const long capacity = 1_000_000_000_000;
        _available = new() { { "ORE", capacity } };
        Consume("FUEL", 1);

        var oreConsumed = capacity - _available["ORE"];
        while (Produce("FUEL", Math.Max(1, _available["ORE"] / oreConsumed)))
        {
        }

        return _available["FUEL"] + 1;
    }

    private struct Component
    {
        public string Name { get; init; }
        public int Quantity { get; init; }
    }

    private class Reaction
    {
        public readonly Component Product;
        public readonly Component[] Reactants;
        private static readonly string[] Separators = [", ", " => "];

        private Reaction(Component[] reactants, Component product)
        {
            Reactants = reactants;
            Product = product;
        }

        public static Reaction Parse(string s)
        {
            var ss = s.Split(Separators, StringSplitOptions.None);

            return new(
                ss.Take(ss.Length - 1).Select(ParseComponent).ToArray(),
                ParseComponent(ss[^1])
            );

            static Component ParseComponent(string s)
            {
                var spl = s.Split(' ', 2);
                return new()
                {
                    Quantity = int.Parse(spl[0]),
                    Name = spl[1],
                };
            }
        }
    }
}
