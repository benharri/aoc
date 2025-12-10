using Solutions._2019;
// ReSharper disable MemberCanBeMadeStatic.Global

namespace Tests;

public class Test2019
{
    [Test]
    [RealInputRequired]
    [Arguments(typeof(Day01TheTyrannyOfTheRocketEquation), "3394106", "5088280")]
    [Arguments(typeof(Day02_1202ProgramAlarm), "3085697", "9425")]
    [Arguments(typeof(Day03CrossedWires), "1195", "91518")]
    [Arguments(typeof(Day04SecureContainer), "1079", "699")]
    [Arguments(typeof(Day05SunnyWithAChanceOfAsteroids), "7692125", "14340395")]
    [Arguments(typeof(Day06UniversalOrbitMap), "145250", "274")]
    [Arguments(typeof(Day07AmplificationCircuit), "19650", "35961106")]
    [Arguments(typeof(Day08SpaceImageFormat), "2413",
        """
        xxx   xx  xxx  xxxx xxx
        x  x x  x x  x    x x  x
        xxx  x    x  x   x  xxx
        x  x x    xxx   x   x  x
        x  x x  x x    x    x  x
        xxx   xx  x    xxxx xxx
        """)]
    [Arguments(typeof(Day09SensorBoost), "3409270027", "82760")]
    [Arguments(typeof(Day10MonitoringStation), "260", "608")]
    [Arguments(typeof(Day11SpacePolice), "2054",
        """
         #  # ###  #### ####  ##    ## #  # ###    
         # #  #  #    # #    #  #    # #  # #  #   
         ##   #  #   #  ###  #  #    # #### ###    
         # #  ###   #   #    ####    # #  # #  #   
         # #  # #  #    #    #  # #  # #  # #  #   
         #  # #  # #### #### #  #  ##  #  # ###    
        """)]
    [Arguments(typeof(Day12TheNBodyProblem), "10635", "583523031727256")]
    [Arguments(typeof(Day13CarePackage), "361", "after 7133 moves, the score is: 17590")]
    [Arguments(typeof(Day14SpaceStoichiometry), "397771", "3126714")]
    [Arguments(typeof(Day15OxygenSystem), "280", "400")]
    [Arguments(typeof(Day16FlawedFrequencyTransmission), "90744714", "82994322")]
    [Arguments(typeof(Day17SetAndForget), "2804", "")]
    [Arguments(typeof(Day19TractorBeam), "114", "10671712")]
    [Arguments(typeof(Day23CategorySix), "23626", "19019")]
    public async Task CheckAllDays(Type dayType, string part1, string part2) =>
        await Common.CheckDay(dayType, part1, part2);
}
