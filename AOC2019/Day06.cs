namespace AOC2019;

public sealed class Day06() : Day(2019, 6, "Universal Orbit Map")
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
