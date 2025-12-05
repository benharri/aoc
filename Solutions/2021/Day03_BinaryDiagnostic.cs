using System.Globalization;
using System.Numerics;

namespace Solutions._2021;

/// <summary>
/// Day 3: <a href="https://adventofcode.com/2021/day/3"/>
/// </summary>
public sealed class Day03BinaryDiagnostic() : Day(2021, 3, "Binary Diagnostic")
{
    private List<string>? _report;

    public override void ProcessInput() =>
        _report = Input.ToList();

    public override object Part1()
    {
        var l = _report!.Count / 2;
        var g = new StringBuilder();
        var e = new StringBuilder();

        foreach (var i in Enumerable.Range(0, _report[0].Length))
        {
            var ones = _report.Select(r => r[i]).Count(c => c == '1');
            g.Append(ones > l ? '1' : '0');
            e.Append(ones > l ? '0' : '1');
        }

        var gamma = BigInteger.Parse($"0{g}", NumberStyles.BinaryNumber);
        var epsilon = BigInteger.Parse($"0{e}", NumberStyles.BinaryNumber);

        return gamma * epsilon;
    }

    public override object Part2()
    {
        var o = _report!;
        var c = _report!;

        var i = 0;
        while (o.Count > 1)
        {
            var most = MostCommon(i, o);
            o = o.Where(r => r[i] == most).ToList();
            i++;
        }
        var o2 = BigInteger.Parse($"0{o.Single()}", NumberStyles.BinaryNumber);

        i = 0;
        while (c.Count > 1)
        {
            var most = MostCommon(i, c);
            c = c.Where(r => r[i] != most).ToList();
            i++;
        }
        var co2 = BigInteger.Parse($"0{c.Single()}", NumberStyles.BinaryNumber);

        return o2 * co2;

        char MostCommon(int index, IReadOnlyCollection<string> report) =>
            report.Count(r => r[index] == '1') >= report.Count / 2.0 ? '1' : '0';
    }
}
