namespace AOC2019;

public sealed class Day13 : Day
{
    private IntCodeVM? _vm;
    private readonly Dictionary<(long x, long y), long> _board = new();
    private readonly List<(long x, long y)> _updatedCoordinates = new();

    public Day13() : base(2019, 13, "Care Package")
    {
    }

    public override void ProcessInput()
    {
        _vm = new(Input.First());
    }

    private void UpdateTiles()
    {
        _updatedCoordinates.Clear();
        while (_vm!.Output.Any())
        {
            long x = _vm.Output.Dequeue(), y = _vm.Output.Dequeue();
            _board[(x, y)] = _vm.Output.Dequeue();
            _updatedCoordinates.Add((x, y));
        }
    }

    private void PrintBoard()
    {
        foreach (var (x, y) in _updatedCoordinates.Any() ? _updatedCoordinates : _board.Keys.ToList())
        {
            if (x < 0 || y < 0) continue;
            Console.SetCursorPosition((int)x, (int)y);
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
        _vm!.Reset();
        _vm.Run();
        return _vm.Output.Where((v, i) => (i + 1) % 3 == 0 && v == 2).Count();
    }

    public override object Part2()
    {
        _vm!.Reset();
        _vm.Memory[0] = 2;
        var printBoard = false;
        var gameTicks = 0;
        if (printBoard)
        {
            Console.Clear();
            Console.CursorVisible = false;
        }

        var haltType = IntCodeVM.HaltType.Waiting;
        while (haltType == IntCodeVM.HaltType.Waiting)
        {
            haltType = _vm.Run();
            UpdateTiles();
            if (printBoard) PrintBoard();

            var (ball, _) = _board.Single(t => t.Value == 4).Key;
            var (paddle, _) = _board.Single(t => t.Value == 3).Key;
            _vm.AddInput(ball > paddle ? 1 : ball < paddle ? -1 : 0);

            gameTicks++;
        }

        return $"after {gameTicks} moves, the score is: {_board[(-1, 0)]}";
    }
}