using MoreLinq.Extensions;

namespace AOC2015;

/// <summary>
/// Day 22: <a href="https://adventofcode.com/2015/day/22"/>
/// </summary>
public sealed class Day22() : Day(2015, 22, "Wizard Simulator 20XX")
{
    private static readonly List<Spell> Spells = new()
    {
        new("Magic Missile", Mana: 53, Damage: 4),
        new("Drain", Mana: 73, Damage: 2, Heal: 2),
        new("Shield", Mana: 113, Armor: 7, Duration: 6),
        new("Poison", Mana: 173, Damage: 3, Duration: 6),
        new("Recharge", Mana: 229, ManaCharge: 101, Duration: 5)
    };

    private Dictionary<string, int> _boss;

    public record Spell(string Name, int Mana, int Duration = 0, int Damage = 0, int Heal = 0, int Armor = 0,
        int ManaCharge = 0);

    public struct GameState(bool HardMode = false, int RoundNumber = 0, int TotalManaSpent = 0, int PlayerHealth = 50,
        int PlayerMana = 500, int BossHealth = 0, int BossDamage = 0, Dictionary<Spell, int>? ActiveSpells = null)
    {
        public GameResult DoTurn(Spell spell)
        {
            RoundNumber++;

            CastSpell(spell);

            ProcessActiveSpells();
            if (BossHealth <= 0) return GameResult.Win;

            PlayerHealth -= Math.Max(1, BossDamage - ActiveSpells.Sum(x => x.Key.Armor));
            if (PlayerHealth <= 0) return GameResult.Loss;

            if (HardMode)
            {
            }

            ProcessActiveSpells();
            return BossHealth <= 0 ? GameResult.Win : GameResult.Continue;
        }

        private void CastSpell(Spell spell)
        {
            TotalManaSpent += spell.Mana;
            PlayerMana -= spell.Mana;
            if (spell.Duration == 0) ProcessSpell(spell);
            else ActiveSpells.Add(spell, spell.Duration);
        }

        private void ProcessActiveSpells()
        {
            ActiveSpells.Keys.ForEach(ProcessSpell);
            foreach (var (spell, duration) in ActiveSpells.ToList())
            {
                if (duration == 1) ActiveSpells.Remove(spell);
                else ActiveSpells[spell]--;
            }
        }

        private void ProcessSpell(Spell spell)
        {
            BossHealth -= spell.Damage;
            PlayerHealth += spell.Heal;
            PlayerMana += spell.ManaCharge;
        }
    }

    public enum GameResult
    {
        Win,
        Loss,
        Continue
    }

    private GameState ProcessStates(GameState initialState)
    {
        var stateQueue = new Queue<GameState>();
        stateQueue.Enqueue(initialState);

        GameState bestGame = new(BossHealth: _boss["Hit Points"], BossDamage: _boss["Damage"]);
        var roundsProcessed = 0;

        while (stateQueue.Count > 0)
        {
        }

        return initialState;
    }

    public override void ProcessInput()
    {
        _boss = Input.ToDictionary(k => k.Split(": ")[0], v => int.Parse(v.Split(": ")[1]));
    }

    public override object Part1()
    {
        return ProcessStates(new(BossHealth: _boss["Hit Points"], BossDamage: _boss["Damage"]));
    }

    public override object Part2() => "";
}