namespace Solutions._2019;

/// <summary>
/// Day 9: <a href="https://adventofcode.com/2019/day/9"/>
/// </summary>
public sealed class Day09SensorBoost() : Day(2019, 9, "Sensor Boost")
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
