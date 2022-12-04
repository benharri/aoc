using System.Text.Json;

namespace AOC2015;

/// <summary>
/// Day 12: <a href="https://adventofcode.com/2015/day/12"/>
/// </summary>
public sealed partial class Day12 : Day
{
    public Day12() : base(2015, 12, "JSAbacusFramework.io")
    {
    }
    
    [GeneratedRegex(@"-?\d+")]
    private static partial Regex Digits();

    public override object Part1() =>
        Digits().Matches(Input.First()).Sum(n => int.Parse(n.Value));

    public override object Part2()
    {
        var reader = new Utf8JsonReader(File.ReadAllBytes(FileName));
        var sum = 0;
        bool redObject = false, insideObject = false;
        
        while (reader.Read())
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.StartObject:
                    insideObject = true;
                    break;
                case JsonTokenType.EndObject:
                    insideObject = false;
                    redObject = false;
                    break;
                case JsonTokenType.String:
                    if (insideObject && reader.GetString()! == "red")
                        redObject = true;
                    break;
                case JsonTokenType.Number:
                    if (!redObject) sum += reader.GetInt32();
                    break;
            }
        }

        return sum;
    }
}
