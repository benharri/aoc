namespace AOC2019;

public sealed class Day21 : Day
{
    private readonly IntCodeVM _vm;

    public Day21() : base(2019, 21, "Springdroid Adventure") =>
        _vm = new(Input.First());

    public override void ProcessInput()
    {
    }

    public override object Part1()
    {
        _vm.Reset();
        var halt = _vm.Run();
        return "";
    }

    public override object Part2() => "";
}
