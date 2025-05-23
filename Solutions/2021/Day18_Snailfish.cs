namespace Solutions._2021;

/// <summary>
/// Day 18: <a href="https://adventofcode.com/2021/day/18"/>
/// </summary>
public sealed class Day18Snailfish() : Day(2021, 18, "Snailfish")
{
    private List<string>? _fishes;

    public override void ProcessInput() => _fishes = Input.ToList();

    private static Tree<int> Parse(string input)
    {
        var cursor = 0;
        return new(ParseFish(null, input, ref cursor));

        static Tree<int>.Node ParseFish(Tree<int>.Node? parent, string input, ref int cursor)
        {
            if (input[cursor] != '[') return new(parent, input[cursor++] - '0');

            var node = new Tree<int>.Node(parent, -1);
            cursor++;
            node.Left = ParseFish(node, input, ref cursor);
            cursor++;
            node.Right = ParseFish(node, input, ref cursor);
            cursor++;
            return node;
        }
    }

    private static Tree<int> Add(Tree<int> a, Tree<int> b)
    {
        var reduced = new Tree<int>(new(null, -1) { Left = a.Root, Right = b.Root });
        Reduce(reduced);
        return reduced;
    }

    private static Tree<int>.Node? SiblingOf(Tree<int>.Node from, Func<Tree<int>.Node, Tree<int>.Node?> move1,
        Func<Tree<int>.Node, Tree<int>.Node?> move2)
    {
        var current = from;
        while (current.Parent != null)
        {
            if (move1(current.Parent) == current)
            {
                var other = move2(current.Parent);
                while (other?.Data == -1)
                    other = move1(other) ?? move2(other);
                return other;
            }

            current = current.Parent;
        }

        return null;
    }

    private static void Reduce(Tree<int> tree)
    {
        var changed = true;
        while (changed)
        {
            changed = false;
            while (ReduceRecurse(tree.Root, Explode)) changed = true;
            if (ReduceRecurse(tree.Root, Split)) changed = true;
        }

        return;

        bool Explode(Tree<int> t, Tree<int>.Node node)
        {
            if (node.Data != -1 || node.DistanceToParent(t.Root) < 4) return false;
            var left = SiblingOf(node, n => n.Right, n => n.Left);
            if (left != null) left.Data += node.Left!.Data;
            var right = SiblingOf(node, n => n.Left, n => n.Right);
            if (right != null) right.Data += node.Right!.Data;

            node.Left = null;
            node.Right = null;
            node.Data = 0;
            return true;
        }

        bool Split(Tree<int> t, Tree<int>.Node node)
        {
            if (node.Data < 10) return false;
            node.Left = new(node, node.Data / 2);
            node.Right = new(node, node.Data / 2 + node.Data % 2);
            node.Data = -1;
            return true;
        }

        bool ReduceRecurse(Tree<int>.Node node, Func<Tree<int>, Tree<int>.Node, bool> reducer)
        {
            if (reducer(tree, node)) return true;
            if (node.Left != null && ReduceRecurse(node.Left, reducer)) return true;
            return node.Right != null && ReduceRecurse(node.Right, reducer);
        }
    }

    private static long Magnitude(Tree<int>.Node? node)
    {
        if (node?.Data >= 0) return node.Data;
        return 3 * Magnitude(node?.Left) + 2 * Magnitude(node?.Right);
    }

    public override object Part1() =>
        Magnitude(_fishes!.Skip(1).Aggregate(Parse(_fishes!.First()), (a, b) => Add(a, Parse(b))).Root);

    public override object Part2()
    {
        var best = 0L;
        for (var i = 0; i < _fishes!.Count; i++)
            best = _fishes
                .Where((_, j) => i != j)
                .Select(t => Add(Parse(_fishes[i]), Parse(t)))
                .Select(result => Magnitude(result.Root))
                .Prepend(best)
                .Max();

        return best;
    }
}
