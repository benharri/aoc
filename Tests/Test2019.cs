using Solutions._2019;

namespace Tests;

[TestClass]
public class Test2019
{
    [DataTestMethod]
    [DataRow(typeof(Day01TheTyrannyOfTheRocketEquation), "3394106", "5088280")]
    [DataRow(typeof(Day02_1202ProgramAlarm), "3085697", "9425")]
    [DataRow(typeof(Day03CrossedWires), "1195", "91518")]
    [DataRow(typeof(Day04SecureContainer), "1079", "699")]
    [DataRow(typeof(Day05SunnyWithAChanceOfAsteroids), "7692125", "14340395")]
    [DataRow(typeof(Day06UniversalOrbitMap), "145250", "274")]
    [DataRow(typeof(Day07AmplificationCircuit), "19650", "35961106")]
    [DataRow(typeof(Day08SpaceImageFormat), "2413",
        """
        xxx   xx  xxx  xxxx xxx
        x  x x  x x  x    x x  x
        xxx  x    x  x   x  xxx
        x  x x    xxx   x   x  x
        x  x x  x x    x    x  x
        xxx   xx  x    xxxx xxx
        """)]
    [DataRow(typeof(Day09SensorBoost), "3409270027", "82760")]
    [DataRow(typeof(Day10MonitoringStation), "260", "608")]
    [DataRow(typeof(Day11SpacePolice), "2054",
        """
         #  # ###  #### ####  ##    ## #  # ###    
         # #  #  #    # #    #  #    # #  # #  #   
         ##   #  #   #  ###  #  #    # #### ###    
         # #  ###   #   #    ####    # #  # #  #   
         # #  # #  #    #    #  # #  # #  # #  #   
         #  # #  # #### #### #  #  ##  #  # ###    
        """)]
    [DataRow(typeof(Day12TheNBodyProblem), "10635", "583523031727256")]
    [DataRow(typeof(Day13CarePackage), "361", "after 7133 moves, the score is: 17590")]
    [DataRow(typeof(Day14SpaceStoichiometry), "397771", "3126714")]
    [DataRow(typeof(Day15OxygenSystem), "280", "400")]
    [DataRow(typeof(Day16FlawedFrequencyTransmission), "90744714", "82994322")]
    [DataRow(typeof(Day17SetAndForget), "2804", "")]
    [DataRow(typeof(Day19TractorBeam), "114", "10671712")]
    [DataRow(typeof(Day23CategorySix), "23626", "19019")]
    public void CheckAllDays(Type dayType, string part1, string part2) =>
        Common.CheckDay(dayType, part1, part2);
}
