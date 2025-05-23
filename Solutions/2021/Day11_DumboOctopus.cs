namespace Solutions._2021;

/// <summary>
/// Day 11: <a href="https://adventofcode.com/2021/day/11"/>
/// </summary>
public sealed class Day11DumboOctopus() : Day(2021, 11, "Dumbo Octopus")
{
    private int _flashTally, _flashesAfter100, _totalTurns;
    private int[][]? _octopusField;

    public override void ProcessInput()
    {
        _octopusField = Input.Select(line => line.Select(c => int.Parse($"{c}")).ToArray()).ToArray();

        while (true)
        {
            _totalTurns++;

            // increment all octopuses
            for (var row = 0; row < _octopusField.Length; row++)
            for (var col = 0; col < _octopusField[row].Length; col++)
                _octopusField[row][col]++;

            // flash any that exceeded 10
            for (var row = 0; row < _octopusField.Length; row++)
            for (var col = 0; col < _octopusField[row].Length; col++)
                if (_octopusField[row][col] == 10)
                    FlashAt(row, col);

            var done = true;
            for (var row = 0; row < _octopusField.Length; row++)
            for (var col = 0; col < _octopusField[row].Length; col++)
                if (_octopusField[row][col] == -1)
                    _octopusField[row][col] = 0;
                else
                    done = false;

            if (_totalTurns == 100) _flashesAfter100 = _flashTally;
            if (done) break;
        }
    }

    private void FlashAt(int r, int c)
    {
        _flashTally++;
        _octopusField![r][c] = -1;
        foreach (var rr in new[] { -1, 0, 1 }.Select(dr => dr + r))
        foreach (var cc in new[] { -1, 0, 1 }.Select(dc => dc + c))
            if (0 <= rr && rr < _octopusField.Length && 0 <= cc && cc < _octopusField[0].Length &&
                _octopusField[rr][cc] != -1)
            {
                _octopusField[rr][cc]++;
                if (_octopusField[rr][cc] >= 10)
                    FlashAt(rr, cc);
            }
    }

    public override object Part1() => _flashesAfter100;

    public override object Part2() => _totalTurns;
}
