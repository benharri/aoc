using System.Security.Cryptography;

namespace AOC2016;

/// <summary>
/// Day 5: <a href="https://adventofcode.com/2016/day/5"/>
/// </summary>
public sealed class Day05() : Day(2016, 5, "How About a Nice Game of Chess?")
{
    public override object Part1()
    {
        var s = Input.First();
        var answer = new char[8];
        var index = 0;

        for (var i = 0; i < answer.Length; i++)
        {
            while (true)
            {
                var hash = BitConverter.ToString(MD5.HashData(Encoding.ASCII.GetBytes(s + index++))).Replace("-", "");
                if (hash.StartsWith("00000"))
                {
                    answer[i] = hash[5];
                    break;
                }
            }
        }

        return new string(answer);
    }

    public override object Part2()
    {
        var s = Input.First();
        var answer = new char[8];
        int index = 0, found = 0;

        while (true)
        {
            var hash = BitConverter.ToString(MD5.HashData(Encoding.ASCII.GetBytes(s + index++))).Replace("-", "");
            if (hash.StartsWith("00000"))
            {
                var target = hash[5] - '0';
                if (target is < 8 and >= 0 && answer[target] == 0)
                {
                    answer[target] = hash[6];
                    if (++found == 8) break;
                }
            }
        }

        return new string(answer);
    }
}
