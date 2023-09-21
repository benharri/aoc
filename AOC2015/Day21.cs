namespace AOC2015;

/// <summary>
/// Day 21: <a href="https://adventofcode.com/2015/day/21"/>
/// </summary>
public sealed class Day21() : Day(2015, 21, "RPG Simulator 20XX")
{
    private const int PlayerHp = 100;
    private IEnumerable<Combination>? _combinations;
    private Dictionary<string, int>? _boss;

    private record Combination(Item Weapon, Item Armor, Item Ring1, Item Ring2)
    {
        public int TotalDamage => Weapon.Damage + Ring1.Damage + Ring2.Damage;
        public int TotalArmor => Armor.Armor + Ring1.Armor + Ring2.Armor;
        public int TotalCost => Weapon.Cost + Armor.Cost + Ring1.Cost + Ring2.Cost;
    }

    private record Item(string Name, int Cost = 0, int Damage = 0, int Armor = 0);

    public override void ProcessInput()
    {
        _boss = Input.ToDictionary(k => k.Split(": ")[0], v => int.Parse(v.Split(": ")[1]));

        var weapons = new Item[]
        {
            new(Name: "Dagger",     Cost: 8,  Damage: 4),
            new(Name: "Shortsword", Cost: 10, Damage: 5),
            new(Name: "Warhammer",  Cost: 25, Damage: 6),
            new(Name: "Longsword",  Cost: 40, Damage: 7),
            new(Name: "Greataxe",   Cost: 74, Damage: 8)
        };

        var armor = new Item[]
        {
            new(Name: "No armor",   Cost: 0,   Armor: 0),
            new(Name: "Leather",    Cost: 13,  Armor: 1),
            new(Name: "Chainmail",  Cost: 31,  Armor: 2),
            new(Name: "Splintmail", Cost: 53,  Armor: 3),
            new(Name: "Bandedmail", Cost: 75,  Armor: 4),
            new(Name: "Platemail",  Cost: 102, Armor: 5)
        };

        var rings = new Item[]
        {
            new(Name: "No ring",    Cost: 0,   Damage: 0, Armor: 0),
            new(Name: "Damage +1",  Cost: 25,  Damage: 1, Armor: 0),
            new(Name: "Damage +2",  Cost: 50,  Damage: 2, Armor: 0),
            new(Name: "Damage +3",  Cost: 100, Damage: 3, Armor: 0),
            new(Name: "Defense +1", Cost: 20,  Damage: 0, Armor: 1),
            new(Name: "Defense +2", Cost: 40,  Damage: 0, Armor: 2),
            new(Name: "Defense +3", Cost: 80,  Damage: 0, Armor: 3)
        };

        _combinations =
            from w in weapons
            from a in armor
            from ring1 in rings
            from ring2 in rings
            where ring1.Cost == 0 || ring1.Cost != ring2.Cost
            select new Combination(w, a, ring1, ring2);
    }

    private bool StillAlive(Combination combination)
    {
        var myDamage          = Math.Max(combination.TotalDamage - _boss!["Armor"], 1);
        var bossDamagePerTurn = Math.Max(_boss["Damage"] - combination.TotalArmor, 1);

        var turnsToLose = PlayerHp / bossDamagePerTurn;
        if (PlayerHp % bossDamagePerTurn > 0) turnsToLose++;
        
        var turnsToKillBoss = _boss["Hit Points"] / myDamage;
        if (_boss["Hit Points"] % myDamage > 0) turnsToKillBoss++;

        return turnsToLose >= turnsToKillBoss;
    }

    public override object Part1() =>
        _combinations!.Where(StillAlive).Min(c => c.TotalCost);

    public override object Part2() =>
        _combinations!.Where(c => !StillAlive(c)).Max(c => c.TotalCost);
}