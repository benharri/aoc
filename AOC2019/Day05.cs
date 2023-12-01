namespace AOC2019;

public sealed class Day05() : Day(2019, 5, "Sunny with a Chance of Asteroids")
{
    private IEnumerable<int>? _tape;
    private int _output;

    public override void ProcessInput() =>
        _tape = Input.First().Split(',').Select(int.Parse);

    private void RunIntCode(IList<int> v, int input)
    {
        var i = 0;
        while (i < v.Count && v[i] != 99)
        {
            var mode1 = v[i] / 100 % 10;
            var mode2 = v[i] / 1000;

            switch (v[i] % 100)
            {
                case 1:
                    v[v[i + 3]] = Val(mode1, v[i + 1]) + Val(mode2, v[i + 2]);
                    i += 4;
                    break;
                case 2:
                    v[v[i + 3]] = Val(mode1, v[i + 1]) * Val(mode2, v[i + 2]);
                    i += 4;
                    break;
                case 3:
                    v[v[i + 1]] = input;
                    i += 2;
                    break;
                case 4:
                    _output = Val(mode1, v[i + 1]);
                    i += 2;
                    break;
                case 5:
                    i = Val(mode1, v[i + 1]) == 0 ? i + 3 : Val(mode2, v[i + 2]);
                    break;
                case 6:
                    i = Val(mode1, v[i + 1]) != 0 ? i + 3 : Val(mode2, v[i + 2]);
                    break;
                case 7:
                    v[v[i + 3]] = Val(mode1, v[i + 1]) < Val(mode2, v[i + 2]) ? 1 : 0;
                    i += 4;
                    break;
                case 8:
                    v[v[i + 3]] = Val(mode1, v[i + 1]) == Val(mode2, v[i + 2]) ? 1 : 0;
                    i += 4;
                    break;
            }

            continue;

            int Val(int mode, int val) => mode != 0 ? val : v[val];
        }
    }

    public override object Part1()
    {
        RunIntCode(_tape!.ToList(), 1);
        return _output;
    }

    public override object Part2()
    {
        RunIntCode(_tape!.ToList(), 5);
        return _output;
    }
}
