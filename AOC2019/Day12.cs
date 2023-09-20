namespace AOC2019;

public sealed class Day12() : Day(2019, 12, "The N-Body Problem")
{
    private List<Position>? _moons;
    private int _step;

    public override void ProcessInput()
    {
        _moons = Input
            .Select(moon =>
                moon
                    .TrimStart('<')
                    .TrimEnd('>')
                    .Split(",")
                    .Select(val => int.Parse(val.Split("=").Last()))
            )
            .Select(moon => new Position(moon.ToList()))
            .ToList();

        foreach (var moon in _moons)
            moon.SetSiblings(_moons);
    }

    private void Step()
    {
        foreach (var moon in _moons!)
            moon.Gravitate();

        foreach (var moon in _moons)
            moon.Move();

        _step++;
    }

    public override object Part1()
    {
        while (_step < 1000)
            Step();

        return _moons!.Sum(p => p.TotalEnergy);
    }

    public override object Part2()
    {
        int cycleX = 0, cycleY = 0, cycleZ = 0;

        while (cycleX == 0 || cycleY == 0 || cycleZ == 0)
        {
            Step();
            if (cycleX == 0 && _moons!.All(m => m.Dx == 0)) cycleX = _step * 2;
            if (cycleY == 0 && _moons!.All(m => m.Dy == 0)) cycleY = _step * 2;
            if (cycleZ == 0 && _moons!.All(m => m.Dz == 0)) cycleZ = _step * 2;
        }

        return Util.Lcm(cycleX, Util.Lcm(cycleY, cycleZ));
    }

    public class Position(IList<int> moon)
    {
        private List<Position> _siblings = new();
        private int _x = moon[0], _y = moon[1], _z = moon[2];
        public int Dx = 0, Dy = 0, Dz = 0;

        private int KineticEnergy =>
            Math.Abs(_x) + Math.Abs(_y) + Math.Abs(_z);

        private int PotentialEnergy =>
            Math.Abs(Dx) + Math.Abs(Dy) + Math.Abs(Dz);

        internal int TotalEnergy =>
            KineticEnergy * PotentialEnergy;

        public void SetSiblings(IEnumerable<Position> positions) =>
            _siblings = positions.Where(p => p != this).ToList();

        public override string ToString() =>
            $"pos=<x={_x}, y={_y}, z={_z}> vel=<x={Dx}, y={Dy}, z={Dz}>";

        internal void Gravitate()
        {
            foreach (var m in _siblings)
            {
                if (_x != m._x) Dx += _x > m._x ? -1 : 1;
                if (_y != m._y) Dy += _y > m._y ? -1 : 1;
                if (_z != m._z) Dz += _z > m._z ? -1 : 1;
            }
        }

        internal void Move()
        {
            _x += Dx;
            _y += Dy;
            _z += Dz;
        }
    }
}