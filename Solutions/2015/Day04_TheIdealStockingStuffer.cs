using System.Security.Cryptography;

namespace Solutions._2015;

/// <summary>
/// Day 4: <a href="https://adventofcode.com/2015/day/4"/>
/// </summary>
public sealed class Day04TheIdealStockingStuffer() : Day(2015, 4, "The Ideal Stocking Stuffer")
{
    private string? _key;

    public override void ProcessInput() => _key = Input.First();

    public override object Part1()
    {
        var counter = 0;

        while (true)
        {
            var hash = MD5.HashData(Encoding.ASCII.GetBytes(_key + counter++));
            if (hash[0] == 0 && hash[1] == 0 && (hash[2] & 0xf0) == 0) return counter - 1;
        }
    }

    public override object Part2()
    {
        var counter = 9_000_000;

        while (true)
        {
            var hashBytes = MD5.HashData(Encoding.ASCII.GetBytes(_key + counter++));
            if (hashBytes[0] == 0 && hashBytes[1] == 0 && hashBytes[2] == 0) return counter - 1;
        }
    }
}
