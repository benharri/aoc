using System.Numerics;

namespace Solutions;

public static class Extensions
{
    /// <summary>
    /// <c>string.Join</c> Wrapper
    /// </summary>
    /// <param name="enumerable"></param>
    /// <param name="delimiter"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static string ToDelimitedString<T>(this IEnumerable<T> enumerable, string delimiter = "") =>
        string.Join(delimiter, enumerable);

    /// <summary>
    /// Loop over a sequence with an optional number of times.
    /// </summary>
    /// <param name="sequence"></param>
    /// <param name="count"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IEnumerable<T> Repeat<T>(this IEnumerable<T> sequence, int? count = null)
    {
        while (count == null || count-- > 0)
            // ReSharper disable once PossibleMultipleEnumeration
            foreach (var item in sequence)
                yield return item;
    }

    /// <summary>
    /// Increased accuracy for stopwatch based on frequency.
    /// </summary>
    /// <param name="stopwatch"></param>
    /// <returns></returns>
    public static double ScaleMilliseconds(this Stopwatch stopwatch) =>
        1_000 * stopwatch.ElapsedTicks / (double)Stopwatch.Frequency;

    /// <summary>
    /// Given an array, it returns a rotated copy.
    /// </summary>
    /// <param name="array">The two-dimensional jagged array to rotate.</param>
    public static T[][] Rotate<T>(this T[][] array)
    {
        var result = new T[array[0].Length][];
        for (var i = 0; i < result.Length; i++)
            result[i] = new T[array.Length];

        for (var i = 0; i < array.Length; i++)
            for (var j = 0; j < array[i].Length; j++)
                result[i][j] = array[array.Length - j - 1][i];

        return result;
    }

    /// <summary>
    /// Given a jagged array, it returns a diagonally flipped copy.
    /// </summary>
    /// <param name="array">The two-dimensional jagged array to flip.</param>
    public static T[][] FlipHorizontally<T>(this IEnumerable<T[]> array) =>
        array.Select(x => x.Reverse().ToArray()).ToArray();

    /// <summary>
    /// Does the <see cref="Range"/> include a given int?
    /// </summary>
    /// <param name="range"></param>
    /// <param name="i"></param>
    /// <returns></returns>
    public static bool Contains(this Range range, int i) =>
        i >= range.Start.Value && i <= range.End.Value;

    /// <summary>
    /// Does <paramref name="r1"/> contain the entire range of <paramref name="r2"/>?
    /// </summary>
    /// <param name="r1"></param>
    /// <param name="r2"></param>
    /// <returns></returns>
    public static bool Contains(this Range r1, Range r2) =>
        r1.Start.Value <= r2.Start.Value && r1.End.Value >= r2.End.Value;

    /// <summary>
    /// Do <paramref name="r1"/> and <paramref name="r2"/> overlap?
    /// </summary>
    /// <param name="r1"></param>
    /// <param name="r2"></param>
    /// <returns></returns>
    public static bool Overlaps(this Range r1, Range r2) =>
        r1.Start.Value <= r2.End.Value && r1.End.Value >= r2.Start.Value &&
        r2.Start.Value <= r1.End.Value && r2.End.Value >= r1.Start.Value;

    /// <summary>
    /// Creates a new BigInteger from a binary (Base2) string
    /// Based on <a href="https://gist.github.com/mjs3339/73042bc0e717f98796ee9fa131e458d4">mjs3339's gist</a>
    /// </summary>
    public static BigInteger BigIntegerFromBinaryString(this string binaryValue)
    {
        BigInteger res = 0;
        if (binaryValue.Count(b => b == '1') + binaryValue.Count(b => b == '0') != binaryValue.Length) return res;
        foreach (var c in binaryValue)
        {
            res <<= 1;
            res += c == '1' ? 1 : 0;
        }

        return res;
    }

    /// <summary>
    /// Generate all permutations of an Enumerable.
    /// </summary>
    /// <param name="list"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IEnumerable<IEnumerable<T>> Permute<T>(this IEnumerable<T> list)
    {
        var array = list as T[] ?? list.ToArray();
        return array.Length == 1
            ? new[] { array }
            : array.SelectMany(t => Permute(array.Where(x => !x!.Equals(t))), (v, p) => p.Prepend(v));
    }

    /// <summary>
    /// Raise an integer to a given <paramref name="power"/>.
    /// </summary>
    /// <param name="i"></param>
    /// <param name="power"></param>
    /// <returns></returns>
    public static int Pow(this int i, int power)
    {
        var pow = (uint)power;
        var ret = 1;
        while (pow != 0)
        {
            if ((pow & 1) == 1) ret *= i;
            i *= i;
            pow >>= 1;
        }

        return ret;
    }

    /// <summary>
    /// Attach the index of each element.
    /// </summary>
    /// <param name="source"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IEnumerable<KeyValuePair<int, T>> Indexed<T>(this IEnumerable<T> source) =>
        source.Select((t, i) => new KeyValuePair<int, T>(i, t));

    /// <summary>
    /// Wrapper for KeyValuePair to enable passing delegates.
    /// </summary>
    /// <param name="source"></param>
    /// <param name="func"></param>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static IEnumerable<KeyValuePair<TKey, TValue>> WhereValue<TKey, TValue>(
        this IEnumerable<KeyValuePair<TKey, TValue>> source, Func<TValue, bool> func) =>
        source.Where(pair => func(pair.Value));

    /// <summary>
    /// Compute the Hamming distance between two strings.
    /// </summary>
    /// <param name="s1"></param>
    /// <param name="other"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static int HammingDistance(this string s1, string other)
    {
        if (s1.Length != other.Length) throw new("Strings must be equal length.");
        return s1.Zip(other).Count(s => s.First != s.Second);
    }
}
