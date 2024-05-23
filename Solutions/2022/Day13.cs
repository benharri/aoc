using System.Text.Json.Nodes;

namespace Solutions._2022;

/// <summary>
/// Day 13: <a href="https://adventofcode.com/2022/day/13"/>
/// </summary>
public sealed class Day13() : Day(2022, 13, "Distress Signal")
{
    private IEnumerable<JsonNode>? _packets;

    public override void ProcessInput() =>
        _packets = Input.Where(line => !string.IsNullOrWhiteSpace(line)).Select(s => JsonNode.Parse(s)!);

    private static int Compare(JsonNode? left, JsonNode? right)
    {
        if (left is JsonValue && right is JsonValue) return (int)left - (int)right;

        var leftAsArray = left as JsonArray ?? new JsonArray((int)left!);
        var rightAsArray = right as JsonArray ?? new JsonArray((int)right!);
        return leftAsArray.Zip(rightAsArray)
            .Select(p => Compare(p.First, p.Second))
            .FirstOrDefault(c => c != 0, leftAsArray.Count - rightAsArray.Count);
    }

    public override object Part1() =>
        _packets!.Chunk(2).Select((p, i) => Compare(p[0], p[1]) < 0 ? i + 1 : 0).Sum();

    public override object Part2()
    {
        JsonNode two = JsonNode.Parse("[[2]]")!, six = JsonNode.Parse("[[6]]")!;
        var packets = _packets!.Append(two).Append(six).ToList();
        packets.Sort(Compare);
        return (packets.IndexOf(two) + 1) * (packets.IndexOf(six) + 1);
    }
}
