namespace Solutions._2025;

/// <summary>
/// Day 6: <a href="https://adventofcode.com/2025/day/6"/>
/// </summary>
public sealed class Day06TrashCompactor() : Day(2025, 6, "Trash Compactor")
{
    public override object Part1()
    {
        var inp = Input.Select(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)).ToArray();
        var sum = 0L;
        for (var i = 0; i < inp[0].Length; i++)
        {
            var operation = inp.Select(l => l[i]).ToList();
            var isMult = operation[^1] == "*";
            sum += operation.SkipLast(1).Aggregate(isMult ? 1L : 0L,
                (total, operand) =>
                {
                    var val = long.Parse(operand);
                    return isMult ? val * total : val + total;
                });
        }

        return sum;
    }

    public override object Part2()
    {
        var inp = Input.ToList();
        var operands = inp.SkipLast(1).ToList();
        var sum = 0L;
        
        var operators = Regex.Matches(inp.Last(), @"\S +");
        foreach (Match op in operators)
        {
            var first = op.Groups.Values.First();
            List<long> numbers = [];
            // I added one (1) space to the end of each line in the input to avoid additional index math for the last operation
            for (var i = first.Length + first.Index - 2; i >= first.Index; i--)
            {
                var digits = operands.Select(line => line[i]).Where(c => c != ' ').ToArray();
                numbers.Add(Util.ParseLongFast(digits));
            }

            var isMult = first.Value[0] == '*';
            sum += numbers.Aggregate(isMult ? 1L : 0L, (i, l) => isMult ? i * l : i + l);
        }

        return sum;
    }
}
