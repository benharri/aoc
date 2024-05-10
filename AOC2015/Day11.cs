namespace AOC2015;

/// <summary>
/// Day 11: <a href="https://adventofcode.com/2015/day/11"/>
/// </summary>
public sealed class Day11() : Day(2015, 11, "Corporate Policy")
{
    private char[]? _password;

    public override void ProcessInput() => _password = Input.First().ToCharArray();

    public override object Part1()
    {
        while (!IsValid(ref _password!)) Increment(ref _password);

        return new string(_password);
    }

    public override object Part2()
    {
        Increment(ref _password!);
        while (!IsValid(ref _password)) Increment(ref _password);

        return new string(_password);
    }

    private static bool IsValid(ref char[] password)
    {
        bool check1 = false, check3 = false;
        for (var j = 2; j < password.Length; j++)
        {
            if (password[j] == 'i' || password[j] == 'o' || password[j] == 'l')
                return false;

            if (password[j - 2] + 1 == password[j - 1] && password[j - 1] + 1 == password[j])
                check1 = true;

            if (j <= 2) continue;

            for (var k = 0; k + 2 < j; k++)
                if (password[j - 3 - k] == password[j - 2 - k]
                    && password[j - 1] == password[j]
                    && password[j - 2 - k] != password[j - 1])
                {
                    check3 = true;
                }
        }

        return check1 && check3;
    }

    private static void Increment(ref char[] password, int at = -1)
    {
        while (true)
        {
            if (at == -1) at = password.Length - 1;

            password[at]++;
            if (password[at] == 'i' || password[at] == 'o' || password[at] == 'l') password[at]++;
            if (password[at] <= 'z') return;
            password[at] = 'a';
            at--;
        }
    }
}
