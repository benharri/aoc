namespace Solutions._2019;

public sealed class Day19() : Day(2019, 19, "Tractor Beam")
{
    private long[,]? _grid;
    private IntCodeVM? _vm;

    public override void ProcessInput()
    {
        _vm = new(Input.First());
        _grid = new long[50, 50];
    }

    public override object Part1()
    {
        for (var x = 0; x < 50; x++)
            for (var y = 0; y < 50; y++)
            {
                _vm!.Reset();
                _vm.Run(x, y);
                _grid![x, y] = _vm.Result;
            }

        return _grid!.Cast<long>().Sum();
    }

    public override object Part2()
    {
        for (int x = 101, y = 0; ; x++)
        {
            while (true)
            {
                _vm!.Reset();
                _vm.Run(x, y);
                if (_vm.Result == 1) break;
                y++;
            }

            _vm.Reset();
            _vm.Run(x - 99, y + 99);
            if (_vm.Result == 1)
                return (x - 99) * 1e4 + y;
        }
    }
}
