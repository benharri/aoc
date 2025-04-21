using Solutions._2015;

namespace Tests;

[TestClass]
public class Test2015
{
    [DataTestMethod]
    [DataRow(typeof(Day01NotQuiteLisp), "232", "1783")]
    [DataRow(typeof(Day02IWasToldThereWouldBeNoMath), "1586300", "3737498")]
    [DataRow(typeof(Day03PerfectlySphericalHousesInAVacuum), "2081", "2341")]
    [DataRow(typeof(Day04TheIdealStockingStuffer), "346386", "9958218")]
    [DataRow(typeof(Day05DoesntHeHaveInternElvesForThis), "258", "53")]
    [DataRow(typeof(Day06ProbablyAFireHazard), "543903", "14687245")] // TODO: optimize
    [DataRow(typeof(Day07SomeAssemblyRequired), "3176", "14710")]
    [DataRow(typeof(Day08Matchsticks), "1342", "2074")]
    [DataRow(typeof(Day09AllInASingleNight), "117", "909")]
    [DataRow(typeof(Day10ElvesLookElvesSay), "492982", "6989950")]
    [DataRow(typeof(Day11CorporatePolicy), "hepxxyzz", "heqaabcc")]
    [DataRow(typeof(Day12JsAbacusFrameworkio), "111754", "65402")]
    [DataRow(typeof(Day13KnightsOfTheDinnerTable), "733", "725")]
    [DataRow(typeof(Day14ReindeerOlympics), "2655", "1059")]
    [DataRow(typeof(Day15ScienceForHungryPeople), "222870", "117936")]
    [DataRow(typeof(Day16AuntSue), "103", "405")]
    [DataRow(typeof(Day17NoSuchThingAsTooMuch), "1304", "18")]
    [DataRow(typeof(Day18LikeAGifForYourYard), "1061", "1006")]
    [DataRow(typeof(Day19MedicineForRudolph), "576", "207")]
    [DataRow(typeof(Day20InfiniteElvesAndInfiniteHouses), "665280", "705600")]
    [DataRow(typeof(Day21RpgSimulator20Xx), "78", "148")]
    [DataRow(typeof(Day22WizardSimulator20Xx), "", "")]
    [DataRow(typeof(Day23OpeningTheTuringLock), "255", "334")]
    [DataRow(typeof(Day25LetItSnow), "9132360", "")]
    public void CheckAllDays(Type dayType, string part1, string part2) =>
        Common.CheckDay(dayType, part1, part2);

    [DataTestMethod]
    [DataRow(typeof(Day01NotQuiteLisp), "-1", "5")]
    [DataRow(typeof(Day02IWasToldThereWouldBeNoMath), "58", "34")]
    [DataRow(typeof(Day03PerfectlySphericalHousesInAVacuum), "2", "11")]
    // [DataRow(typeof(Day04TheIdealStockingStuffer), "609043", "6742839")]
    [DataRow(typeof(Day05DoesntHeHaveInternElvesForThis), "1", "1")]
    [DataRow(typeof(Day06ProbablyAFireHazard), "1000000", "1000000")]
    // [DataRow(typeof(Day07SomeAssemblyRequired), "", "")] // test input doesn't have "a" wire
    [DataRow(typeof(Day08Matchsticks), "12", "19")]
    [DataRow(typeof(Day09AllInASingleNight), "605", "982")]
    [DataRow(typeof(Day10ElvesLookElvesSay), "237746", "3369156")]
    [DataRow(typeof(Day13KnightsOfTheDinnerTable), "330", "286")]
    [DataRow(typeof(Day15ScienceForHungryPeople), "62842880", "57600000")]
    [DataRow(typeof(Day19MedicineForRudolph), "4", "2")]
    public void CheckTestInputs(Type dayType, string part1, string part2) =>
        Common.CheckDay(dayType, part1, part2, true);
}
