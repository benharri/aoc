namespace AOC2016;

/// <summary>
/// Day 1: <a href="https://adventofcode.com/2016/day/1"/>
/// </summary>
public sealed class Day01() : Day(2016, 1, "No Time for a Taxicab")
{
    private string[]? _moves;

    public override void ProcessInput() => _moves = Input.First().Split(", ");

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

    private static (int x, int y) Move((int x, int y) coord, Direction direction) =>
        direction switch
        {
            Direction.North => (coord.x, coord.y + 1),
            Direction.South => (coord.x, coord.y - 1),
            Direction.East => (coord.x + 1, coord.y),
            Direction.West => (coord.x - 1, coord.y),
            _ => (0, 0)
        };

    public override object Part1()
    {
        var direction = Direction.North;
        var location = (x: 0, y: 0);

        foreach (var move in _moves!)
        {
            direction = Turn(direction, move[0]);
            location = Enumerable.Range(0, int.Parse(move[1..]))
                .Aggregate(location, (current, _) => Move(current, direction));
        }

        return Math.Abs(location.x) + Math.Abs(location.y);
    }

    public override object Part2()
    {
        HashSet<(int x, int y)> visitedLocations = [];
        var direction = Direction.North;
        var location = (x: 0, y: 0);

        foreach (var move in _moves!)
        {
            direction = Turn(direction, move[0]);
            foreach (var _ in Enumerable.Range(0, int.Parse(move[1..])))
            {
                location = Move(location, direction);
                if (!visitedLocations.Add((location.x, location.y)))
                    return Math.Abs(location.x) + Math.Abs(location.y);
            }
        }

        return 0;
    }
}
