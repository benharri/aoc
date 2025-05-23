namespace Solutions._2019;

/// <summary>
/// Day 23: <a href="https://adventofcode.com/2019/day/23"/>
/// </summary>
public sealed class Day23CategorySix() : Day(2019, 23, "Category Six")
{
    public override object Part1()
    {
        var vms = Enumerable.Range(0, 50)
            .Select((_, i) =>
            {
                var vm = new IntCodeVM(Input.First());
                vm.Run(i);
                return vm;
            }).ToList();

        while (true)
            foreach (var vm in vms)
            {
                while (vm.Output.Count != 0)
                {
                    var destination = (int)vm.Result;
                    var x = vm.Result;
                    var y = vm.Result;

                    if (destination == 255) return y;

                    vms[destination].Run(x, y);
                }

                vm.Run(-1);
            }
    }

    public override object Part2()
    {
        var vms = Enumerable.Range(0, 50)
            .Select((_, i) =>
            {
                var vm = new IntCodeVM(Input.First());
                vm.Run(i);
                return vm;
            }).ToList();

        long natX = 0, natY = 0, lastYSent = -1;

        while (true)
        {
            var numIdle = 0;
            foreach (var vm in vms)
            {
                var isIdle = true;
                while (vm.Output.Count != 0)
                {
                    var destination = (int)vm.Result;
                    var x = vm.Result;
                    var y = vm.Result;

                    if (destination == 255)
                    {
                        natX = x;
                        natY = y;
                    }
                    else
                    {
                        vms[destination].Run(x, y);
                    }

                    isIdle = false;
                }

                vm.Run(-1);
                if (isIdle) numIdle++;
            }

            if (numIdle == 50)
            {
                if (natY == lastYSent) return natY;
                vms[0].Run(natX, natY);
                lastYSent = natY;
            }
        }
    }
}
