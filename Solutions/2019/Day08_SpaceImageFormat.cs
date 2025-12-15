namespace Solutions._2019;

/// <summary>
/// Day 8: <a href="https://adventofcode.com/2019/day/8"/>
/// </summary>
public sealed class Day08SpaceImageFormat() : Day(2019, 8, "Space Image Format")
{
    private readonly List<List<char>> _photo = [];

    public override void ProcessInput() =>
        _photo.AddRange(Input.First().Chunk(25 * 6).Select(s => s.ToList()));

    public override object Part1()
    {
        var l = _photo.OrderBy(layer => layer.Count(pixel => pixel == '0')).First();
        return l.Count(p => p == '1') * l.Count(p => p == '2');
    }

    public override object Part2() =>
        Enumerable.Range(0, 25 * 6)
            .Select(p => Enumerable.Range(0, _photo.Count)
                .Select(l => _photo[l][p])
                .Aggregate('2', (acc, next) =>
                    acc != '2' ? acc : next == '0' ? ' ' : next
                )
            )
            .Join()
            .Chunk(25)
            .Select(s => new string(s).Trim())
            .Join("\n")
            .Replace('1', 'x');
}
