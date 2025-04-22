namespace Solutions._2020;

/// <summary>
/// Day 25: <a href="https://adventofcode.com/2020/day/25" />
/// </summary>
public sealed class Day25ComboBreaker() : Day(2020, 25, "Combo Breaker")
{
    private static long Transform(long subject, int loopSize)
    {
        var value = 1L;
        for (var i = 0; i < loopSize; i++)
        {
            value *= subject;
            value %= 20201227;
        }
        return value;
    }
    private static int FindLoopSize(long subject, int target)
    {
        var value = 1L;
        var loops = 0;
        while (value != target)
        {
            value *= subject;
            value %= 20201227;
            loops++;
        }
        return loops;
    }

    public override object Part1()
    {
        var cardKey = int.Parse(Input.First());
        var doorKey = int.Parse(Input.Last());
        return Transform(doorKey, FindLoopSize(7, cardKey));
    }

    public override object Part2() => "";
}
