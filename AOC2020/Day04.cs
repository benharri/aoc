namespace AOC2020;

/// <summary>
///     Day 4: <a href="https://adventofcode.com/2020/day/4" />
/// </summary>
public sealed partial class Day04 : Day
{
    private List<Passport>? _passports;

    public Day04() : base(2020, 4, "Passport Processing")
    {
    }

    public override void ProcessInput()
    {
        _passports = new();

        var a = new List<string>();
        foreach (var line in Input)
        {
            if (line == "")
            {
                _passports.Add(Passport.Parse(a));
                a.Clear();
                continue;
            }

            a.Add(line);
        }

        if (a.Any()) _passports.Add(Passport.Parse(a));
    }

    public override object Part1() => _passports!.Count(p => p.IsValid);

    public override object Part2() => _passports!.Count(p => p.ExtendedValidation());

    private partial class Passport
    {
        private string? _byr;
        private string? _cid;
        private string? _ecl;
        private string? _eyr;
        private string? _hcl;
        private string? _hgt;
        private string? _iyr;
        private string? _pid;

        public bool IsValid =>
            _byr != null &&
            _iyr != null &&
            _eyr != null &&
            _hgt != null &&
            _hcl != null &&
            _ecl != null &&
            _pid != null;

        public bool ExtendedValidation()
        {
            if (!IsValid) return false;

            // birth year
            if (int.TryParse(_byr, out var byr))
            {
                if (byr is < 1920 or > 2002)
                    return false;
            }
            else
            {
                return false;
            }

            // issuance year
            if (int.TryParse(_iyr, out var iyr))
            {
                if (iyr is < 2010 or > 2020)
                    return false;
            }
            else
            {
                return false;
            }

            // expiration year
            if (int.TryParse(_eyr, out var eyr))
            {
                if (eyr is < 2020 or > 2030)
                    return false;
            }
            else
            {
                return false;
            }

            // height
            if (_hgt!.EndsWith("cm"))
            {
                var h = _hgt[..3];
                if (int.TryParse(h, out var hgt))
                {
                    if (hgt is < 150 or > 193)
                        return false;
                }
                else
                {
                    return false;
                }
            }
            else if (_hgt.EndsWith("in"))
            {
                var h = _hgt[..2];
                if (int.TryParse(h, out var hgt))
                {
                    if (hgt is < 59 or > 76)
                        return false;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            // hair color
            if (!HexColor().IsMatch(_hcl!))
                return false;

            // eye color
            if (!new[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }.Contains(_ecl))
                return false;

            // passport id
            return _pid == null || _pid.Length == 9;
        }

        public static Passport Parse(IEnumerable<string> list)
        {
            var passport = new Passport();
            foreach (var entry in string.Join(' ', list).Split(' ', StringSplitOptions.TrimEntries))
            {
                var spl = entry.Split(':', 2);
                switch (spl[0])
                {
                    case "byr":
                        passport._byr = spl[1];
                        break;
                    case "iyr":
                        passport._iyr = spl[1];
                        break;
                    case "eyr":
                        passport._eyr = spl[1];
                        break;
                    case "hgt":
                        passport._hgt = spl[1];
                        break;
                    case "hcl":
                        passport._hcl = spl[1];
                        break;
                    case "ecl":
                        passport._ecl = spl[1];
                        break;
                    case "pid":
                        passport._pid = spl[1];
                        break;
                    case "cid":
                        passport._cid = spl[1];
                        break;
                }
            }

            return passport;
        }

        [GeneratedRegex("#[0-9a-f]{6}")]
        private static partial Regex HexColor();
    }
}
