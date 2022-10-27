namespace AOC2019;

public sealed class Day13 : Day
{
    private readonly Dictionary<(int x, int y), int> _board;
    private readonly IntCodeVM _vm;

    public Day13() : base(13, "Care Package")
    {
        _vm = new(Input.First());
        _board = new Dictionary<(int, int), int>();
    }

    private void UpdateTiles(IEnumerable<long> queue)
    {
        var input = queue.Select(i => (int)i).ToList();

        for (var i = 0; i < input.Count - 2; i += 3)
        {
            var x = input[i];
            var y = input[i + 1];
            var val = input[i + 2];

            if (_board.ContainsKey((x, y)))
                _board[(x, y)] = val;
            else
                _board.Add((x, y), val);
        }
    }

    private void PrintBoard()
    {
        foreach (var ((x, y), value) in _board)
        {
            if (x < 0 || y < 0) continue;
            Console.SetCursorPosition(x, y);
            Console.Write(value switch
            {
                0 => " ",
                1 => "|",
                2 => "B",
                3 => "_",
                4 => ".",
                _ => value
            });
        }
    }

    public override string Part1()
    {
        _vm.Reset();
        _vm.Run();
        return $"{_vm.Output.Where((v, i) => (i + 1) % 3 == 0 && v == 2).Count()}";
    }

    public override string Part2()
    {
        _vm.Reset();
        _vm.Memory[0] = 2;
        var printBoard = false;
        var gameTicks = 0;
        if (printBoard) Console.Clear();

        var haltType = IntCodeVM.HaltType.Waiting;
        while (haltType == IntCodeVM.HaltType.Waiting)
        {
            haltType = _vm.Run();
            UpdateTiles(_vm.Output);

            var (ball, _) = _board.First(t => t.Value == 4).Key;
            var (paddle, _) = _board.First(t => t.Value == 3).Key;
            _vm.AddInput(ball > paddle ? 1 : ball < paddle ? -1 : 0);

            gameTicks++;
            if (printBoard) PrintBoard();
        }

        return $"after {gameTicks} moves, the score is: {_board[(-1, 0)]}";
    }
}