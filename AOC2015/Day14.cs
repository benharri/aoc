namespace AOC2015;

/// <summary>
/// Day 14: <a href="https://adventofcode.com/2015/day/14"/>
/// </summary>
public sealed class Day14() : Day(2015, 14, "Reindeer Olympics")
{
    private List<Reindeer>? _reindeer;

    public override void ProcessInput()
    {
        _reindeer = Input.Select(i => new Reindeer(i)).ToList();
    }

    public override object Part1() =>
        _reindeer!.Select(r => r.Fly(2503)).Max();

    public override object Part2() =>
        Enumerable.Range(1, 2503)
            .SelectMany(time => _reindeer!.GroupBy(r => r.Fly(time)).OrderByDescending(r => r.Key).First())
            .GroupBy(r => r)
            .Max(g => g.Count());

    private class Reindeer {
        private readonly int _duration;
        private readonly int _rest;
        private readonly int _speed;

        public Reindeer(string input) {
            var p = input.Split(' ');
            _speed = int.Parse(p[3]);
            _duration = int.Parse(p[6]);
            _rest = int.Parse(p[13]);
        }

        public int Fly(int time) =>
            time / (_duration + _rest) * _speed * _duration // number iterations * travel distance
            + Math.Min(_duration, time % (_duration + _rest)) * _speed; // last partial iteration
    }
}
