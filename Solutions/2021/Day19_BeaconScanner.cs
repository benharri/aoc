namespace Solutions._2021;

/// <summary>
/// Day 19: <a href="https://adventofcode.com/2021/day/19"/>
/// </summary>
public sealed class Day19BeaconScanner() : Day(2021, 19, "Beacon Scanner")
{
    private static readonly (int, int, int)[] Axes =
        [(0, 1, 0), (0, -1, 0), (1, 0, 0), (-1, 0, 0), (0, 0, 1), (0, 0, -1)];

    private List<HashSet<Point3d<int>>>? _scans;
    private List<HashSet<Point3d<int>>> _scanners = [];

    public override void ProcessInput() =>
        _scans = Input
            .Aggregate(new List<HashSet<Point3d<int>>>(), (list, line) =>
            {
                if (string.IsNullOrWhiteSpace(line)) return list;

                if (line.StartsWith("---"))
                {
                    list.Add([]);
                    return list;
                }

                var parts = line.Split(',').Select(int.Parse).ToList();
                list[^1].Add((parts[0], parts[1], parts[2]));
                return list;
            });

    private static (HashSet<Point3d<int>> alignedBeacons, Point3d<int> translation, Point3d<int> up, int rotation)? Align(
        HashSet<Point3d<int>> beacons1, IReadOnlyCollection<Point3d<int>> beacons2)
    {
        // Fix beacons1, rotate beacons2
        foreach (var axis in Axes)
        {
            for (var rotation = 0; rotation < 4; rotation++)
            {
                var rotatedBeacons2 = new HashSet<Point3d<int>>(beacons2.Select(b => b.Transform(axis, rotation)));

                foreach (var b1 in beacons1)
                {
                    foreach (var matchingB1InB2 in rotatedBeacons2)
                    {
                        var delta = b1.Difference(matchingB1InB2);
                        var transformedBeacons2 =
                            new HashSet<Point3d<int>>(rotatedBeacons2.Select(b => b.Translate(delta)));

                        var intersection = new HashSet<Point3d<int>>();
                        intersection.UnionWith(transformedBeacons2);
                        intersection.IntersectWith(beacons1);
                        if (intersection.Count >= 12)
                            return (transformedBeacons2, delta, axis, rotation);
                    }
                }
            }
        }

        return null;
    }

    private static (List<HashSet<Point3d<int>>> scans, List<HashSet<Point3d<int>>> scanners) Reduce(
        IReadOnlyList<HashSet<Point3d<int>>> scans, IReadOnlyList<HashSet<Point3d<int>>> scanners)
    {
        var toRemove = new HashSet<int>();
        for (var i = 0; i < scans.Count - 1; i++)
        {
            for (var j = i + 1; j < scans.Count; j++)
            {
                if (toRemove.Contains(j)) continue;

                var alignment = Align(scans[i], scans[j]);
                if (alignment == null) continue;

                // Convert all scanners from j coordinates to i coordinates
                foreach (var s in scanners[j])
                    scanners[i].Add(alignment.Value.translation.Translate(
                        s.Transform(alignment.Value.up, alignment.Value.rotation)));

                // Merge the scan sets
                scans[i].UnionWith(alignment.Value.alignedBeacons);
                toRemove.Add(j);
            }
        }

        // Skip all scans and scanners that were merged
        return (scans.Where((_, i) => !toRemove.Contains(i)).ToList(),
            scanners.Where((_, i) => !toRemove.Contains(i)).ToList());
    }


    public override object Part1()
    {
        var scans = _scans!;
        _scanners = scans.Select(_ => new HashSet<Point3d<int>> { (0, 0, 0) }).ToList();
        while (scans.Count > 1)
            (scans, _scanners) = Reduce(scans, _scanners);

        return scans[0].Count;
    }

    public override object Part2()
    {
        var scannerList = _scanners[0].ToList();
        return Enumerable.Range(0, scannerList.Count - 1)
            .SelectMany(i => Enumerable.Range(i + 1, scannerList.Count - i - 1).Select(j => (i, j)))
            .Max(pair => scannerList[pair.i].ManhattanDistance(scannerList[pair.j]));
    }
}
