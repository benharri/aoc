namespace AOC.Common;

public static class Util
{
    /// <summary>
    /// Naive least common multiple implementation.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static long Lcm(long a, long b) => a * b / Gcd(a, b);

    /// <summary>
    /// Naive greatest common denominator implementation.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Quickly parse an integer from a ReadOnlySpan by ascii index and radix shifting.
    /// </summary>
    /// <param name="span"></param>
    /// <returns></returns>
    public static int ParseIntFast(ReadOnlySpan<char> span)
    {
        var result = 0;
        for (var i = 0; i < span.Length; i++)
            result = result * 10 + span[i] - '0';
        return result;
    }

    /// <summary>
    /// Quickly parse a long from a ReadOnlySpan by ascii index and radix shifting.
    /// </summary>
    /// <param name="span"></param>
    /// <returns></returns>
    public static long ParseLongFast(ReadOnlySpan<char> span)
    {
        var result = 0L;
        for (var i = 0; i < span.Length; i++)
            result = result * 10 + span[i] - '0';
        return result;
    }
}
