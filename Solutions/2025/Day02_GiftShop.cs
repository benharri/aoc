namespace Solutions._2025;

/// <summary>
/// Day 2: <a href="https://adventofcode.com/2025/day/2"/>
/// </summary>
public sealed partial class Day02GiftShop() : Day(2025, 2, "Gift Shop")
{
    [GeneratedRegex(@"^(.+)\1+$")]
    private static partial Regex RepeatingDigitSequence();

    public override object Part1() =>
        Input.First().Split(',')
            .Select(r => r.Split('-').Select(long.Parse).ToList())
            .Sum(q =>
            {
                var temp = 0L;
                for (var i = q[0]; i <= q[1]; i++)
                {
                    var s = i.ToString();
                    var half = s.Length / 2;
                    if (s[half..] == s[..half]) temp += i;
                }

                return temp;
            });

    public override object Part2() =>
        Input.First().Split(',')
            .Select(r => r.Split('-').Select(Util.ParseLongFast).ToList())
            .Sum(q =>
            {
                var temp = 0L;
                for (var i = q[0]; i <= q[1]; i++)
                {
                    if (RepeatingDigitSequence().IsMatch(i.ToString())) temp += i;
                }

                return temp;
            });
}
