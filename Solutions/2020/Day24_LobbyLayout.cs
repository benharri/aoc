namespace Solutions._2020;

/// <summary>
/// Day 24: <a href="https://adventofcode.com/2020/day/24" />
/// </summary>
public sealed class Day24LobbyLayout() : Day(2020, 24, "Lobby Layout")
{
    private static readonly Dictionary<string, (int q, int r, int s)> Directions = new()
    {
        { "e",  (1, 0, -1) },
        { "w",  (-1, 0, 1) },
        { "se", (0, 1, -1) },
        { "sw", (-1, 1, 0) },
        { "nw", (0, -1, 1) },
        { "ne", (1, -1, 0) },
    };

    private Dictionary<(int q, int r, int s), Tile>? _tiles;

    public override void ProcessInput() => _tiles = Input
            .Select(Tile.FromLine)
            .GroupBy(t => t.Location)
            .Where(g => g.Count() % 2 == 1)
            .Select(t => t.First())
            .ToDictionary(t => t.Location);

    public override object Part1() => _tiles!.Count;

    public override object Part2()
    {
        foreach (var _ in Enumerable.Range(0, 100))
        {
            _tiles = _tiles!
                .SelectMany(t => Directions.Select(d => t.Value + d.Value))
                .Distinct()
                .Where(t =>
                {
                    var neighborCount = Directions
                        .Select(d => t + d.Value)
                        .Count(neighbor => _tiles!.ContainsKey(neighbor.Location));

                    return neighborCount == 2 || _tiles!.ContainsKey(t.Location) && neighborCount == 1;
                })
                .ToDictionary(t => t.Location);
        }

        return _tiles!.Count;
    }

    private record Tile
    {
        public (int q, int r, int s) Location { get; private init; }

        public static Tile FromLine(string route)
        {
            (int q, int r, int s) location = (0, 0, 0);
            var direction = "";
            foreach (var c in route)
            {
                if (c is 'n' or 's')
                {
                    direction += c;
                    continue;
                }

                direction += c;
                var (q, r, s) = Directions[direction];
                location = (location.q + q, location.r + r, location.s + s);
                direction = "";
            }

            return new() { Location = location };
        }

        public static Tile operator +(Tile t, (int q, int r, int s) direction) =>
            new() { Location = (t.Location.q + direction.q, t.Location.r + direction.r, t.Location.s + direction.s) };
    }
}
