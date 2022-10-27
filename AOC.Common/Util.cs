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
}