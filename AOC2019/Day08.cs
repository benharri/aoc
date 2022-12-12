namespace AOC2019;

public sealed class Day08 : Day
{
    private List<List<char>>? _photo;

    public Day08() : base(2019, 8, "Space Image Format")
    {
    }

    public override void ProcessInput()
    {
        _photo = Input.First().Chunk(25 * 6).Select(s => s.ToList()).ToList();
    }

    public override object Part1()
    {
        var l = _photo!.OrderBy(layer => layer.Count(pixel => pixel == '0')).First();
        return l.Count(p => p == '1') * l.Count(p => p == '2');
    }

    public override object Part2()
    {
        return Enumerable.Range(0, 25 * 6)
            .Select(p => Enumerable.Range(0, _photo!.Count)
                .Select(l => _photo[l][p])
                .Aggregate('2', (acc, next) =>
                    acc != '2' ? acc : next == '0' ? ' ' : next
                )
            )
            .ToDelimitedString()
            .Chunk(25)
            .Select(s => new string(s).Trim())
            .ToDelimitedString(Environment.NewLine)
            .Replace('1', 'x');
    }
}