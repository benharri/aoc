using Solutions._2016;
// ReSharper disable MemberCanBeMadeStatic.Global

namespace Tests;

public class Test2016
{
    [Test]
    [Arguments(typeof(Day01NoTimeForATaxicab), "300", "159")]
    [Arguments(typeof(Day02BathroomSecurity), "76792", "A7AC3")]
    [Arguments(typeof(Day03SquaresWithThreeSides), "993", "1849")]
    [Arguments(typeof(Day04SecurityThroughObscurity), "361724", "482")]
    // [Arguments(typeof(Day05HowAboutANiceGameOfChess), "F77A0E6E", "999828EC")] // TODO: optimize
    [Arguments(typeof(Day06SignalsAndNoise), "gyvwpxaz", "jucfoary")]
    [Arguments(typeof(Day07InternetProtocolVersion7), "105", "258")]
    [Arguments(typeof(Day08TwoFactorAuthentication), "121",
        """

        ███▒▒█▒▒█▒███▒▒█▒▒█▒▒██▒▒████▒▒██▒▒████▒▒███▒█▒▒▒▒
        █▒▒█▒█▒▒█▒█▒▒█▒█▒▒█▒█▒▒█▒█▒▒▒▒█▒▒█▒█▒▒▒▒▒▒█▒▒█▒▒▒▒
        █▒▒█▒█▒▒█▒█▒▒█▒█▒▒█▒█▒▒▒▒███▒▒█▒▒█▒███▒▒▒▒█▒▒█▒▒▒▒
        ███▒▒█▒▒█▒███▒▒█▒▒█▒█▒▒▒▒█▒▒▒▒█▒▒█▒█▒▒▒▒▒▒█▒▒█▒▒▒▒
        █▒█▒▒█▒▒█▒█▒█▒▒█▒▒█▒█▒▒█▒█▒▒▒▒█▒▒█▒█▒▒▒▒▒▒█▒▒█▒▒▒▒
        █▒▒█▒▒██▒▒█▒▒█▒▒██▒▒▒██▒▒████▒▒██▒▒████▒▒███▒████▒

        """)]
    public async Task CheckAllDays(Type dayType, string part1, string part2) =>
        await Common.CheckDay(dayType, part1, part2);

    [Test]
    [Arguments(typeof(Day02BathroomSecurity), "1985", "5DB3")]
    //[Arguments(typeof(Day05HowAboutANiceGameOfChess), "18F47A30", "05ACE8E3")]
    [Arguments(typeof(Day06SignalsAndNoise), "easter", "advent")]
    public async Task CheckTestInputs(Type dayType, string part1, string part2) =>
        await Common.CheckDay(dayType, part1, part2, true);
}
