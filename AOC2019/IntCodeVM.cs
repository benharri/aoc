namespace AOC2019;

public class IntCodeVM
{
    public enum HaltType
    {
        Terminate,
        Waiting
    }

    private readonly Queue<long> _input;
    public readonly Queue<long> Output;

    private readonly long[] _program;
    private long _i;
    public long[] Memory;
    private long _relativeBase;

    public IntCodeVM(string tape)
    {
        _i = 0;
        _relativeBase = 0;
        _program = tape.Split(',').Select(long.Parse).ToArray();
        Memory = _program;
        _input = new();
        Output = new();
    }

    public long Result => Output.Dequeue();

    public void Reset()
    {
        _i = 0;
        _relativeBase = 0;
        Memory = _program;
        _input.Clear();
        Output.Clear();
    }

    public void AddInput(params long[] values)
    {
        foreach (var v in values) AddInput(v);
    }

    public void AddInput(long value)
    {
        _input.Enqueue(value);
    }

    private long MemGet(long addr)
    {
        return addr < Memory.Length ? Memory[addr] : 0;
    }

    private void MemSet(long addr, long value)
    {
        if (addr < 0) addr = 0;
        if (addr >= Memory.Length)
            Array.Resize(ref Memory, (int)addr + 1);
        Memory[addr] = value;
    }

    private long Mode(long idx)
    {
        var mode = MemGet(_i) / 100;
        for (var s = 1; s < idx; s++)
            mode /= 10;
        return mode % 10;
    }

    private long Get(long idx)
    {
        var param = MemGet(_i + idx);
        return Mode(idx) switch
        {
            0 => MemGet(param),
            1 => param,
            2 => MemGet(_relativeBase + param),
            _ => throw new("invalid parameter mode")
        };
    }

    private void Set(long idx, long val)
    {
        var param = MemGet(_i + idx);
        switch (Mode(idx))
        {
            case 0:
                MemSet(param, val);
                break;
            case 1: throw new("cannot set in immediate mode");
            case 2:
                MemSet(_relativeBase + param, val);
                break;
            default: throw new("invalid parameter mode");
        }
    }

    public HaltType Run(params long[] additionalInput)
    {
        foreach (var s in additionalInput) AddInput(s);
        return Run();
    }

    public HaltType Run()
    {
        while (_i < Memory.Length)
        {
            var op = MemGet(_i) % 100;
            switch (op)
            {
                case 1:
                    Set(3, Get(1) + Get(2));
                    _i += 4;
                    break;
                case 2:
                    Set(3, Get(1) * Get(2));
                    _i += 4;
                    break;
                case 3:
                    if (!_input.Any())
                        return HaltType.Waiting;
                    Set(1, _input.Dequeue());
                    _i += 2;
                    break;
                case 4:
                    Output.Enqueue(Get(1));
                    _i += 2;
                    break;
                case 5:
                    _i = Get(1) == 0 ? _i + 3 : Get(2);
                    break;
                case 6:
                    _i = Get(1) != 0 ? _i + 3 : Get(2);
                    break;
                case 7:
                    Set(3, Get(1) < Get(2) ? 1 : 0);
                    _i += 4;
                    break;
                case 8:
                    Set(3, Get(1) == Get(2) ? 1 : 0);
                    _i += 4;
                    break;
                case 9:
                    _relativeBase += Get(1);
                    _i += 2;
                    break;
                case 99:
                    return HaltType.Terminate;
                default:
                    throw new($"unknown op {op} at {_i}");
            }
        }

        return HaltType.Terminate;
    }
}
