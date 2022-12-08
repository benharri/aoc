namespace AOC2019;

public sealed class Day16 : Day
{
    private static readonly int[] BasePattern = { 0, 1, 0, -1 };
    private int[]? _initialList;

    public Day16() : base(2019, 16, "Flawed Frequency Transmission")
    {
    }
    
    public override void ProcessInput(){
        _initialList = Input.First().Select(c => int.Parse($"{c}")).ToArray();
    }

    public override object Part1()
    {
        const int phaseCount = 100;
        var signal0 = _initialList!.ToArray();
        var signal1 = new int[signal0.Length];

        for (var i = 0; i < phaseCount; i++)
            CalculateSignal(i % 2 == 0 ? signal0 : signal1, i % 2 == 0 ? signal1 : signal0);

        return new string(
            signal0.Take(8).Select(c => (char)(c + '0'))
                .ToArray());
    }

    public override object Part2()
    {
        const int phaseCount = 100;
        var messageOffset = _initialList!.Take(7).Aggregate((n, i) => n * 10 + i);
        var signal = _initialList!.Repeat(10_000).Skip(messageOffset).ToArray();

        for (var p = 0; p < phaseCount; p++)
        {
            signal[^1] %= 10;
            for (var i = signal.Length - 2; i >= 0; i--)
                signal[i] = (signal[i + 1] + signal[i]) % 10;
        }

        return new string(signal.Take(8).Select(c => (char)(c + '0')).ToArray());
    }

    private static void CalculateSignal(IReadOnlyList<int> input, IList<int> output)
    {
        for (var outputIndex = 0; outputIndex < output.Count; outputIndex++)
            output[outputIndex] =
                Math.Abs(PatternValues(outputIndex, input.Count).Select((pv, i) => pv * input[i] % 10).Sum()) % 10;
    }

    private static IEnumerable<int> PatternValues(int index, int count)
    {
        return BasePattern
            .SelectMany(v => Enumerable.Repeat(v, index + 1))
            .Repeat(int.MaxValue)
            .Skip(1)
            .Take(count);
    }
}
