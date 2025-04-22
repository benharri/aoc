using System.Security.Cryptography;

namespace Solutions._2016;

/// <summary>
/// Day 5: <a href="https://adventofcode.com/2016/day/5"/>
/// </summary>
public sealed class Day05HowAboutANiceGameOfChess() : Day(2016, 5, "How About a Nice Game of Chess?")
{
    private string? _keyBase;

    public override void ProcessInput() => _keyBase = Input.First();

    public override object Part1()
    {
        var answer = new char[8];
        var index = 0;

        for (var i = 0; i < answer.Length; i++)
        {
            while (true)
            {
                var chars = _keyBase + index++;
                var bytes = Encoding.ASCII.GetBytes(chars);
                var hashData = MD5.HashData(bytes);

                // bail out before converting back to string
                if (hashData[0] != 0 || hashData[1] != 0 || (hashData[2] & 0xf0) != 0) continue;

                var hash = Convert.ToHexString(hashData);
                answer[i] = hash[5];
                break;
            }
        }

        return new string(answer);
    }

    public override object Part2()
    {
        var answer = new char[8];
        int index = 0, found = 0;

        while (found < 8)
        {
            var chars = _keyBase + index++;
            var bytes = Encoding.ASCII.GetBytes(chars);
            var hashData = MD5.HashData(bytes);

            // compare bytes for leading zeros and bail if there aren't five of them
            if (hashData[0] != 0 || hashData[1] != 0 || (hashData[2] & 0xf0) != 0) continue;

            var hash = Convert.ToHexString(hashData);
            var target = hash[5] - '0';
            if (target is >= 8 or < 0 || answer[target] != 0) continue;

            answer[target] = hash[6];
            found++;
        }

        return new string(answer);
    }
}
