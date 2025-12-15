namespace Solutions._2016;

/// <summary>
/// Day 1: <a href="https://adventofcode.com/2016/day/1"/>
/// </summary>
public sealed class Day01NoTimeForATaxicab() : Day(2016, 1, "No Time for a Taxicab")
{
    private readonly List<string> _moves = [];

    public override void ProcessInput() => _moves.AddRange(Input.First().Split(", "));

    private enum Direction
    {
        North,
        South,
        East,
        West,
    }

    private static Direction Turn(Direction current, char newDirection) =>
        current switch
        {
            Direction.North => newDirection == 'L' ? Direction.West : Direction.East,
            Direction.South => newDirection == 'L' ? Direction.East : Direction.West,
            Direction.East => newDirection == 'L' ? Direction.North : Direction.South,
            Direction.West => newDirection == 'L' ? Direction.South : Direction.North,
            _ => throw new ArgumentException("invalid direction", nameof(current)),
        };

    private static Point2d<int> Move(Point2d<int> coord, Direction direction) =>
        direction switch
        {
            Direction.North => (coord.X, coord.Y + 1),
            Direction.South => (coord.X, coord.Y - 1),
            Direction.East => (coord.X + 1, coord.Y),
            Direction.West => (coord.X - 1, coord.Y),
            _ => (0, 0),
        };

    public override object Part1()
    {
        var direction = Direction.North;
        Point2d<int> location = (0, 0);

        foreach (var move in _moves)
        {
            direction = Turn(direction, move[0]);
            location = Enumerable.Range(0, int.Parse(move[1..]))
                .Aggregate(location, (current, _) => Move(current, direction));
        }

        return Math.Abs(location.X) + Math.Abs(location.Y);
    }

    public override object Part2()
    {
        HashSet<Point2d<int>> visitedLocations = [];
        var direction = Direction.North;
        Point2d<int> location = (0, 0);

        foreach (var move in _moves)
        {
            direction = Turn(direction, move[0]);
            foreach (var _ in Enumerable.Range(0, int.Parse(move[1..])))
            {
                location = Move(location, direction);
                if (!visitedLocations.Add((location.X, location.Y)))
                    return Math.Abs(location.X) + Math.Abs(location.Y);
            }
        }

        return 0;
    }
}
