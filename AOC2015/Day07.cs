namespace AOC2015;

/// <summary>
/// Day 7: <a href="https://adventofcode.com/2015/day/7"/>
/// </summary>
public sealed class Day07() : Day(2015, 7, "Some Assembly Required")
{
    private readonly Dictionary<string, Func<ushort>> _actions = new();
    private readonly Dictionary<string, ushort> _wires = new();

    public override void ProcessInput()
    {
    }

    public override object Part1()
    {
        ProcessInstructions();
        return _actions["a"]();
    }

    private void ProcessInstructions()
    {
        _actions.Clear();
        _wires.Clear();

        foreach (var line in Input)
        {
            var split = line.Split(' ');
            var destination = split.Last();

            switch (split.Length)
            {
                case 3:
                    if (ushort.TryParse(split[0], out var val))
                    {
                        _actions.Add(destination, () => val);
                        _wires.Add(destination, val);
                    }
                    else
                    {
                        _actions.Add(destination, () =>
                        {
                            if (_wires.TryGetValue(destination, out var wire)) return wire;

                            var res = _actions[split[0]]();
                            _wires.Add(destination, res);
                            return res;
                        });
                    }

                    break;
                case 4:
                    _actions.Add(destination, () => (ushort)~_actions[split[1]]());
                    break;
                case 5:
                    switch (split[1])
                    {
                        case "AND":
                            _actions.Add(destination, () =>
                            {
                                if (_wires.TryGetValue(destination, out var wire)) return wire;

                                var res = (ushort)((ushort.TryParse(split[0], out var v)
                                    ? v
                                    : _actions[split[0]]()) & _actions[split[2]]());
                                _wires.Add(destination, res);
                                return res;
                            });
                            break;
                        case "OR":
                            _actions.Add(destination, () =>
                            {
                                if (_wires.TryGetValue(destination, out var wire)) return wire;

                                var res = (ushort)((ushort.TryParse(split[0], out var v)
                                    ? v
                                    : _actions[split[0]]()) | _actions[split[2]]());
                                _wires.Add(destination, res);
                                return res;
                            });
                            break;
                        case "LSHIFT":
                            _actions.Add(destination, () =>
                            {
                                if (_wires.TryGetValue(destination, out var wire)) return wire;

                                var res = (ushort)(_actions[split[0]]() << ushort.Parse(split[2]));
                                _wires.Add(destination, res);
                                return res;
                            });
                            break;
                        case "RSHIFT":
                            _actions.Add(destination, () =>
                            {
                                if (_wires.TryGetValue(destination, out var wire)) return wire;

                                var res = (ushort)(_actions[split[0]]() >> ushort.Parse(split[2]));
                                _wires.Add(destination, res);
                                return res;
                            });
                            break;
                    }

                    break;
            }
        }
    }

    public override object Part2()
    {
        ProcessInstructions();
        var p1 = _actions["a"]();

        ProcessInstructions();

        _actions["b"] = () => p1;
        return _actions["a"]();
    }
}