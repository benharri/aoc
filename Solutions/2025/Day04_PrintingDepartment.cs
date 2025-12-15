namespace Solutions._2025;

/// <summary>
/// Day 4: <a href="https://adventofcode.com/2025/day/4"/>
/// </summary>
public sealed class Day04PrintingDepartment() : Day(2025, 4, "Printing Department")
{
    private bool[][] _stacks = [];

    public override void ProcessInput()
    {
        var input = Input.ToArray();
        _stacks = Enumerable.Range(0, input.Length + 2).Select(_ => new bool[input[0].Length + 2]).ToArray();
        for (var i = 0; i < input.Length; i++)
        for (var j = 0; j < input[0].Length; j++)
            _stacks[i + 1][j + 1] = input[i][j] == '@';
    }

    public override object Part1()
    {
        var count = 0;
        for (var i = 1; i < _stacks.Length - 1; i++)
        for (var j = 1; j < _stacks[0].Length - 1; j++)
            if (_stacks[i][j] && NeighborsAt(i, j).Count(n => n) < 4) count++;

        return count;
    }

    public override object Part2()
    {
        var count = 0;
        
        while (true)
        {
            var countBeforeRemoval = count;
            for (var i = 1; i < _stacks.Length - 1; i++)
            for (var j = 1; j < _stacks[0].Length - 1; j++)
                if (_stacks[i][j] && NeighborsAt(i, j).Count(n => n) < 4)
                {
                    _stacks[i][j] = false;
                    count++;
                }

            if (countBeforeRemoval == count) break;
        }

        return count;
    }

    private bool[] NeighborsAt(int i, int j) =>
    [
        _stacks[i - 1][j - 1], _stacks[i - 1][j], _stacks[i - 1][j + 1], _stacks[i][j - 1],
        _stacks[i][j + 1], _stacks[i + 1][j - 1], _stacks[i + 1][j], _stacks[i + 1][j + 1]
    ];
}
