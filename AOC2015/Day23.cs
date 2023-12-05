namespace AOC2015;

/// <summary>
/// Day 23: <a href="https://adventofcode.com/2015/day/23"/>
/// </summary>
public sealed class Day23() : Day(2015, 23, "Opening the Turing Lock")
{
    private int RunOperations(int initialA = 0, int initialB = 0)
    {
        Dictionary<char, int> registers = new()
        {
            ['a'] = initialA,
            ['b'] = initialB
        };

        var input = Input.ToList();
        for (var i = 0; i < input.Count;)
        {
            switch (input[i][..3])
            {
                case "hlf":
                    registers[input[i++][4]] /= 2;
                    break;
                case "tpl":
                    registers[input[i++][4]] *= 3;
                    break;
                case "inc":
                    registers[input[i++][4]]++;
                    break;
                case "jmp":
                    i += int.Parse(input[i][4..]);
                    break;
                case "jie":
                    i += registers[input[i][4]] % 2 == 0
                        ? int.Parse(input[i][7..])
                        : 1;
                    break;
                case "jio":
                    i += registers[input[i][4]] == 1
                        ? int.Parse(input[i][7..])
                        : 1;
                    break;
            }
        }

        return registers['b'];
    }

    public override object Part1() => RunOperations();

    public override object Part2() => RunOperations(1);
}
