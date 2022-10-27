namespace AOC2019;

public sealed class Day17 : Day
{
    private readonly IntCodeVM _vm;

    public Day17() : base(17, "Set and Forget")
    {
        _vm = new(Input.First());
    }

    public override string Part1()
    {
        _vm.Reset();
        _vm.Run();
        var sb = new StringBuilder();
        while (_vm.Output.Any())
            sb.Append((char)_vm.Result);
        // Console.Write(sb);
        var grid = sb.ToString().Trim().Split().Select(s => s.ToCharArray()).ToArray();

        var sum = 0;
        for (var y = 1; y < grid.Length - 1; y++)
        for (var x = 1; x < grid[y].Length - 1; x++)
            if (grid[y][x] == '#' &&
                grid[y - 1][x] == '#' &&
                grid[y + 1][x] == '#' &&
                grid[y][x - 1] == '#' &&
                grid[y][x + 1] == '#')
                sum += x * y;

        return $"{sum}";
    }

    public override string Part2()
    {
        //vm.Reset();
        //vm.memory[0] = 2;
        //var halt = IntCodeVM.HaltType.Waiting;
        //while (halt == IntCodeVM.HaltType.Waiting)
        //{
        //    halt = vm.Run();
        //}
        return "";
    }
}