using MoreLinq;

namespace AOC2022;

/// <summary>
/// Day 5: <a href="https://adventofcode.com/2022/day/5"/>
/// </summary>
public sealed class Day05() : Day(2022, 5, "Supply Stacks")
{
    private IEnumerable<(int quantity, int from, int to)>? _instructions;
    private List<Stack<char>>? _stacks;
    private List<Stack<char>>? _stacksPart2;

    public override void ProcessInput()
    {
        var s = Input.Split("").ToList();
        var stackDiagram = s[0];
        _instructions = s[1].Select(ParseInstruction);
        _stacks = Enumerable.Range(0, stackDiagram.First().Length / 4 + 2).Select(_ => new Stack<char>()).ToList();

        foreach (var line in stackDiagram.Reverse().Skip(1))
        {
            var diagramIndex = 1;
            foreach (var stack in line.Chunk(4))
            {
                if (stack[1] != ' ')
                    _stacks[diagramIndex].Push(stack[1]);

                diagramIndex++;
            }
        }

        _stacksPart2 = new(_stacks.Count);
        _stacks.ForEach(item => _stacksPart2.Add(new(item.Reverse())));
    }

    private static (int quantity, int from, int to) ParseInstruction(string line)
    {
        var split = line.Split(' ');
        return (int.Parse(split[1]), int.Parse(split[3]), int.Parse(split[5]));
    }

    private static string PeekStackTops(IEnumerable<Stack<char>> stacks) =>
        stacks.Where(s => s.Count != 0).Aggregate("", (result, stack) => result + stack.Peek());

    public override object Part1()
    {
        foreach (var (quantity, from, to) in _instructions!)
            Enumerable.Range(0, quantity).ForEach(_ => _stacks![to].Push(_stacks[from].Pop()));

        return PeekStackTops(_stacks!);
    }

    public override object Part2()
    {
        foreach (var (quantity, from, to) in _instructions!)
        {
            var crane = new Stack<char>(quantity);
            Enumerable.Range(0, quantity).ForEach(_ => crane.Push(_stacksPart2![from].Pop()));

            while (crane.Count != 0) _stacksPart2![to].Push(crane.Pop());
        }

        return PeekStackTops(_stacksPart2!);
    }
}