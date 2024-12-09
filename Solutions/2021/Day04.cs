namespace Solutions._2021;

/// <summary>
/// Day 4: <a href="https://adventofcode.com/2021/day/4"/>
/// </summary>
public sealed class Day04() : Day(2021, 4, "Giant Squid")
{
    private List<int>? _call;
    private List<List<int>>? _boards;
    private int _size;

    public override void ProcessInput()
    {
        _call = Input.First().Split(',').Select(int.Parse).ToList();
        _boards = [];

        List<int> currentBoard = [];
        foreach (var line in Input.Skip(2))
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                _boards.Add(currentBoard);
                currentBoard = [];
                continue;
            }

            currentBoard.AddRange(line
                .Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
        }

        if (currentBoard.Count != 0) _boards.Add(currentBoard);
        _size = (int)Math.Sqrt(currentBoard.Count);
    }

    public override object Part1()
    {
        int i = _size, b = FirstWin(i);
        while (b == -1)
        {
            i++;
            b = FirstWin(i);
        }

        var called = _call!.Take(i).ToHashSet();
        return called.Last() * _boards![b].Where(x => !called.Contains(x)).Sum();
    }

    public override object Part2()
    {
        Dictionary<int, bool> wonBoards = [];
        for (var i = 0; i < _boards!.Count; i++)
            wonBoards[i] = false;

        var j = _size;
        while (wonBoards.Values.Count(b => b) != wonBoards.Count - 1)
        {
            var c = _call!.Take(j).ToHashSet();
            for (var u = 0; u < _boards.Count; u++)
                wonBoards[u] = HasWin(c, _boards[u]);
            j++;
        }

        var called = _call!.Take(j).ToHashSet();
        var b = wonBoards.Single(kvp => !kvp.Value).Key;
        return called.Last() * _boards[b].Where(x => !called.Contains(x)).Sum();
    }

    private int FirstWin(int i)
    {
        var c = _call!.Take(i).ToHashSet();
        for (var j = 0; j < _boards!.Count; j++)
            if (HasWin(c, _boards[j])) return j;
        return -1;
    }

    private int At(int x, int y) => x * _size + y;

    private bool HasWin(HashSet<int> c, List<int> b)
    {
        for (var y = 0; y < _size; y++)
        {
            bool rowWin = true, colWin = true;
            for (var x = 0; x < _size; x++)
            {
                rowWin &= c.Contains(b[At(x, y)]);
                colWin &= c.Contains(b[At(y, x)]);
            }

            if (rowWin || colWin) return true;
        }

        return false;
    }
}
