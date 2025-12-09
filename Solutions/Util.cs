// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable ForCanBeConvertedToForeach
namespace Solutions;

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

    public static int ParseIntFast(string arg) => ParseIntFast(arg.AsSpan());

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

    public static long ParseLongFast(string arg) => ParseLongFast(arg.AsSpan());

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

    /// <summary>Integer modulus to range [0, <paramref name="b"/>)</summary>
    public static double Modulus(float a, float b) => a - b * Math.Floor(a / b);

    /// <summary>
    /// Choose groups of size m from the range 0 to n
    /// </summary>
    /// <param name="n"></param>
    /// <param name="m"></param>
    public static IEnumerable<int[]> ChooseIntsUpTo(int n, int m)
    {
        int[] result = new int[m];
        Stack<int> stack = new(m);
        stack.Push(0);
        
        while (stack.Count > 0)
        {
            int index = stack.Count - 1;
            int value = stack.Pop();
            while (value < n)
            {
                result[index++] = value++;
                stack.Push(value);
                if (index != m) continue;
                yield return (int[])result.Clone();
                break;
            }
        }
    }
}
