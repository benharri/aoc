// ReSharper disable HeuristicUnreachableCode
#pragma warning disable CS0162 // Unreachable code detected
namespace AOC2019;

public sealed class Day15() : Day(2019, 15, "Oxygen System")
{
    private const bool Verbose = false;
    private IntCodeVM? _vm;

    public override void ProcessInput() =>
        _vm = new(Input.First());

    public override object Part1()
    {
        _vm!.Reset();
        var currentLocation = new Location(0, 0);
        var halt = IntCodeVM.HaltType.Waiting;
        while (halt == IntCodeVM.HaltType.Waiting)
        {
            var direction = currentLocation!.NextDirection();
            if (direction <= 4)
            {
                var (x, y) = currentLocation.Neighbor(direction);
                if (Location.GetLocation(x, y) == null)
                {
                    halt = _vm.Run(direction);
                    switch (_vm.Result)
                    {
                        case Location.Wall:
                            _ = new Location(x, y, Location.Opposites[direction], Location.Wall);
                            break;
                        case Location.Empty:
                            currentLocation = new(x, y, Location.Opposites[direction]);
                            break;
                        case Location.System:
                            currentLocation = new(x, y, Location.Opposites[direction], Location.System);
                            break;
                        default:
                            throw new($"Unknown IntCodeVM response: {_vm.Result}");
                    }
                }
            }
            else
            {
                direction = currentLocation.PreviousDirection;
                if (direction > 0)
                {
                    halt = _vm.Run(direction);
                    currentLocation = _vm.Result switch
                    {
                        Location.Empty or Location.System => Location.GetLocation(currentLocation.Neighbor(direction)),
                        _ => throw new($"Unknown or unexpected response for previous room: {_vm.Result}")
                    };
                }
                else
                {
                    if (Verbose)
                    {
                        // find extents of canvas
                        int yMin, yMax;
                        var xMin = yMin = int.MaxValue;
                        var xMax = yMax = int.MinValue;
                        foreach (var (x, y) in Location.AllLocations.Keys)
                        {
                            if (x < xMin) xMin = x;
                            if (x > xMax) xMax = x;
                            if (y < yMin) yMin = y;
                            if (y > yMax) yMax = y;
                        }

                        Console.WriteLine($"Canvas extends from ({xMin}, {yMin}) to ({xMax}, {yMax})");

                        // print board
                        for (var y = yMin; y <= yMax; y++)
                        {
                            var line = "";
                            for (var x = xMin; x <= xMax; x++)
                                if (Location.AllLocations.ContainsKey((x, y)))
                                    line += Location.AllLocations[(x, y)].Image();
                                else
                                    line += "@";

                            Console.WriteLine(line);
                        }
                    }

                    currentLocation = Location.OxygenLocation;
                    var distance = 0;
                    while (currentLocation?.PreviousDirection != 0)
                    {
                        distance++;
                        currentLocation = Location.GetLocation(currentLocation!.PreviousLocation());
                    }

                    return distance;
                }
            }
        }

        return "";
    }

    public override object Part2()
    {
        var changed = true;
        while (changed)
        {
            changed = false;
            foreach (var location in Location.AllLocations.Values)
                changed = location.UpdateDistanceToOxygenSystem() || changed;
        }

        return Location.AllLocations.Values
            .Where(l => !l.IsWall)
            .Max(l => l.DistanceToOxygenSystem);
    }

    private class Location
    {
        public const int Wall = 0;
        public const int Empty = 1;
        public const int System = 2;

        private static readonly int[] Dx = [0, 0, 0, 1, -1];
        private static readonly int[] Dy = [0, 1, -1, 0, 0];
        public static readonly int[] Opposites = [0, 2, 1, 4, 3];

        public static readonly Dictionary<(int x, int y), Location> AllLocations = [];

        private readonly int _currentType;

        private int _searchDirection = 1;
        public int DistanceToOxygenSystem = int.MaxValue - 1;

        public Location(int x, int y, int prev = 0, int type = Empty)
        {
            PreviousDirection = prev;
            _currentType = type;
            X = x;
            Y = y;

            if (type == System)
            {
                OxygenLocation = this;
                DistanceToOxygenSystem = 0;
                // Console.WriteLine($"Found Oxygen System at ({x}, {y})");
            }

            AllLocations.Add((x, y), this);
        }

        public static Location? OxygenLocation { get; private set; }
        public int PreviousDirection { get; }
        private int X { get; }
        private int Y { get; }

        public bool IsWall => _currentType == Wall;

        public string Image() => _currentType switch
        {
            Wall => "\u2587",
            Empty => X == 0 && Y == 0 ? "S" : " ",
            System => "O",
            _ => "?"
        };

        public bool UpdateDistanceToOxygenSystem()
        {
            if (_currentType != Empty) return false;

            foreach (var direction in Enumerable.Range(1, 4))
            {
                var distance = GetLocation(Neighbor(direction))?.DistanceToOxygenSystem ?? int.MaxValue;
                if (distance + 1 < DistanceToOxygenSystem)
                {
                    DistanceToOxygenSystem = distance + 1;
                    return true;
                }
            }

            return false;
        }

        public (int, int) Neighbor(int direction) => (X + Dx[direction], Y + Dy[direction]);

        public (int, int) PreviousLocation() => Neighbor(PreviousDirection);

        public int NextDirection() => _searchDirection++;

        public static Location? GetLocation(int x, int y) =>
            AllLocations.ContainsKey((x, y)) ? AllLocations[(x, y)] : null;

        public static Location? GetLocation((int x, int y) coords) => GetLocation(coords.x, coords.y);
    }
}
