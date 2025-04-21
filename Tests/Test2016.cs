using Solutions._2016;

namespace Tests;

[TestClass]
public class Test2016
{
    [DataTestMethod]
    [DataRow(typeof(Day01NoTimeForATaxicab), "300", "159")]
    [DataRow(typeof(Day02BathroomSecurity), "76792", "A7AC3")]
    [DataRow(typeof(Day03SquaresWithThreeSides), "993", "1849")]
    [DataRow(typeof(Day04SecurityThroughObscurity), "361724", "482")]
    // [DataRow(typeof(Day05HowAboutANiceGameOfChess), "F77A0E6E", "999828EC")] // TODO: optimize
    [DataRow(typeof(Day06SignalsAndNoise), "gyvwpxaz", "jucfoary")]
    [DataRow(typeof(Day07InternetProtocolVersion7), "105", "258")]
    [DataRow(typeof(Day08TwoFactorAuthentication), "121",
        """

        ███▒▒█▒▒█▒███▒▒█▒▒█▒▒██▒▒████▒▒██▒▒████▒▒███▒█▒▒▒▒
        █▒▒█▒█▒▒█▒█▒▒█▒█▒▒█▒█▒▒█▒█▒▒▒▒█▒▒█▒█▒▒▒▒▒▒█▒▒█▒▒▒▒
        █▒▒█▒█▒▒█▒█▒▒█▒█▒▒█▒█▒▒▒▒███▒▒█▒▒█▒███▒▒▒▒█▒▒█▒▒▒▒
        ███▒▒█▒▒█▒███▒▒█▒▒█▒█▒▒▒▒█▒▒▒▒█▒▒█▒█▒▒▒▒▒▒█▒▒█▒▒▒▒
        █▒█▒▒█▒▒█▒█▒█▒▒█▒▒█▒█▒▒█▒█▒▒▒▒█▒▒█▒█▒▒▒▒▒▒█▒▒█▒▒▒▒
        █▒▒█▒▒██▒▒█▒▒█▒▒██▒▒▒██▒▒████▒▒██▒▒████▒▒███▒████▒

        """)]
    public void CheckAllDays(Type dayType, string part1, string part2) =>
        Common.CheckDay(dayType, part1, part2);

    [DataTestMethod]
    [DataRow(typeof(Day02BathroomSecurity), "1985", "5DB3")]
    //[DataRow(typeof(Day05HowAboutANiceGameOfChess), "18F47A30", "05ACE8E3")]
    [DataRow(typeof(Day06SignalsAndNoise), "easter", "advent")]
    public void CheckTestInputs(Type dayType, string part1, string part2) =>
        Common.CheckDay(dayType, part1, part2, true);
}
