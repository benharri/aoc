//using MoreLinq.Extensions;

namespace AOC2015;

/// <summary>
/// Day 13: <a href="https://adventofcode.com/2015/day/13"/>
/// </summary>
public sealed class Day13 : Day
{
    private readonly Dictionary<(string person1, string person2), int> _happinessMap = new();
    private readonly List<string> _people = new();

    public Day13() : base(2015, 13, "Knights of the Dinner Table")
    {
    }

    public override void ProcessInput()
    {
        foreach (var line in Input)
            AddToHappinessMap(line);
    }

    public override object Part1()
    {
        return ComputeHappiness();
    }

    public override object Part2()
    {
        //  Add myself
        foreach (var person in _people)
        {
            _happinessMap[("me", person)] = 0;
            _happinessMap[(person, "me")] = 0;
        }

        _people.Add("me");

        return ComputeHappiness();
    }

    private void AddToHappinessMap(string thisString)
    {
        var tokens = thisString.Split(' ');
        var person1 = tokens.First();
        var person2 = tokens.Last().TrimEnd('.');
        var amount = int.Parse(tokens[3]);

        if (tokens.Contains("lose"))
            amount *= -1;

        _happinessMap[(person1, person2)] = amount;

        if (!_people.Contains(person1))
            _people.Add(person1);
        if (!_people.Contains(person2))
            _people.Add(person2);
    }

    private static List<List<string>> BuildPermutations(List<string> items)
    {
        if (items.Count > 1)
        {
            return items.SelectMany(item => BuildPermutations(items.Where(i => !i.Equals(item)).ToList()),
                (item, permutation) => new[] { item }.Concat(permutation).ToList()).ToList();
        }

        return new() { items };
    }

    public long ComputeHappiness()
    {
        var possibilities = BuildPermutations(_people);

        var maxHappiness = long.MinValue;
        foreach (var possibility in possibilities)
        {
            long thisPossibilityHappiness = 0;

            for (var i = 0; i < possibility.Count; i++)
            {
                //  get the people on either side.
                var firstPerson = possibility[i];
                var leftPerson = i == 0 ? possibility[^1] : possibility[i - 1];
                var rightPerson = i == possibility.Count - 1 ? possibility[0] : possibility[i + 1];

                thisPossibilityHappiness += _happinessMap[(firstPerson, leftPerson)];
                thisPossibilityHappiness += _happinessMap[(firstPerson, rightPerson)];
            }

            maxHappiness = Math.Max(maxHappiness, thisPossibilityHappiness);
        }

        return maxHappiness;
    }
}