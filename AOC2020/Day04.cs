using MoreLinq;

namespace AOC2020;

/// <summary>
///     Day 4: <a href="https://adventofcode.com/2020/day/4" />
/// </summary>
public sealed partial class Day04() : Day(2020, 4, "Passport Processing")
{
    private List<Dictionary<string, string>>? _passports;
    private static readonly string[] RequiredFieldNames = ["byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"];
    private static readonly string[] EyeColors = ["amb", "blu", "brn", "gry", "grn", "hzl", "oth"];

    public override void ProcessInput() =>
        _passports = Input.Split("").Select(Parse).ToList();

    [GeneratedRegex("#[0-9a-f]{6}")]
    private static partial Regex HexColor();

    private static Dictionary<string, string> Parse(IEnumerable<string> list) =>
        string.Join(' ', list).Split(' ', StringSplitOptions.TrimEntries)
            .ToDictionary(k => k.Split(':', 2)[0], v => v.Split(':', 2)[1]);

    private static bool IsValid(Dictionary<string, string> d) => RequiredFieldNames.All(d.ContainsKey);

    private static bool ExtendedValidation(Dictionary<string, string> d)
    {
        if (!IsValid(d)) return false;

        // birth year
        if (int.TryParse(d["byr"], out var byr))
        {
            if (byr is < 1920 or > 2002) return false;
        }
        else return false;

        // issuance year
        if (int.TryParse(d["iyr"], out var iyr))
        {
            if (iyr is < 2010 or > 2020) return false;
        }
        else return false;

        // expiration year
        if (int.TryParse(d["eyr"], out var eyr))
        {
            if (eyr is < 2020 or > 2030) return false;
        }
        else return false;

        // height
        if (d["hgt"].EndsWith("cm"))
        {
            if (int.TryParse(d["hgt"][..3], out var hgt))
            {
                if (hgt is < 150 or > 193) return false;
            }
            else return false;
        }
        else if (d["hgt"].EndsWith("in"))
        {
            if (int.TryParse(d["hgt"][..2], out var hgt))
            {
                if (hgt is < 59 or > 76) return false;
            }
            else return false;
        }
        else return false;

        // hair color
        if (!HexColor().IsMatch(d["hcl"])) return false;

        // eye color
        if (!EyeColors.Contains(d["ecl"]))
            return false;

        // passport id
        return !d.ContainsKey("pid") || d["pid"].Length == 9;
    }

    public override object Part1() => _passports!.Count(IsValid);
    public override object Part2() => _passports!.Count(ExtendedValidation);
}
