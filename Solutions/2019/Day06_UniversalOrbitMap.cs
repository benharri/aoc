namespace Solutions._2019;

/// <summary>
/// Day 6: <a href="https://adventofcode.com/2019/day/6"/>
/// </summary>
public sealed class Day06UniversalOrbitMap() : Day(2019, 6, "Universal Orbit Map")
{
    private Dictionary<string, string>? _input;

    public override void ProcessInput() =>
        _input = Input.ToDictionary(i => i.Split(')')[1], i => i.Split(')')[0]);

    private List<string> GetParents(string obj)
    {
        var res = new List<string>();
        for (var current = obj; current != "COM"; current = _input![current])
            res.Add(current);
        res.Add("COM");
        return res;
    }

    public override object Part1() =>
        _input!.Keys.Sum(o => GetParents(o).Count - 1);

    public override object Part2()
    {
        var you = GetParents("YOU");
        var san = GetParents("SAN");
        var common = 1;
        for (; you[^common] == san[^common]; common++)
        {
        }

        return you.Count + san.Count - common * 2;
    }
}
