﻿namespace AOC2015;

/// <summary>
/// Day 6: <see href="https://adventofcode.com/2015/day/6"/>
/// </summary>
public sealed partial class Day06 : Day
{
    [GeneratedRegex(@"(\d+),(\d+) through (\d+),(\d+)")]
    private static partial Regex Coords();

    private readonly Dictionary<(int x, int y), bool> _lightGrid = new();
    private readonly Dictionary<(int x, int y), int> _brightnessGrid = new();

    public Day06() : base(2015, 6, "Probably a Fire Hazard")
    {
    }

    public override object Part1()
    {
        foreach (var line in Input)
        {
            var d = Coords().Match(line).Groups.Values.Skip(1).Select(v => int.Parse(v.Value)).ToList();
            int x1 = d[0], y1 = d[1], x2 = d[2], y2 = d[3];
            int xStart = Math.Min(x1, x2), xEnd = Math.Max(x1, x2), yStart = Math.Min(y1, y2), yEnd = Math.Max(y1, y2);

            for (var x = xStart; x <= xEnd; x++)
            {
                for (var y = yStart; y <= yEnd; y++)
                {
                    if (line.StartsWith("toggle"))
                    {
                        if (_lightGrid.ContainsKey((x, y)))
                        {
                            _lightGrid[(x, y)] = !_lightGrid[(x, y)];
                        }
                        else
                        {
                            _lightGrid[(x, y)] = true;
                        }
                    }
                    else if (line.StartsWith("turn on"))
                    {
                        _lightGrid[(x, y)] = true;
                    }
                    else if (line.StartsWith("turn off"))
                    {
                        _lightGrid[(x, y)] = false;
                    }
                }
            }
        }

        return _lightGrid.Count(v => v.Value);
    }

    public override object Part2()
    {
        foreach (var line in Input)
        {
            var d = Coords().Match(line).Groups.Values.Skip(1).Select(v => int.Parse(v.Value)).ToList();
            int x1 = d[0], y1 = d[1], x2 = d[2], y2 = d[3];
            int xStart = Math.Min(x1, x2), xEnd = Math.Max(x1, x2), yStart = Math.Min(y1, y2), yEnd = Math.Max(y1, y2);

            for (var x = xStart; x <= xEnd; x++)
            {
                for (var y = yStart; y <= yEnd; y++)
                {
                    if (line.StartsWith("toggle"))
                    {
                        if (_brightnessGrid.ContainsKey((x, y)))
                        {
                            _brightnessGrid[(x, y)] += 2;
                        }
                        else
                        {
                            _brightnessGrid[(x, y)] = 2;
                        }
                    }
                    else if (line.StartsWith("turn on"))
                    {
                        if (_brightnessGrid.ContainsKey((x, y)))
                        {
                            _brightnessGrid[(x, y)]++;
                        }
                        else
                        {
                            _brightnessGrid[(x, y)] = 1;
                        }
                    }
                    else if (line.StartsWith("turn off"))
                    {
                        if (_brightnessGrid.ContainsKey((x, y)) && _brightnessGrid[(x, y)] > 0)
                        {
                            _brightnessGrid[(x, y)]--;
                        }
                        else
                        {
                            _brightnessGrid[(x, y)] = 0;
                        }
                    }
                }
            }
        }

        return _brightnessGrid.Sum(v => v.Value);
    }
}