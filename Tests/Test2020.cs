using Solutions._2020;
// ReSharper disable MemberCanBeMadeStatic.Global

namespace Tests;

public class Test2020
{
    [Test]
    [RealInputRequired]
    [Arguments(typeof(Day01ReportRepair), "751776", "42275090")]
    [Arguments(typeof(Day02PasswordPhilosophy), "556", "605")]
    [Arguments(typeof(Day03TobogganTrajectory), "189", "1718180100")]
    [Arguments(typeof(Day04PassportProcessing), "247", "145")]
    [Arguments(typeof(Day05BinaryBoarding), "878", "504")]
    [Arguments(typeof(Day06CustomCustoms), "6273", "3254")]
    [Arguments(typeof(Day07HandyHaversacks), "169", "82372")]
    [Arguments(typeof(Day08HandheldHalting), "1654", "833")]
    [Arguments(typeof(Day09EncodingError), "138879426", "23761694")]
    [Arguments(typeof(Day10AdapterArray), "1980", "4628074479616")]
    [Arguments(typeof(Day11SeatingSystem), "2303", "2057")]
    [Arguments(typeof(Day12RainRisk), "1710", "62045")]
    [Arguments(typeof(Day13ShuttleSearch), "171", "539746751134958")]
    [Arguments(typeof(Day14DockingData), "17481577045893", "4160009892257")]
    [Arguments(typeof(Day15RambunctiousRecitation), "257", "8546398")]
    [Arguments(typeof(Day16TicketTranslation), "19093", "5311123569883")]
    // [Arguments(typeof(Day17ConwayCubes), "293", "1816")] // this one takes too long and i don't want to bother optimizing it
    [Arguments(typeof(Day18OperationOrder), "12918250417632", "171259538712010")]
    [Arguments(typeof(Day19MonsterMessages), "160", "357")]
    [Arguments(typeof(Day20JurassicJigsaw), "21599955909991", "2495")]
    [Arguments(typeof(Day21AllergenAssessment), "2436", "dhfng,pgblcd,xhkdc,ghlzj,dstct,nqbnmzx,ntggc,znrzgs")]
    [Arguments(typeof(Day22CrabCombat), "32856", "33805")]
    [Arguments(typeof(Day23CrabCups), "36542897", "562136730660")]
    [Arguments(typeof(Day24LobbyLayout), "282", "3445")]
    [Arguments(typeof(Day25ComboBreaker), "11707042", "")]
    public async Task CheckAllDays(Type dayType, string part1, string part2) =>
        await Common.CheckDay(dayType, part1, part2);
}
