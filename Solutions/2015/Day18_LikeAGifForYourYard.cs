namespace Solutions._2015;

/// <summary>
/// Day 18: <a href="https://adventofcode.com/2015/day/18"/>
/// </summary>
public sealed class Day18LikeAGifForYourYard() : Day(2015, 18, "Like a GIF For Your Yard")
{
    private bool[][] _lights = [];

    public override void ProcessInput()
    {
        var input = Input.ToArray();
        _lights = Enumerable.Range(0, 102).Select(_ => new bool[102]).ToArray();
        for (var i = 0; i < 100; i++)
        for (var j = 0; j < 100; j++)
            _lights[i + 1][j + 1] = input[i][j] == '#';
    }

    private static bool[][] DoStep(bool[][] lights)
    {
        var nextGrid = Enumerable.Range(0, 102).Select(_ => new bool[102]).ToArray();
        for (var i = 1; i < 101; i++)
        {
            for (var j = 1; j < 101; j++)
            {
                var activeNeighbors = new[]
                {
                    lights[i - 1][j - 1],
                    lights[i - 1][j],
                    lights[i - 1][j + 1],
                    lights[i][j - 1],
                    lights[i][j + 1],
                    lights[i + 1][j - 1],
                    lights[i + 1][j],
                    lights[i + 1][j + 1],
                }.Count(n => n);

                nextGrid[i][j] = lights[i][j] ? activeNeighbors is 2 or 3 : activeNeighbors == 3;
            }
        }

        return nextGrid;
    }

    public override object Part1()
    {
        for (var i = 0; i < 100; i++) _lights = DoStep(_lights);
        return _lights.Sum(l => l.Count(x => x));
    }

    public override object Part2()
    {
        ProcessInput();
        for (var i = 0; i < 100; i++)
        {
            _lights = DoStep(_lights);
            _lights[1][1] = _lights[1][100] = _lights[100][1] = _lights[100][100] = true;
        }

        return _lights.Sum(l => l.Count(x => x));
    }
}
