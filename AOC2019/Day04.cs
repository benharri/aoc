namespace AOC2019;

public sealed class Day04 : Day
{
    private int _start, _end;

    public Day04() : base(2019, 4, "Secure Container")
    {
    }

    public override void ProcessInput()
    {
        var range = Input.First().Split('-').Select(int.Parse).ToList();
        _start = range[0];
        _end = range[1];
    }

    private bool IsValid(int i)
    {
        var prev = 0;
        var hasDup = false;
        foreach (var curr in i.ToString().Select(c => c - '0'))
        {
            if (curr < prev) return false;
            if (curr == prev) hasDup = true;
            prev = curr;
        }

        return i >= _start && i <= _end && hasDup;
    }

    private bool HasOnePair(int i)
    {
        var s = i.ToString();
        return IsValid(i) && s.Select(c => s.Count(j => j == c)).Any(c => c == 2);
    }

    public override object Part1() =>
        Enumerable.Range(_start, _end).Count(IsValid);

    public override object Part2() =>
        Enumerable.Range(_start, _end).Count(HasOnePair);
}