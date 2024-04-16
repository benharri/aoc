namespace AOC.Common;

public static class Util
{
    public static long Lcm(long a, long b) => a * b / Gcd(a, b);

    public static long Gcd(long a, long b)
    {
        while (true)
        {
            if (b == 0) return a;
            var a1 = a;
            a = b;
            b = a1 % b;
        }
    }

    public static int ParseIntFast(ReadOnlySpan<char> span)
    {
        var result = 0;
        for (var i = 0; i < span.Length; i++)
            result = result * 10 + span[i] - '0';
        return result;
    }

    public static long ParseLongFast(ReadOnlySpan<char> span)
    {
        var result = 0L;
        for (var i = 0; i < span.Length; i++)
            result = result * 10 + span[i] - '0';
        return result;
    }
}
