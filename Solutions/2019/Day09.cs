namespace Solutions._2019;

public sealed class Day09() : Day(2019, 9, "Sensor Boost")
{
    private IntCodeVM? _vm;

    public override void ProcessInput() =>
        _vm = new(Input.First());

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
