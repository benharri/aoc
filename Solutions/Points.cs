namespace Solutions;

public readonly record struct Point2d(int X, int Y)
{
    public long AreaBetween(Point2d other) => Math.Abs(X - other.X - 1) * Math.Abs(Y - other.Y - 1);

    public static Point2d FromLine(string line)
    {
        var split = line.Split(',').Select(int.Parse).ToList();
        return new(split[0], split[1]);
    }
}

public readonly record struct Point2dL(long X, long Y)
{
    public long AreaBetween(Point2dL other) => (Math.Abs(X - other.X) + 1) * (Math.Abs(Y - other.Y) + 1);

    public static Point2dL FromLine(string line)
    {
        var split = line.Split(',').Select(long.Parse).ToList();
        return new(split[0], split[1]);
    }
}

public readonly record struct Point3d(int X, int Y, int Z)
{
    public double EuclideanDistance(Point3d other) =>
        Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2) + Math.Pow(Z - other.Z, 2));

    public static Point3d FromLine(string line)
    {
        var split = line.Split(',').Select(int.Parse).ToList();
        return new(split[0], split[1], split[2]);
    }
}
