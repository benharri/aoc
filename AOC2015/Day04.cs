using System.Security.Cryptography;

namespace AOC2015;

/// <summary>
/// Day 4: <see href="https://adventofcode.com/2015/day/4"/>
/// </summary>
public sealed class Day04 : Day
{
    private readonly string _key;

    public Day04() : base(2015, 4, "The Ideal Stocking Stuffer")
    {
        _key = Input.First();
    }

    public override object Part1()
    {
        var md5 = MD5.Create();
        var counter = 0;

        while (true)
        {
            var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(_key + counter));
            if (BitConverter.ToString(hash).Replace("-", "").StartsWith("00000")) 
                return counter;
            counter++;
        }
    }

    public override object Part2()
    {
        var md5 = MD5.Create();
        var counter = 0;

        while (true)
        {
            var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(_key + counter));
            if (BitConverter.ToString(hash).Replace("-", "").StartsWith("000000"))
                return counter;
            counter++;
        }
    }
}
