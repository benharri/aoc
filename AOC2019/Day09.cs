namespace AOC2019;

public sealed class Day09 : Day
{
    private IntCodeVM? _vm;

    public Day09() : base(2019, 9, "Sensor Boost")
    {
    }

    public override void ProcessInput()
    {
        _vm = new(Input.First());
    }

    public override object Part1()
    {
        _vm!.Reset();
        _vm.Run(1);
        return _vm.Output.ToDelimitedString(",");
    }

    public override object Part2()
    {
        _vm!.Reset();
        _vm.Run(2);
        return _vm.Output.ToDelimitedString(",");
    }
}