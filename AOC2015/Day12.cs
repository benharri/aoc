using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AOC2015;

/// <summary>
/// Day 12: <a href="https://adventofcode.com/2015/day/12"/>
/// </summary>
public sealed partial class Day12() : Day(2015, 12, "JSAbacusFramework.io")
{
    [GeneratedRegex(@"-?\d+")]
    private static partial Regex Digits();

    public override void ProcessInput()
    {
    }

    public override object Part1() =>
        Digits().Matches(Input.First()).Sum(n => int.Parse(n.Value));

    public override object Part2()
    {
        dynamic j = JsonConvert.DeserializeObject(Input.First())!;
        return GetSum(j, "red");
    }

    private long GetSum(JObject o, string? avoid = null)
    {
        var shouldAvoid = o.Properties()
            .Select(a => a.Value).OfType<JValue>()
            .Select(v => v.Value).Contains(avoid);

        return shouldAvoid ? 0 : o.Properties().Sum((dynamic a) => (long)GetSum(a.Value, avoid));
    }

    private long GetSum(JArray arr, string avoid) => arr.Sum((dynamic a) => (long)GetSum(a, avoid));

    private long GetSum(JValue val, string avoid) => val.Type == JTokenType.Integer ? (long)(val.Value ?? 0L) : 0;
}