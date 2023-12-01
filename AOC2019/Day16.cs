namespace AOC2019;

public sealed class Day16() : Day(2019, 16, "Flawed Frequency Transmission")
{
    private static readonly int[] BasePattern = { 0, 1, 0, -1 };
    private int[]? _initialList;

    public override void ProcessInput() =>
        _initialList = Input.First().Select(c => c - '0').ToArray();

    public override object Part1()
    {
        var signal0 = _initialList!.ToArray();
        var signal1 = new int[signal0.Length];

        for (var i = 0; i < 100; i++)
            if (i % 2 == 0)
                CalculateSignal(signal0, signal1);
            else
                CalculateSignal(signal1, signal0);

        return new string(signal0.Take(8).Select(c => (char)(c + '0')).ToArray());
    }

    public override object Part2()
    {
        var messageOffset = _initialList!.Take(7).Aggregate((n, i) => n * 10 + i);
        var signal = _initialList!.Repeat(10_000).Skip(messageOffset).ToArray();

        for (var p = 0; p < 100; p++)
        {
            signal[^1] %= 10;
            for (var i = signal.Length - 2; i >= 0; i--)
                signal[i] = (signal[i + 1] + signal[i]) % 10;
        }

        return new string(signal.Take(8).Select(c => (char)(c + '0')).ToArray());
    }

    private static void CalculateSignal(int[] input, int[] output)
    {
        for (var j = 0; j < output.Length; j++)
            output[j] = Math.Abs(BasePattern
                .SelectMany(v => Enumerable.Repeat(v, j + 1))
                .Repeat()
                .Skip(1)
                .Take(input.Length)
                .Select((pv, i) => pv * input[i] % 10).Sum()) % 10;
    }
}
