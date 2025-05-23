namespace Solutions._2020;

/// <summary>
/// Day 2: <a href="https://adventofcode.com/2020/day/1" />
/// </summary>
public sealed class Day02PasswordPhilosophy() : Day(2020, 2, "Password Philosophy")
{
    private ImmutableList<Password>? _passwords;

    public override void ProcessInput() =>
        _passwords = Input.Select(p => new Password(p)).ToImmutableList();

    public override object Part1() =>
        _passwords!.Count(p => p.IsValid);

    public override object Part2() =>
        _passwords!.Count(p => p.IsValidByIndex);

    private class Password
    {
        public Password(string line)
        {
            var split = line.Split(": ", 2);
            var split2 = split[0].Split(' ', 2);
            var indices = split2[0].Split('-', 2);
            I = int.Parse(indices[0]);
            J = int.Parse(indices[1]);
            C = char.Parse(split2[1]);
            Value = split[1];
        }

        public bool IsValid =>
            Count >= I && Count <= J;

        public bool IsValidByIndex =>
            (Value[I - 1] == C) ^ (Value[J - 1] == C);

        private int Count =>
            Value.Count(p => p == C);

        private int I { get; }
        private int J { get; }
        private char C { get; }
        private string Value { get; }
    }
}
