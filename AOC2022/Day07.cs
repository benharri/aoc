namespace AOC2022;

/// <summary>
/// Day 7: <a href="https://adventofcode.com/2022/day/7"/>
/// </summary>
public sealed class Day07 : Day
{
    private readonly DefaultDictionary<string, long> _dirs;

    public Day07() : base(2022, 7, "No Space Left On Device")
    {
        _dirs = new();
        var path = new Stack<string>();
        foreach (var line in Input)
        {
            if (line.StartsWith("$ cd"))
            {
                var split = line.Split("$ cd ");
                if (split[1] == "..")
                {
                    path.Pop();
                }
                else if (split[1] != "/")
                {
                    path.Push(split[1]);
                }
            }
            else
            {
                if (!long.TryParse(line.Split(' ')[0], out var filesize))
                    continue;
                
                var pathList = path.ToList();

                foreach (var i in Enumerable.Range(0, path.Count + 1))
                    _dirs[string.Join("/", pathList.GetRange(0, i))] += filesize;
            }
        }
    }

    public override object Part1() =>
        _dirs.Values.Where(d => d <= 1_000_000L).Sum();

    public override object Part2() => "";
}
