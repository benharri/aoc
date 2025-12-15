namespace Solutions._2021;

/// <summary>
/// Day 7: <a href="https://adventofcode.com/2021/day/7"/>
/// </summary>
public sealed class Day07TheTreacheryOfWhales() : Day(2021, 7, "The Treachery of Whales")
{
    private readonly List<long> _tape = [];

    public override void ProcessInput() =>
        _tape.AddRange(Input.First().Split(',').Select(long.Parse).OrderBy(i => i));

    private static long ArithmeticSumTo(long n) => n * (n + 1) / 2L;

    public override object Part1()
    {
        var i = _tape[_tape.Count / 2];
        return _tape.Select(t => Math.Abs(t - i)).Sum();
    }

    public override object Part2()
    {
        var avg = (decimal)_tape.Sum() / _tape.Count;
        var floor = _tape.Select(t => ArithmeticSumTo(Math.Abs(t - (long)Math.Floor(avg)))).Sum();
        var ceil = _tape.Select(t => ArithmeticSumTo(Math.Abs(t - (long)Math.Ceiling(avg)))).Sum();
        return Math.Min(floor, ceil);
    }
}
