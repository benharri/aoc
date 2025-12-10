using System.Globalization;
using System.Numerics;

namespace Solutions;

public readonly record struct Point2d<T>(T X, T Y) where T : INumber<T>
{
    public static Point2d<T> FromLine(string line)
    {
        var split = line.Split(',').Select(i => T.Parse(i, CultureInfo.InvariantCulture)).ToList();
        return new(split[0], split[1]);
    }

    public static implicit operator Point2d<T>((T x, T y) value) => new(value.x, value.y);

    public T AreaBetween(Point2d<T> other) => (T.Abs(X - other.X) + T.One) * (T.Abs(Y - other.Y) + T.One);

    public IEnumerable<Point2d<T>> LinePointsTo(Point2d<T> other)
    {
        if (X == other.X)
        {
            T y = T.Min(Y, other.Y), end = T.Max(Y, other.Y) + T.One;
            while (y < end) yield return (X, y++);
        }

        if (Y == other.Y)
        {
            T x = T.Min(X, other.X), end = T.Max(X, other.X) + T.One;
            while (x < end) yield return (x++, Y);
        }
    }

    public T ManhattanDistance(Point2d<T> other) => T.Abs(X - other.X) + T.Abs(Y - other.Y);
}

public readonly record struct Point3d<T>(T X, T Y, T Z) where T : INumber<T>
{
    public double EuclideanDistance(Point3d<T> other)
    {
        T x = X - other.X, y = Y - other.Y, z = Z - other.Z;
        return Math.Sqrt(Convert.ToDouble(x * x + y * y + z * z));
    }

    public static Point3d<T> FromLine(string line)
    {
        var split = line.Split(',').Select(i => T.Parse(i, CultureInfo.InvariantCulture)).ToList();
        return new(split[0], split[1], split[2]);
    }

    public static implicit operator Point3d<T>((T x, T y, T z) value) => new(value.x, value.y, value.z);

    public Point3d<T> Transform(Point3d<T> up, int rotation)
    {
        Point3d<T> reoriented = up switch
        {
            (0, 1, 0) => (X, Y, Z),
            (0, -1, 0) => (X, -Y, -Z),
            (1, 0, 0) => (Y, X, -Z),
            (-1, 0, 0) => (Y, -X, Z),
            (0, 0, 1) => (Y, Z, X),
            (0, 0, -1) => (Y, -Z, -X),
            _ => throw new("Invalid up vector"),
        };

        return rotation switch
        {
            0 => reoriented,
            1 => (reoriented.Z, reoriented.Y, -reoriented.X),
            2 => (-reoriented.X, reoriented.Y, -reoriented.Z),
            3 => (-reoriented.Z, reoriented.Y, reoriented.X),
            _ => throw new("Invalid rotation"),
        };
    }

    public Point3d<T> Translate(Point3d<T> p) => (X + p.X, Y + p.Y, Z + p.Z);
    public Point3d<T> Difference(Point3d<T> p) => (X - p.X, Y - p.Y, Z - p.Z);

    public T ManhattanDistance(Point3d<T> p)
    {
        var (dx, dy, dz) = Difference(p);
        return T.Abs(dx) + T.Abs(dy) + T.Abs(dz);
    }
}

public readonly record struct Point4d<T>(T X, T Y, T Z, T W) where T : INumber<T>
{
    public static Point4d<T> FromLine(string line)
    {
        var split = line.Split(',').Select(i => T.Parse(i, CultureInfo.InvariantCulture)).ToList();
        return new(split[0], split[1], split[2], split[3]);
    }

    public static implicit operator Point4d<T>((T x, T y, T z, T w) value) => new(value.x, value.y, value.z, value.w);
}
