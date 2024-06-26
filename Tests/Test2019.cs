using Solutions._2019;

namespace Tests;

[TestClass]
public class Test2019
{
    [DataTestMethod]
    [DataRow(typeof(Day01), "3394106", "5088280")]
    [DataRow(typeof(Day02), "3085697", "9425")]
    [DataRow(typeof(Day03), "1195", "91518")]
    [DataRow(typeof(Day04), "1079", "699")]
    [DataRow(typeof(Day05), "7692125", "14340395")]
    [DataRow(typeof(Day06), "145250", "274")]
    [DataRow(typeof(Day07), "19650", "35961106")]
    [DataRow(typeof(Day08), "2413",
        """
        xxx   xx  xxx  xxxx xxx
        x  x x  x x  x    x x  x
        xxx  x    x  x   x  xxx
        x  x x    xxx   x   x  x
        x  x x  x x    x    x  x
        xxx   xx  x    xxxx xxx
        """)]
    [DataRow(typeof(Day09), "3409270027", "82760")]
    [DataRow(typeof(Day10), "260", "608")]
    [DataRow(typeof(Day11), "2054",
        """
         #  # ###  #### ####  ##    ## #  # ###    
         # #  #  #    # #    #  #    # #  # #  #   
         ##   #  #   #  ###  #  #    # #### ###    
         # #  ###   #   #    ####    # #  # #  #   
         # #  # #  #    #    #  # #  # #  # #  #   
         #  # #  # #### #### #  #  ##  #  # ###    
        """)]
    [DataRow(typeof(Day12), "10635", "583523031727256")]
    [DataRow(typeof(Day13), "361", "after 7133 moves, the score is: 17590")]
    [DataRow(typeof(Day14), "397771", "3126714")]
    [DataRow(typeof(Day15), "280", "400")]
    [DataRow(typeof(Day16), "90744714", "82994322")]
    [DataRow(typeof(Day17), "2804", "")]
    //[DataRow(typeof(Day18), "", "")]
    [DataRow(typeof(Day19), "114", "10671712")]
    //[DataRow(typeof(Day20), "", "")]
    //[DataRow(typeof(Day21), "", "")]
    //[DataRow(typeof(Day22), "", "")]
    [DataRow(typeof(Day23), "23626", "19019")]
    //[DataRow(typeof(Day24), "", "")]
    //[DataRow(typeof(Day25), "", "")]
    public void CheckAllDays(Type dayType, string part1, string part2) =>
        Common.CheckDay(dayType, part1, part2);
}
