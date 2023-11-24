namespace AOC2016;

/// <summary>
/// Day 4: <a href="https://adventofcode.com/2016/day/4"/>
/// </summary>
public sealed class Day04() : Day(2016, 4, "Security Through Obscurity")
{
    private List<Room> _rooms = null!;

    private record Room(string Name, int SectorId, string Checksum)
    {
        public static Room FromRawLine(string raw)
        {
            var s = raw.Split('[');
            var s2 = s[0].Split('-');
            return new(string.Join("", s2[..^1]).Replace("-", string.Empty), int.Parse(s2.Last()), s[1].TrimEnd(']'));
        }

        public bool IsRealRoom() =>
            Name.GroupBy(c => c)
                .OrderByDescending(c => c.Count())
                .ThenBy(c => c.Key)
                .Take(5)
                .Select(c => c.Key)
                .ToArray()
                .SequenceEqual(Checksum.ToCharArray());

        public string DecryptedName()
        {
            var answer = Name.ToCharArray();
            for (var i = 0; i < Name.Length; i++)
            for (var l = 0; l < SectorId % 26; l++)
                answer[i] = answer[i] == 'z' ? 'a' : (char)(answer[i] + 1);

            return new(answer);
        }
    }

    public override void ProcessInput()
    {
        _rooms = Input.Select(Room.FromRawLine).ToList();
    }

    public override object Part1() => _rooms.Where(r => r.IsRealRoom()).Sum(r => r.SectorId);

    public override object Part2() => _rooms.Single(r => r.DecryptedName().Contains("northpole")).SectorId;
}