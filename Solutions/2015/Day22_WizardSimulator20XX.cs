using MoreLinq.Extensions;

namespace Solutions._2015;

/// <summary>
/// Day 22: <a href="https://adventofcode.com/2015/day/22"/>
/// </summary>
public sealed class Day22WizardSimulator20Xx() : Day(2015, 22, "Wizard Simulator 20XX")
{
    private static readonly List<Spell> Spells =
    [
        new("Magic Missile", Mana: 53, Damage: 4),
        new("Drain", Mana: 73, Damage: 2, Heal: 2),
        new("Shield", Mana: 113, Armor: 7, Duration: 6),
        new("Poison", Mana: 173, Damage: 3, Duration: 6),
        new("Recharge", Mana: 229, ManaCharge: 101, Duration: 5),
    ];

    private Dictionary<string, int> _boss = new();

    private record Spell(
        // ReSharper disable once NotAccessedPositionalProperty.Local
        string Name,
        int Mana,
        int Duration = 0,
        int Damage = 0,
        int Heal = 0,
        int Armor = 0,
        int ManaCharge = 0
    );

    private struct GameState(
        bool hardMode = false,
        int roundNumber = 0,
        int totalManaSpent = 0,
        int playerHealth = 50,
        int playerMana = 500,
        int bossHealth = 0,
        int bossDamage = 0,
        Dictionary<Spell, int>? activeSpells = null)
    {
        public GameResult DoTurn(Spell spell)
        {
            roundNumber++;

            CastSpell(spell);

            ProcessActiveSpells();
            if (bossHealth <= 0) return GameResult.Win;

            playerHealth -= Math.Max(1, bossDamage - activeSpells?.Sum(x => x.Key.Armor) ?? 0);
            if (playerHealth <= 0) return GameResult.Loss;

            if (hardMode)
            {
            }

            ProcessActiveSpells();
            return bossHealth <= 0 ? GameResult.Win : GameResult.Continue;
        }

        private void CastSpell(Spell spell)
        {
            totalManaSpent += spell.Mana;
            playerMana -= spell.Mana;
            if (spell.Duration == 0) ProcessSpell(spell);
            else activeSpells?.Add(spell, spell.Duration);
        }

        private void ProcessActiveSpells()
        {
            if (activeSpells is null) return;

            activeSpells.Keys.ForEach(ProcessSpell);
            foreach (var (spell, duration) in activeSpells.ToList())
            {
                if (duration == 1) activeSpells.Remove(spell);
                else activeSpells[spell]--;
            }
        }

        private void ProcessSpell(Spell spell)
        {
            bossHealth -= spell.Damage;
            playerHealth += spell.Heal;
            playerMana += spell.ManaCharge;
        }
    }

    private enum GameResult
    {
        Win,
        Loss,
        Continue,
    }

    private GameState ProcessStates(GameState initialState)
    {
        var stateQueue = new Queue<GameState>();
        stateQueue.Enqueue(initialState);

        GameState bestGame = new(bossHealth: _boss["Hit Points"], bossDamage: _boss["Damage"]);

        while (stateQueue.Count > 0)
        {
        }

        return initialState;
    }

    public override void ProcessInput() =>
        _boss = Input.ToDictionary(k => k.Split(": ")[0], v => int.Parse(v.Split(": ")[1]));

    public override object Part1() => "";
    // ProcessStates(new(bossHealth: _boss["Hit Points"], bossDamage: _boss["Damage"]));

    public override object Part2() => "";
}
