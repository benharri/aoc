using Solutions;
using Solutions._2015;
using Solutions._2016;
using Solutions._2018;
using Solutions._2019;
using Solutions._2020;
using Solutions._2021;
using Solutions._2022;
using Solutions._2023;
using Solutions._2024;
using Solutions._2025;
using System.Collections.Generic;

namespace Tests;

using DataFunc = Func<TestDataRow<(Day Day, string Part1, string Part2)>>;

public class DayData
{
    private static DataFunc Row(Day day, string part1, string part2) =>
        () => new((day, part1, part2), DisplayName: $"$arg1{(day.UseTestInput ? " Test Input" : "")}: $arg2 $arg3");

    public static IEnumerable<DataFunc> GetData()
    {
        // 2015
        yield return Row(new Day01NotQuiteLisp(), "232", "1783");
        yield return Row(new Day01NotQuiteLisp { UseTestInput = true }, "-1", "5");
        yield return Row(new Day02IWasToldThereWouldBeNoMath(), "1586300", "3737498");
        yield return Row(new Day02IWasToldThereWouldBeNoMath { UseTestInput = true }, "58", "34");
        yield return Row(new Day03PerfectlySphericalHousesInAVacuum(), "2081", "2341");
        yield return Row(new Day03PerfectlySphericalHousesInAVacuum { UseTestInput = true }, "2", "11");
        yield return Row(new Day04TheIdealStockingStuffer(), "346386", "9958218");
        // yield return Row(new Day04TheIdealStockingStuffer { UseTestInput = true }, "609043", "6742839"); // test input changes for p2
        yield return Row(new Day05DoesntHeHaveInternElvesForThis(), "258", "53");
        yield return Row(new Day05DoesntHeHaveInternElvesForThis { UseTestInput = true }, "1", "1");
        // yield return Row(new Day06ProbablyAFireHazard(), "543903", "14687245"); // TODO: optimize
        yield return Row(new Day06ProbablyAFireHazard { UseTestInput = true }, "1000000", "1000000");
        yield return Row(new Day07SomeAssemblyRequired(), "3176", "14710");
        // yield return Row(new Day07SomeAssemblyRequired { UseTestInput = true }, "", ""); // test input doesn't have "a" wire
        yield return Row(new Day08Matchsticks(), "1342", "2074");
        yield return Row(new Day08Matchsticks { UseTestInput = true }, "12", "19");
        yield return Row(new Day09AllInASingleNight(), "117", "909");
        yield return Row(new Day09AllInASingleNight { UseTestInput = true }, "605", "982");
        yield return Row(new Day10ElvesLookElvesSay(), "492982", "6989950");
        yield return Row(new Day10ElvesLookElvesSay { UseTestInput = true }, "237746", "3369156");
        yield return Row(new Day11CorporatePolicy(), "hepxxyzz", "heqaabcc");
        yield return Row(new Day12JsAbacusFrameworkio(), "111754", "65402");
        yield return Row(new Day13KnightsOfTheDinnerTable(), "733", "725");
        yield return Row(new Day13KnightsOfTheDinnerTable { UseTestInput = true }, "330", "286");
        yield return Row(new Day14ReindeerOlympics(), "2655", "1059");
        yield return Row(new Day15ScienceForHungryPeople(), "222870", "117936");
        yield return Row(new Day15ScienceForHungryPeople { UseTestInput = true }, "62842880", "57600000");
        yield return Row(new Day16AuntSue(), "103", "405");
        yield return Row(new Day17NoSuchThingAsTooMuch(), "1304", "18");
        yield return Row(new Day18LikeAGifForYourYard(), "1061", "1006");
        yield return Row(new Day19MedicineForRudolph(), "576", "207");
        yield return Row(new Day19MedicineForRudolph { UseTestInput = true }, "4", "2");
        yield return Row(new Day20InfiniteElvesAndInfiniteHouses(), "665280", "705600");
        yield return Row(new Day21RpgSimulator20Xx(), "78", "148");
        yield return Row(new Day22WizardSimulator20Xx(), "", "");
        yield return Row(new Day23OpeningTheTuringLock(), "255", "334");
        yield return Row(new Day25LetItSnow(), "9132360", "");
        // 2016
        yield return Row(new Day01NoTimeForATaxicab(), "300", "159");
        yield return Row(new Day02BathroomSecurity(), "76792", "A7AC3");
        yield return Row(new Day02BathroomSecurity { UseTestInput = true }, "1985", "5DB3");
        yield return Row(new Day03SquaresWithThreeSides(), "993", "1849");
        yield return Row(new Day04SecurityThroughObscurity(), "361724", "482");
        yield return Row(new Day05HowAboutANiceGameOfChess(), "F77A0E6E", "999828EC"); // slow
        yield return Row(new Day05HowAboutANiceGameOfChess { UseTestInput = true }, "18F47A30", "05ACE8E3"); // slow
        yield return Row(new Day06SignalsAndNoise(), "gyvwpxaz", "jucfoary");
        yield return Row(new Day06SignalsAndNoise { UseTestInput = true }, "easter", "advent");
        yield return Row(new Day07InternetProtocolVersion7(), "105", "258");
        yield return Row(new Day08TwoFactorAuthentication(), "121",
            """

            ███▒▒█▒▒█▒███▒▒█▒▒█▒▒██▒▒████▒▒██▒▒████▒▒███▒█▒▒▒▒
            █▒▒█▒█▒▒█▒█▒▒█▒█▒▒█▒█▒▒█▒█▒▒▒▒█▒▒█▒█▒▒▒▒▒▒█▒▒█▒▒▒▒
            █▒▒█▒█▒▒█▒█▒▒█▒█▒▒█▒█▒▒▒▒███▒▒█▒▒█▒███▒▒▒▒█▒▒█▒▒▒▒
            ███▒▒█▒▒█▒███▒▒█▒▒█▒█▒▒▒▒█▒▒▒▒█▒▒█▒█▒▒▒▒▒▒█▒▒█▒▒▒▒
            █▒█▒▒█▒▒█▒█▒█▒▒█▒▒█▒█▒▒█▒█▒▒▒▒█▒▒█▒█▒▒▒▒▒▒█▒▒█▒▒▒▒
            █▒▒█▒▒██▒▒█▒▒█▒▒██▒▒▒██▒▒████▒▒██▒▒████▒▒███▒████▒

            """);
        // 2018
        yield return Row(new Day01ChronalCalibration(), "582", "488");
        yield return Row(new Day02InventoryManagementSystem(), "5166", "cypueihajytordkgzxfqplbwn");
        yield return Row(new Day03NoMatterHowYouSliceIt(), "119551", "1124");
        // 2019
        yield return Row(new Day01TheTyrannyOfTheRocketEquation(), "3394106", "5088280");
        yield return Row(new Day02_1202ProgramAlarm(), "3085697", "9425");
        yield return Row(new Day03CrossedWires(), "1195", "91518");
        yield return Row(new Day04SecureContainer(), "1079", "699");
        yield return Row(new Day05SunnyWithAChanceOfAsteroids(), "7692125", "14340395");
        yield return Row(new Day06UniversalOrbitMap(), "145250", "274");
        yield return Row(new Day07AmplificationCircuit(), "19650", "35961106");
        yield return Row(new Day08SpaceImageFormat(), "2413",
            """
            xxx   xx  xxx  xxxx xxx
            x  x x  x x  x    x x  x
            xxx  x    x  x   x  xxx
            x  x x    xxx   x   x  x
            x  x x  x x    x    x  x
            xxx   xx  x    xxxx xxx
            """);
        yield return Row(new Day09SensorBoost(), "3409270027", "82760");
        yield return Row(new Day10MonitoringStation(), "260", "608");
        yield return Row(new Day11SpacePolice(), "2054",
            """
             #  # ###  #### ####  ##    ## #  # ###    
             # #  #  #    # #    #  #    # #  # #  #   
             ##   #  #   #  ###  #  #    # #### ###    
             # #  ###   #   #    ####    # #  # #  #   
             # #  # #  #    #    #  # #  # #  # #  #   
             #  # #  # #### #### #  #  ##  #  # ###    
            """);
        yield return Row(new Day12TheNBodyProblem(), "10635", "583523031727256");
        yield return Row(new Day13CarePackage(), "361", "after 7133 moves, the score is: 17590");
        yield return Row(new Day14SpaceStoichiometry(), "397771", "3126714");
        yield return Row(new Day15OxygenSystem(), "280", "400");
        yield return Row(new Day16FlawedFrequencyTransmission(), "90744714", "82994322");
        yield return Row(new Day17SetAndForget(), "2804", "");
        yield return Row(new Day19TractorBeam(), "114", "10671712");
        yield return Row(new Day23CategorySix(), "23626", "19019");
        // 2020
        yield return Row(new Day01ReportRepair(), "751776", "42275090");
        yield return Row(new Day02PasswordPhilosophy(), "556", "605");
        yield return Row(new Day03TobogganTrajectory(), "189", "1718180100");
        yield return Row(new Day04PassportProcessing(), "247", "145");
        yield return Row(new Day05BinaryBoarding(), "878", "504");
        yield return Row(new Day06CustomCustoms(), "6273", "3254");
        yield return Row(new Day07HandyHaversacks(), "169", "82372");
        yield return Row(new Day08HandheldHalting(), "1654", "833");
        yield return Row(new Day09EncodingError(), "138879426", "23761694");
        yield return Row(new Day10AdapterArray(), "1980", "4628074479616");
        yield return Row(new Day11SeatingSystem(), "2303", "2057");
        yield return Row(new Day12RainRisk(), "1710", "62045");
        yield return Row(new Day13ShuttleSearch(), "171", "539746751134958");
        yield return Row(new Day14DockingData(), "17481577045893", "4160009892257");
        yield return Row(new Day15RambunctiousRecitation(), "257", "8546398");
        yield return Row(new Day16TicketTranslation(), "19093", "5311123569883");
        // yield return Row(new Day17ConwayCubes(), "293", "1816"); // this one takes too long and i don't want to bother optimizing it
        yield return Row(new Day18OperationOrder(), "12918250417632", "171259538712010");
        yield return Row(new Day19MonsterMessages(), "160", "357");
        yield return Row(new Day20JurassicJigsaw(), "21599955909991", "2495");
        yield return Row(new Day21AllergenAssessment(), "2436", "dhfng,pgblcd,xhkdc,ghlzj,dstct,nqbnmzx,ntggc,znrzgs");
        yield return Row(new Day22CrabCombat(), "32856", "33805");
        yield return Row(new Day23CrabCups(), "36542897", "562136730660");
        yield return Row(new Day24LobbyLayout(), "282", "3445");
        yield return Row(new Day25ComboBreaker(), "11707042", "");
        // 2021
        yield return Row(new Day01SonarSweep(), "1616", "1645");
        yield return Row(new Day01SonarSweep { UseTestInput = true }, "7", "5");
        yield return Row(new Day02Dive(), "2272262", "2134882034");
        yield return Row(new Day02Dive { UseTestInput = true }, "150", "900");
        yield return Row(new Day03BinaryDiagnostic(), "3009600", "6940518");
        yield return Row(new Day03BinaryDiagnostic { UseTestInput = true }, "198", "230");
        yield return Row(new Day04GiantSquid(), "8580", "9576");
        yield return Row(new Day04GiantSquid { UseTestInput = true }, "4512", "1924");
        yield return Row(new Day05HydrothermalVenture(), "7318", "19939");
        yield return Row(new Day05HydrothermalVenture { UseTestInput = true }, "5", "12");
        yield return Row(new Day06Lanternfish(), "362740", "1644874076764");
        yield return Row(new Day06Lanternfish { UseTestInput = true }, "5934", "26984457539");
        yield return Row(new Day07TheTreacheryOfWhales(), "345035", "97038163");
        yield return Row(new Day07TheTreacheryOfWhales { UseTestInput = true }, "37", "168");
        yield return Row(new Day08SevenSegmentSearch(), "362", "1020159");
        yield return Row(new Day08SevenSegmentSearch { UseTestInput = true }, "26", "61229");
        yield return Row(new Day09SmokeBasin(), "478", "1327014");
        yield return Row(new Day09SmokeBasin { UseTestInput = true }, "15", "1134");
        yield return Row(new Day10SyntaxScoring(), "288291", "820045242");
        yield return Row(new Day10SyntaxScoring { UseTestInput = true }, "26397", "288957");
        yield return Row(new Day11DumboOctopus(), "1613", "510");
        yield return Row(new Day11DumboOctopus { UseTestInput = true }, "1656", "195");
        yield return Row(new Day12PassagePathing(), "4549", "120535");
        yield return Row(new Day12PassagePathing { UseTestInput = true }, "226", "3509");
        yield return Row(new Day13TransparentOrigami(), "837",
            """
            ████▒███▒▒████▒▒██▒▒█▒▒█▒▒██▒▒█▒▒█▒█▒▒█
            █▒▒▒▒█▒▒█▒▒▒▒█▒█▒▒█▒█▒█▒▒█▒▒█▒█▒▒█▒█▒▒█
            ███▒▒█▒▒█▒▒▒█▒▒█▒▒▒▒██▒▒▒█▒▒▒▒████▒█▒▒█
            █▒▒▒▒███▒▒▒█▒▒▒█▒██▒█▒█▒▒█▒▒▒▒█▒▒█▒█▒▒█
            █▒▒▒▒█▒▒▒▒█▒▒▒▒█▒▒█▒█▒█▒▒█▒▒█▒█▒▒█▒█▒▒█
            ████▒█▒▒▒▒████▒▒███▒█▒▒█▒▒██▒▒█▒▒█▒▒██▒
            """);
        yield return Row(new Day13TransparentOrigami { UseTestInput = true }, "17",
            """
            █████
            █▒▒▒█
            █▒▒▒█
            █▒▒▒█
            █████
            """);
        yield return Row(new Day14ExtendedPolymerization(), "5656", "12271437788530");
        yield return Row(new Day14ExtendedPolymerization { UseTestInput = true }, "1588", "2188189693529");
        yield return Row(new Day15Chiton(), "702", "2955");
        yield return Row(new Day15Chiton { UseTestInput = true }, "40", "315");
        yield return Row(new Day16PacketDecoder(), "852", "19348959966392");
        yield return Row(new Day16PacketDecoder { UseTestInput = true }, "16", "15");
        yield return Row(new Day17TrickShot(), "12090", "5059");
        yield return Row(new Day17TrickShot { UseTestInput = true }, "45", "112");
        yield return Row(new Day18Snailfish(), "4289", "4807");
        yield return Row(new Day18Snailfish { UseTestInput = true }, "4140", "3993");
        // yield return Row(new Day19BeaconScanner(), "338", "9862"); // takes too long and i don't feel like optimizing
        yield return Row(new Day19BeaconScanner { UseTestInput = true }, "79", "3621");
        yield return Row(new Day20TrenchMap(), "5306", "17497");
        yield return Row(new Day20TrenchMap { UseTestInput = true }, "35", "3351");
        yield return Row(new Day21DiracDice(), "512442", "346642902541848");
        yield return Row(new Day21DiracDice { UseTestInput = true }, "739785", "444356092776315");
        yield return Row(new Day22ReactorReboot(), "658691", "1228699515783640");
        yield return Row(new Day22ReactorReboot { UseTestInput = true }, "590784", "39769202357779");
        yield return Row(new Day23Amphipod(), "15365", "52055");
        yield return Row(new Day23Amphipod { UseTestInput = true }, "12521", "44169");
        yield return Row(new Day24ArithmeticLogicUnit(), "99299513899971", "93185111127911");
        yield return Row(new Day25SeaCucumber(), "417", "");
        yield return Row(new Day25SeaCucumber { UseTestInput = true }, "58", "");
        yield return Row(new Day01CalorieCounting(), "70509", "208567");
        yield return Row(new Day01CalorieCounting { UseTestInput = true }, "24000", "45000");
        yield return Row(new Day02RockPaperScissors(), "11449", "13187");
        yield return Row(new Day02RockPaperScissors { UseTestInput = true }, "15", "12");
        yield return Row(new Day03RucksackReorganization(), "7917", "2585");
        yield return Row(new Day03RucksackReorganization { UseTestInput = true }, "157", "70");
        yield return Row(new Day04CampCleanup(), "503", "827");
        yield return Row(new Day04CampCleanup { UseTestInput = true }, "2", "4");
        yield return Row(new Day05SupplyStacks(), "TGWSMRBPN", "TZLTLWRNF");
        yield return Row(new Day05SupplyStacks { UseTestInput = true }, "CMZ", "MCD");
        yield return Row(new Day06TuningTrouble(), "1356", "2564");
        yield return Row(new Day06TuningTrouble { UseTestInput = true }, "7", "19");
        yield return Row(new Day07NoSpaceLeftOnDevice(), "919137", "2877389");
        yield return Row(new Day07NoSpaceLeftOnDevice { UseTestInput = true }, "95437", "24933642");
        yield return Row(new Day08TreetopTreeHouse(), "1776", "234416");
        yield return Row(new Day08TreetopTreeHouse { UseTestInput = true }, "21", "8");
        yield return Row(new Day09RopeBridge(), "6406", "2643");
        yield return Row(new Day09RopeBridge { UseTestInput = true }, "88", "36");
        yield return Row(new Day10CathodeRayTube(), "14220",
            """
             ████ ███   ██  ███  █    ████ ████ █  █
                █ █  █ █  █ █  █ █    █       █ █  █
               █  █  █ █  █ █  █ █    ███    █  █  █
              █   ███  ████ ███  █    █     █   █  █
             █    █ █  █  █ █ █  █    █    █    █  █
             ████ █  █ █  █ █  █ ████ █    ████  ██ 
            """);
        yield return Row(new Day10CathodeRayTube { UseTestInput = true }, "13140",
            """
             ██  ██  ██  ██  ██  ██  ██  ██  ██  ██ 
             ███   ███   ███   ███   ███   ███   ███
             ████    ████    ████    ████    ████   
             █████     █████     █████     █████    
             ██████      ██████      ██████      ███
            ████████       ███████       ███████    
            """);
        yield return Row(new Day11MonkeyInTheMiddle(), "61503", "14081365540");
        yield return Row(new Day11MonkeyInTheMiddle { UseTestInput = true }, "10605", "2713310158");
        yield return Row(new Day12HillClimbingAlgorithm(), "352", "345");
        yield return Row(new Day12HillClimbingAlgorithm { UseTestInput = true }, "31", "29");
        yield return Row(new Day13DistressSignal(), "5682", "20304");
        yield return Row(new Day13DistressSignal { UseTestInput = true }, "13", "140");
        yield return Row(new Day14RegolithReservoir(), "674", "24958");
        yield return Row(new Day14RegolithReservoir { UseTestInput = true }, "24", "93");
        yield return Row(new Day15BeaconExclusionZone(), "4724228", "13622251246513");
        yield return Row(new Day15BeaconExclusionZone { UseTestInput = true }, "26", "56000011");
        // 2023
        yield return Row(new Day01Trebuchet(), "54331", "54518");
        yield return Row(new Day01Trebuchet { UseTestInput = true }, "142", "142");
        yield return Row(new Day02CubeConundrum(), "2476", "54911");
        yield return Row(new Day02CubeConundrum { UseTestInput = true }, "8", "2286");
        yield return Row(new Day03GearRatios(), "522726", "81721933");
        yield return Row(new Day03GearRatios { UseTestInput = true }, "4361", "467835");
        yield return Row(new Day04Scratchcards(), "20117", "13768818");
        yield return Row(new Day04Scratchcards { UseTestInput = true }, "13", "30");
        yield return Row(new Day06WaitForIt(), "505494", "23632299");
        yield return Row(new Day06WaitForIt { UseTestInput = true }, "288", "71503");
        yield return Row(new Day07CamelCards(), "250370104", "251735672");
        yield return Row(new Day07CamelCards { UseTestInput = true }, "6440", "5905");
        // 2024
        yield return Row(new Day01HistorianHysteria(), "1319616", "27267728");
        yield return Row(new Day01HistorianHysteria { UseTestInput = true }, "11", "31");
        yield return Row(new Day02RedNosedReports(), "321", "386");
        yield return Row(new Day02RedNosedReports { UseTestInput = true }, "2", "4");
        yield return Row(new Day03MullItOver(), "163931492", "76911921");
        yield return Row(new Day03MullItOver { UseTestInput = true }, "161", "48");
        yield return Row(new Day04CeresSearch(), "2573", "1850");
        yield return Row(new Day04CeresSearch { UseTestInput = true }, "18", "9");
        yield return Row(new Day05PrintQueue(), "4637", "");
        yield return Row(new Day05PrintQueue { UseTestInput = true }, "143", "");
        // 2025
        yield return Row(new Day01SecretEntrance(), "1105", "6599");
        yield return Row(new Day01SecretEntrance { UseTestInput = true }, "3", "6");
        yield return Row(new Day02GiftShop(), "20223751480", "30260171216");
        yield return Row(new Day02GiftShop { UseTestInput = true }, "1227775554", "4174379265");
        yield return Row(new Day03Lobby(), "17155", "169685670469164");
        yield return Row(new Day03Lobby { UseTestInput = true }, "357", "3121910778619");
        yield return Row(new Day04PrintingDepartment(), "1419", "8739");
        yield return Row(new Day04PrintingDepartment { UseTestInput = true }, "13", "43");
        yield return Row(new Day05Cafeteria(), "756", "355555479253787");
        yield return Row(new Day05Cafeteria { UseTestInput = true }, "3", "14");
        yield return Row(new Day06TrashCompactor(), "6757749566978", "10603075273949");
        yield return Row(new Day06TrashCompactor { UseTestInput = true }, "4277556", "3263827");
        yield return Row(new Day07Laboratories(), "1642", "47274292756692");
        yield return Row(new Day07Laboratories { UseTestInput = true }, "21", "40");
        yield return Row(new Day08Playground(), "102816", "100011612");
        yield return Row(new Day08Playground { UseTestInput = true }, "40", "25272");
        yield return Row(new Day09MovieTheater(), "4752484112", "1465767840");
        yield return Row(new Day09MovieTheater { UseTestInput = true }, "50", "24");
        yield return Row(new Day10Factory(), "475", "18273");
        yield return Row(new Day10Factory { UseTestInput = true }, "7", "33");
        yield return Row(new Day11Reactor(), "613", "372918445876116");
        yield return Row(new Day11Reactor { UseTestInput = true }, "5", "0");
        yield return Row(new Day12ChristmasTreeFarm(), "490", "");
        yield return Row(new Day12ChristmasTreeFarm { UseTestInput = true }, "3", "");
    }
}
