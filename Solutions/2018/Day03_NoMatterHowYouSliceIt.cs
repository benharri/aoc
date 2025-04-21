namespace Solutions._2018;

/// <summary>
/// Day 3: <a href="https://adventofcode.com/2018/day/3"/>
/// </summary>
public sealed partial class Day03NoMatterHowYouSliceIt() : Day(2018, 3, "No Matter How You Slice It")
{
    private List<Claim>? _claims;
    private readonly Dictionary<(int x, int y), List<int>> _plots = [];

    [GeneratedRegex(@"\d+")]
    private static partial Regex Digits();

    private record Claim(int ID, int X, int Y, int SizeX, int SizeY);

    public override void ProcessInput()
    {
        _claims = Input.Select(line => Digits().Matches(line).Select(m => int.Parse(m.Value)).ToList())
            .Select(l => new Claim(l[0], l[1], l[2], l[3], l[4])).ToList();

        foreach (var claim in _claims)
        {
            foreach (var y in Enumerable.Range(claim.X, claim.SizeX))
                foreach (var x in Enumerable.Range(claim.Y, claim.SizeY))
                {
                    if (!_plots.ContainsKey((x, y))) _plots.Add((x, y), []);
                    _plots[(x, y)].Add(claim.ID);
                }
        }
    }

    public override object Part1() => _plots.Values.Count(v => v.Count > 1);
    public override object Part2()
    {
        var overlapping = _plots.Where(p => p.Value.Count > 1).SelectMany(p => p.Value).Distinct().ToList();
        return _claims!.Single(p => !overlapping.Contains(p.ID)).ID;
    }
}
