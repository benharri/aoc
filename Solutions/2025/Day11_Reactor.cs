namespace Solutions._2025;

/// <summary>
/// Day 11: <a href="https://adventofcode.com/2025/day/11"/>
/// </summary>
public sealed class Day11Reactor() : Day(2025, 11, "Reactor")
{
    private readonly DirectedGraph<string> _dag = new();
    private readonly Dictionary<(string from, string to), long> _memo = new();

    public override void ProcessInput()
    {
        foreach (var chunks in Input.Select(line => line.Split(": ")))
        foreach (var adj in chunks[1].Split(' '))
            _dag.AddEdge(chunks[0], adj);
    }
    
    private long Paths(string from, string to)
    {
        if (_memo.TryGetValue((from, to), out var cached)) return cached;
        if (from == to) return _memo[(from, to)] = 1L;
        return _memo[(from, to)] = _dag.Outgoing[from].Sum(adj => Paths(adj, to));
    }

    public override object Part1() => Paths("you", "out");

    public override object Part2() => Paths("svr", "dac") * Paths("dac", "fft") * Paths("fft", "out") +
                                      Paths("svr", "fft") * Paths("fft", "dac") * Paths("dac", "out");
}
