namespace AOC2019;

public sealed class Day09 : Day
{
    private readonly IntCodeVM _vm;

    public Day09() : base(2019, 9, "Sensor Boost")
    {
        _vm = new(Input.First());
    }

    public override string Part1()
    {
        _vm.Reset();
        _vm.Run(1);
        return $"{_vm.Output.ToDelimitedString(",")}";
    }

    public override string Part2()
    {
        _vm.Reset();
        _vm.Run(2);
        return $"{_vm.Output.ToDelimitedString(",")}";
    }
}