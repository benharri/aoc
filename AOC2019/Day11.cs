namespace AOC2019;

public sealed class Day11 : Day
{
    private IntCodeVM? _vm;
    private Direction _heading;
    private long _x, _y;

    public Day11() : base(2019, 11, "Space Police")
    {
    }

    public override void ProcessInput()
    {
        _vm = new(Input.First());
    }

    private void Move()
    {
        switch (_heading)
        {
            case Direction.Up:
                _y++;
                break;
            case Direction.Down:
                _y--;
                break;
            case Direction.Left:
                _x--;
                break;
            case Direction.Right:
                _x++;
                break;
            default:
                throw new ArgumentException("invalid heading", nameof(_heading));
        }
    }

    private void Turn(long direction)
    {
        _heading = _heading switch
        {
            Direction.Up    => direction == 0 ? Direction.Left : Direction.Right,
            Direction.Down  => direction == 0 ? Direction.Right : Direction.Left,
            Direction.Left  => direction == 0 ? Direction.Down : Direction.Up,
            Direction.Right => direction == 0 ? Direction.Up : Direction.Down,
            _ => _heading
        };

        Move();
    }

    private Dictionary<(long x, long y), long> PaintShip(int initialVal)
    {
        var map = new Dictionary<(long, long), long>();
        _vm!.Reset();
        _heading = Direction.Up;
        _x = 0;
        _y = 0;
        map[(_x, _y)] = initialVal;

        var haltType = IntCodeVM.HaltType.Waiting;
        while (haltType == IntCodeVM.HaltType.Waiting)
        {
            haltType = _vm.Run(map.GetValueOrDefault((_x, _y)));
            map[(_x, _y)] = _vm.Result;
            Turn(_vm.Result);
        }

        return map;
    }

    public override object Part1() => PaintShip(0).Count;

    public override object Part2()
    {
        var map = PaintShip(1);
        var minX = (int)map.Keys.Select(i => i.x).Min();
        var maxX = (int)map.Keys.Select(i => i.x).Max();
        var minY = (int)map.Keys.Select(i => i.y).Min();
        var maxY = (int)map.Keys.Select(i => i.y).Max();

        return Enumerable.Range(minY, maxY - minY + 1)
            .Select(j =>
                Enumerable.Range(minX, maxX - minX + 1)
                    .Select(i => map.GetValueOrDefault((x: i, y: j)) == 0 ? ' ' : '#')
                    .ToDelimitedString()
            )
            .Reverse()
            .ToDelimitedString(Environment.NewLine);
    }

    private enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
}
