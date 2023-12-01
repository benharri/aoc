namespace AOC.Common;

public class DefaultDictionary<TKey, TValue> : Dictionary<TKey, TValue> where TKey : notnull
{
    public TValue? DefaultValue;

    public new TValue? this[TKey key]
    {
        get => TryGetValue(key, out var t) ? t : DefaultValue;
        set
        {
            if (value != null) base[key] = value;
        }
    }
}

public class Tree<T>(Tree<T>.Node root)
{
    public class Node(Node? parent, T data)
    {
        public Node? Parent { get; private set; } = parent;
        public T Data { get; set; } = data;
        private List<Node?> Children { get; } = [];

        public Node? Left
        {
            get => Children.Count >= 1 ? Children[0] : null;

            set
            {
                if (value != null) value.Parent = this;
                if (Children.Count >= 1) Children[0] = value;
                else Children.Add(value);
            }
        }

        public Node? Right
        {
            get => Children.Count >= 2 ? Children[1] : null;

            set
            {
                if (value != null) value.Parent = this;
                switch (Children.Count)
                {
                    case >= 2:
                        Children[1] = value;
                        break;
                    case 0:
                        Children.Add(null);
                        break;
                }
                Children.Add(value);
            }
        }

        public int DistanceToParent(Node nodeParent)
        {
            var current = this;
            var dist = 0;
            while (current != nodeParent)
            {
                dist++;
                current = current?.Parent;
            }

            return dist;
        }
    }

    public Node Root { get; } = root;
}

public class Dijkstra<TCell, TMid> where TCell : notnull
{
    public Func<TCell, IEnumerable<TMid>>? Neighbors;
    public Func<TMid, int>? Distance;
    public Func<TCell, TMid, TCell>? Cell;

    public int ComputeFind(TCell start, TCell target, Func<TCell, bool>? valid = null)
    {
        valid ??= _ => true;
        var dist = new DefaultDictionary<TCell, int> { DefaultValue = int.MaxValue, [start] = 0 };
        var seen = new HashSet<TCell>();
        var queue = new PriorityQueue<TCell, int>();
        queue.Enqueue(start, 0);
        while (queue.Count > 0)
        {
            var cell = queue.Dequeue();
            if (seen.Contains(cell)) continue;
            var current = dist[cell];
            if (Equals(cell, target)) return current;
            seen.Add(cell);
            foreach (var neighbor in Neighbors!(cell))
            {
                var other = Cell!(cell, neighbor);
                if (!valid(other)) continue;
                var weight = Distance!(neighbor);
                if (!seen.Contains(other)) queue.Enqueue(other, current + weight);
                if (current + weight < dist[other])
                {
                    dist[other] = current + weight;
                }
            }
        }

        return -1;
    }
}
