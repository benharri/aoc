namespace AOC2019;

public sealed class Day13 : Day
{
    private readonly Dictionary<(int x, int y), int> _board = new();
    private readonly IntCodeVM _vm;

    public Day13() : base(2019, 13, "Care Package")
    {
        _vm = new(Input.First());
    }

    private IList<(int x, int y)> UpdateTiles(IEnumerable<long> queue)
    {
        var updated = new List<(int x, int y)>();
        foreach (var c in queue.Select(i => (int)i).Chunk(3))
        {
            _board[(c[0], c[1])] = c[2];
            updated.Add((c[0], c[1]));
        }

        return updated;
    }

    private void PrintBoard(IList<(int x, int y)>? updated = null)
    {
        foreach (var (x, y) in updated ?? _board.Keys.ToList())
        {
            if (x < 0 || y < 0) continue;
            Console.SetCursorPosition(x, y);
            var value = _board[(x, y)];
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


    public override object Part1()
    {
        _vm.Reset();
        _vm.Run();
        return _vm.Output.Where((v, i) => (i + 1) % 3 == 0 && v == 2).Count();
    }

    public override object Part2()
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
            var updated = UpdateTiles(_vm.Output);
            if (printBoard) PrintBoard(updated);

            var (ball, _) = _board.Single(t => t.Value == 4).Key;
            var (paddle, _) = _board.Single(t => t.Value == 3).Key;
            _vm.AddInput(ball > paddle ? 1 : ball < paddle ? -1 : 0);

            gameTicks++;
        }

        return $"after {gameTicks} moves, the score is: {_board[(-1, 0)]}";
    }
}