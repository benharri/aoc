namespace AOC2022;

/// <summary>
/// Day 7: <a href="https://adventofcode.com/2022/day/7"/>
/// </summary>
public sealed class Day07() : Day(2022, 7, "No Space Left On Device")
{
    private readonly DefaultDictionary<string, long> _dirs = new();

    public override void ProcessInput()
    {
        var path = new Stack<string>();
        foreach (var line in Input)
        {
            if (line.StartsWith("$ cd"))
            {
                var dir = line.Split("$ cd ")[1];
                if (dir == "..")
                    path.Pop();
                else if (dir != "/")
                    path.Push(dir);
            }
            else
            {
                if (!long.TryParse(line.Split(' ')[0], out var filesize)) continue;
                
                var pathList = path.ToList();
                pathList.Reverse();

                foreach (var i in Enumerable.Range(0, pathList.Count + 1))
                    _dirs[string.Join("/", pathList.GetRange(0, i))] += filesize;
            }
        }
    }

    public override object Part1() =>
        _dirs.Values.Where(d => d <= 100_000L).Sum();

    public override object Part2() =>
        _dirs.Values.Where(d => d >= _dirs[""] - 40_000_000).Min();
}
