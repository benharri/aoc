namespace Solutions._2023;

/// <summary>
/// <a href="https://adventofcode.com/2023/day/2">Day 2</a>
/// </summary>
public sealed class Day02() : Day(2023, 2, "Cube Conundrum")
{
    private static bool PossibleGame(string line)
    {
        var rounds = line.Split(": ", 2)[1];
        foreach (var round in rounds.Split("; "))
        {
            foreach (var draw in round.Split(", "))
            {
                var s = draw.Split(' ');
                var limit = s[1] switch
                {
                    "blue" => 14,
                    "green" => 13,
                    "red" => 12,
                    _ => 0,
                };
                if (int.Parse(s[0]) > limit) return false;
            }
        }

        return true;
    }

    public override object Part1() =>
        Input.Where(PossibleGame).Sum(l => int.Parse(l.Split(' ', ':')[1]));

    public override object Part2()
    {
        var sum = 0;
        Dictionary<string, int> mins = new() { { "red", 0 }, { "green", 0 }, { "blue", 0 } };
        
        foreach (var line in Input)
        {
            foreach (var (name, _) in mins) mins[name] = 0;
            
            var rounds = line.Split(": ", 2)[1];
            foreach (var round in rounds.Split("; "))
            {
                foreach (var draw in round.Split(", "))
                {
                    var s = draw.Split(' ');
                    mins[s[1]] = Math.Max(int.Parse(s[0]), mins[s[1]]);
                }
            }

            sum += mins.Aggregate(1, (acc, curr) => acc * curr.Value);
        }

        return sum;
    }
}
