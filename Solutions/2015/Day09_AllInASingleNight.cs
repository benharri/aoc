namespace Solutions._2015;

/// <summary>
/// Day 9: <a href="https://adventofcode.com/2015/day/9"/>
/// </summary>
public sealed class Day09AllInASingleNight() : Day(2015, 9, "All in a Single Night")
{
    private readonly List<Distance> _distances = [];
    private int _shortest = int.MaxValue, _longest;

    public override void ProcessInput()
    {
        foreach (var split in Input.Select(line => line.Split(' ')))
        {
            _distances.Add(new(split[0], split[2], int.Parse(split[4])));
            _distances.Add(new(split[2], split[0], int.Parse(split[4])));
        }

        var cities = _distances.Select(d => d.Start).Distinct().ToList();
        var routes = cities.Permute();

        foreach (var permutation in routes.Select(p => p.ToList()))
        {
            var routeLength = 0;
            for (var i = 1; i < permutation.Count; i++)
                routeLength += _distances.First(d => d.Start == permutation[i - 1] && d.End == permutation[i]).Length;

            if (routeLength < _shortest) _shortest = routeLength;
            if (routeLength > _longest) _longest = routeLength;
        }
    }

    public override object Part1() => _shortest;

    public override object Part2() => _longest;

    private record Distance(string Start, string End, int Length);
}
