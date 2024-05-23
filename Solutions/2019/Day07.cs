namespace Solutions._2019;

public sealed class Day07() : Day(2019, 7, "Amplification Circuit")
{
    private readonly IntCodeVM[] _amplifiers = new IntCodeVM[5];

    public override void ProcessInput()
    {
        for (var i = 0; i < 5; i++) _amplifiers[i] = new(Input.First());
    }

    public override object Part1()
    {
        var largest = 0L;

        foreach (var phaseSeq in Enumerable.Range(0, 5).Permute())
        {
            var i = 0L;
            foreach (var (vm, phase) in _amplifiers.Zip(phaseSeq))
            {
                vm.Reset();
                vm.Run(phase, i);
                i = vm.Result;
            }

            if (i > largest)
                largest = i;
        }

        return largest;
    }

    public override object Part2()
    {
        var largest = 0L;

        foreach (var phaseSeq in Enumerable.Range(5, 5).Permute())
        {
            var i = 0L;
            foreach (var (vm, phase) in _amplifiers.Zip(phaseSeq))
            {
                vm.Reset();
                vm.AddInput(phase);
            }

            var vms = new Queue<IntCodeVM>(_amplifiers);
            while (vms.Count > 0)
            {
                var vm = vms.Dequeue();
                var haltType = vm.Run(i);
                if (haltType == IntCodeVM.HaltType.Waiting)
                    vms.Enqueue(vm);
                i = vm.Result;
            }

            if (i > largest)
                largest = i;
        }

        return largest;
    }
}
