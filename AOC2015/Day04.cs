using System.Security.Cryptography;

namespace AOC2015;

/// <summary>
/// Day 4: <a href="https://adventofcode.com/2015/day/4"/>
/// </summary>
public sealed class Day04 : Day
{
    private string? _key;

    public Day04() : base(2015, 4, "The Ideal Stocking Stuffer")
    {
    }

    public override void ProcessInput()
    {
        _key = Input.First();
    }

    public override object Part1()
    {
        var counter = 0;

        while (true)
        {
            var hash = MD5.HashData(Encoding.ASCII.GetBytes(_key + counter));
            if (BitConverter.ToString(hash).Replace("-", "").StartsWith("00000"))
                return counter;
            counter++;
        }
    }

    public override object Part2()
    {
        var counter = 0;

        while (true)
        {
            var hash = MD5.HashData(Encoding.ASCII.GetBytes(_key + counter));
            if (BitConverter.ToString(hash).Replace("-", "").StartsWith("000000"))
                return counter;
            counter++;
        }
    }
}
