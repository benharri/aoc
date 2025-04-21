namespace Solutions._2023;

/// <summary>
/// <a href="https://adventofcode.com/2023/day/6">Day 6</a>
/// </summary>
public class Day06WaitForIt() : Day(2023, 6, "Wait For It")
{
    private readonly List<(int time, int distance)> _races = [];

    public override void ProcessInput()
    {
        var input = Input.Select(l =>
            l.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .Select(int.Parse)
                .ToList()
        ).ToList();

        for (var i = 0; i < input[0].Count; i++)
            _races.Add((input[0][i], input[1][i]));
    }

    public override object Part1() =>
        _races.Select(race =>
        {
            var cnt = 0;
            for (var speed = 1; speed < race.time; speed++)
                if (speed * (race.time - speed) > race.distance)
                    cnt++;

            return cnt;
        }).Aggregate(1, (a, b) => a * b);

    public override object Part2()
    {
        var input = Input.ToList();
        var time = ulong.Parse(input[0].Replace(" ", "").Replace("Time:", ""));
        var distance = ulong.Parse(input[1].Replace(" ", "").Replace("Distance:", ""));

        var shortestPress = 0ul;
        for (var speed = 0ul; speed < time; speed++)
            if (speed * (time - speed) > distance)
            {
                shortestPress = speed;
                break;
            }

        var longestPress = 0ul;
        for (var speed = time; speed > 0; speed--)
            if (speed * (time - speed) > distance)
            {
                longestPress = speed;
                break;
            }

        return longestPress - shortestPress + 1;
    }
}
