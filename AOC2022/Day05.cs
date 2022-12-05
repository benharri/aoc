using MoreLinq;

namespace AOC2022;

/// <summary>
/// Day 5: <a href="https://adventofcode.com/2022/day/5"/>
/// </summary>
public sealed class Day05 : Day
{
    private readonly List<Stack<char>> _stacks;
    private readonly List<Stack<char>> _stacksPart2;
    private readonly IEnumerable<string> _instructions;

    public Day05() : base(2022, 5, "Supply Stacks")
    {
        var s = Input.Split("").ToList();
        var stackDiagram = s[0];
        _instructions = s[1];
        var stackCount = stackDiagram.First().Length / 4;
        _stacks = Enumerable.Range(0, stackCount + 2).Select(_ => new Stack<char>()).ToList();
        

        foreach (var line in stackDiagram.Reverse().Skip(1))
        {
            var diagram = line.Chunk(4);
            var diagramIndex = 1;
            foreach (var stack in diagram)
            {
                if (stack[1] != ' ')
                    _stacks[diagramIndex].Push(stack[1]);

                diagramIndex++;
            }
        }

        _stacksPart2 = new(_stacks.Count);
        _stacks.ForEach(item => _stacksPart2.Add(new(item.Reverse())));
    }

    public override object Part1()
    {
        foreach (var i in _instructions)
        {
            var split = i.Split(' ');
            var quantity = int.Parse(split[1]);
            var from = int.Parse(split[3]);
            var to = int.Parse(split[5]);

            for (var j = 0; j < quantity; j++)
                _stacks[to].Push(_stacks[from].Pop());
        }

        return _stacks.Where(q => q.Any()).Aggregate("", (s1, chars) => s1 + chars.Peek());
    }

    public override object Part2()
    {
        foreach (var i in _instructions)
        {
            var split = i.Split(' ');
            var quantity = int.Parse(split[1]);
            var from = int.Parse(split[3]);
            var to = int.Parse(split[5]);

            var temp = new Stack<char>(quantity);
            for (var j = 0; j < quantity; j++)
                temp.Push(_stacksPart2[from].Pop());

            while (temp.Any())
                _stacksPart2[to].Push(temp.Pop());
        }
        
        return _stacksPart2.Where(q => q.Any()).Aggregate("", (s1, chars) => s1 + chars.Peek());
    }
}
