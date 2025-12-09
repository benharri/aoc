namespace Solutions;

public static class Extensions
{
    /// <param name="enumerable"></param>
    /// <typeparam name="T"></typeparam>
    extension<T>(IEnumerable<T> enumerable)
    {
        /// <summary>
        /// <c>string.Join</c> Wrapper
        /// </summary>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public string Join(string delimiter = "") =>
            string.Join(delimiter, enumerable);

        /// <summary>
        /// Loop over a sequence with an optional number of times.
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public IEnumerable<T> Repeat(int? count = null)
        {
            while (count == null || count-- > 0)
                // ReSharper disable once PossibleMultipleEnumeration
                foreach (var item in enumerable)
                    yield return item;
        }

        /// <summary>
        /// Generate all permutations of an Enumerable.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IEnumerable<T>> Permute()
        {
            var array = enumerable as T[] ?? enumerable.ToArray();
            return array.Length == 1
                ? [array]
                : array.SelectMany(t => Permute(array.Where(x => !x!.Equals(t))), (v, p) => p.Prepend(v));
        }

        public IEnumerable<(T First, T Second)> Pairs()
        {
            var list = enumerable.ToList();
            ArgumentOutOfRangeException.ThrowIfLessThan(list.Count, 2);
            foreach (int[] j in Util.ChooseIntsUpTo(list.Count, 2))
                yield return (list[j[0]], list[j[1]]);
        }

        /// <summary>
        /// Attach the index of each element.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<KeyValuePair<int, T>> Indexed() =>
            enumerable.Select((t, i) => new KeyValuePair<int, T>(i, t));
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

    /// <param name="range"></param>
    extension(Range range)
    {
        /// <summary>
        /// Does the <see cref="Range"/> include a given int?
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public bool Contains(int i) =>
            i >= range.Start.Value && i <= range.End.Value;

        /// <summary>
        /// Does <paramref name="range"/> contain the entire range of <paramref name="r2"/>?
        /// </summary>
        /// <param name="r2"></param>
        /// <returns></returns>
        public bool Contains(Range r2) =>
            range.Start.Value <= r2.Start.Value && range.End.Value >= r2.End.Value;

        /// <summary>
        /// Do <paramref name="range"/> and <paramref name="r2"/> overlap?
        /// </summary>
        /// <param name="r2"></param>
        /// <returns></returns>
        public bool Overlaps(Range r2) =>
            range.Start.Value <= r2.End.Value && range.End.Value >= r2.Start.Value &&
            r2.Start.Value <= range.End.Value && r2.End.Value >= range.Start.Value;
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
