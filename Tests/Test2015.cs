using Solutions._2015;

namespace Tests;

public class Test2015
{
    [Test]
    [Arguments(typeof(Day01NotQuiteLisp), "232", "1783")]
    [Arguments(typeof(Day02IWasToldThereWouldBeNoMath), "1586300", "3737498")]
    [Arguments(typeof(Day03PerfectlySphericalHousesInAVacuum), "2081", "2341")]
    [Arguments(typeof(Day04TheIdealStockingStuffer), "346386", "9958218")]
    [Arguments(typeof(Day05DoesntHeHaveInternElvesForThis), "258", "53")]
    [Arguments(typeof(Day06ProbablyAFireHazard), "543903", "14687245")] // TODO: optimize
    [Arguments(typeof(Day07SomeAssemblyRequired), "3176", "14710")]
    [Arguments(typeof(Day08Matchsticks), "1342", "2074")]
    [Arguments(typeof(Day09AllInASingleNight), "117", "909")]
    [Arguments(typeof(Day10ElvesLookElvesSay), "492982", "6989950")]
    [Arguments(typeof(Day11CorporatePolicy), "hepxxyzz", "heqaabcc")]
    [Arguments(typeof(Day12JsAbacusFrameworkio), "111754", "65402")]
    [Arguments(typeof(Day13KnightsOfTheDinnerTable), "733", "725")]
    [Arguments(typeof(Day14ReindeerOlympics), "2655", "1059")]
    [Arguments(typeof(Day15ScienceForHungryPeople), "222870", "117936")]
    [Arguments(typeof(Day16AuntSue), "103", "405")]
    [Arguments(typeof(Day17NoSuchThingAsTooMuch), "1304", "18")]
    [Arguments(typeof(Day18LikeAGifForYourYard), "1061", "1006")]
    [Arguments(typeof(Day19MedicineForRudolph), "576", "207")]
    [Arguments(typeof(Day20InfiniteElvesAndInfiniteHouses), "665280", "705600")]
    [Arguments(typeof(Day21RpgSimulator20Xx), "78", "148")]
    [Arguments(typeof(Day22WizardSimulator20Xx), "", "")]
    [Arguments(typeof(Day23OpeningTheTuringLock), "255", "334")]
    [Arguments(typeof(Day25LetItSnow), "9132360", "")]
    public void CheckAllDays(Type dayType, string part1, string part2) =>
        _ = Common.CheckDay(dayType, part1, part2);

    [Test]
    [Arguments(typeof(Day01NotQuiteLisp), "-1", "5")]
    [Arguments(typeof(Day02IWasToldThereWouldBeNoMath), "58", "34")]
    [Arguments(typeof(Day03PerfectlySphericalHousesInAVacuum), "2", "11")]
    // [Arguments(typeof(Day04TheIdealStockingStuffer), "609043", "6742839")]
    [Arguments(typeof(Day05DoesntHeHaveInternElvesForThis), "1", "1")]
    [Arguments(typeof(Day06ProbablyAFireHazard), "1000000", "1000000")]
    // [Arguments(typeof(Day07SomeAssemblyRequired), "", "")] // test input doesn't have "a" wire
    [Arguments(typeof(Day08Matchsticks), "12", "19")]
    [Arguments(typeof(Day09AllInASingleNight), "605", "982")]
    [Arguments(typeof(Day10ElvesLookElvesSay), "237746", "3369156")]
    [Arguments(typeof(Day13KnightsOfTheDinnerTable), "330", "286")]
    [Arguments(typeof(Day15ScienceForHungryPeople), "62842880", "57600000")]
    [Arguments(typeof(Day19MedicineForRudolph), "4", "2")]
    public void CheckTestInputs(Type dayType, string part1, string part2) =>
        _ = Common.CheckDay(dayType, part1, part2, true);
}
