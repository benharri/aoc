namespace AOC2019;

public sealed class Day06 : Day
{
    private readonly Dictionary<string, string> _input;

    public Day06() : base(2019, 6, "Universal Orbit Map")
    {
        _input = Input.ToDictionary(i => i.Split(')')[1], i => i.Split(')')[0]);
    }

    private List<string> GetParents(string obj)
    {
        var res = new List<string>();
        for (var curr = obj; curr != "COM"; curr = _input[curr])
            res.Add(curr);
        res.Add("COM");
        return res;
    }

    public override object Part1() =>
        _input.Keys.Sum(o => GetParents(o).Count - 1);

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
