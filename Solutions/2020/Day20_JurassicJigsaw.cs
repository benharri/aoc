namespace Solutions._2020;

/// <summary>
/// Day 20: <a href="https://adventofcode.com/2020/day/20" />
/// </summary>
public sealed partial class Day20JurassicJigsaw() : Day(2020, 20, "Jurassic Jigsaw")
{
    [GeneratedRegex("(?<=#.{77})#.{4}#{2}.{4}#{2}.{4}#{3}(?=.{77}#.{2}#.{2}#.{2}#.{2}#.{2}#)")]
    private static partial Regex MonsterRegex();

    public override object Part1()
    {
        var puzzlePieces = ParsePiecesFromInput(Input.ToArray());
        var connections = FindConnections(puzzlePieces);
        var cornerIds = connections
            .Select(pair => (piece: pair.Key, nrConnections: pair.Value.Count))
            .Where(connection => connection.nrConnections == 2)
            .Select(connection => connection.piece.Id);

        return cornerIds.Aggregate((double)1, (curr, next) => curr * next);
    }

    public override object Part2()
    {
        var puzzlePieces = ParsePiecesFromInput(Input.ToArray());
        var connections = FindConnections(puzzlePieces);
        var puzzle = ComposePuzzle(connections);
        var lines = ExtractImagesFromPuzzle(puzzle);
        var numberSeaMonsters = TagSeaMonsters(lines);
        var numberWaves = lines.Select(l => l.Count(c => c == '#')).Sum();
        return numberWaves - numberSeaMonsters * 15;
    }

    private static IEnumerable<PuzzlePiece> ParsePiecesFromInput(string[] input)
    {
        const int pieceHeight = 12;
        for (var i = pieceHeight; i <= input.Length + 1; i += pieceHeight)
        {
            var lBound = i - pieceHeight;
            var uBound = i - 1;
            yield return PuzzlePiece.CreatePieceFromString(input[lBound..uBound]);
        }
    }

    private static Dictionary<PuzzlePiece, List<PuzzlePiece>> FindConnections(IEnumerable<PuzzlePiece> puzzlePieces)
    {
        var sides = new Dictionary<string, PuzzlePiece>();
        var connections = new Dictionary<PuzzlePiece, List<PuzzlePiece>>();

        foreach (var piece in puzzlePieces)
        foreach (var (original, flipped) in piece.SidesWithFlippedPaired.Value)
        {
            if (sides.TryGetValue(original, out var side))
            {
                AddConnection(piece, side);
            }
            else if (sides.TryGetValue(flipped, out var otherPiece))
            {
                AddConnection(piece, otherPiece);
            }
            else
            {
                sides.Add(original, piece);
                sides.Add(flipped, piece);
            }
        }

        return connections;

        void AddConnection(PuzzlePiece p1, PuzzlePiece p2)
        {
            if (!connections.ContainsKey(p1)) connections.Add(p1, []);
            if (!connections.ContainsKey(p2)) connections.Add(p2, []);
            connections[p1].Add(p2);
            connections[p2].Add(p1);
        }
    }

    private static PuzzlePiece[][] ComposePuzzle(Dictionary<PuzzlePiece, List<PuzzlePiece>> connections)
    {
        var sideSize = (int)Math.Sqrt(connections.Count);
        var unprocessed = connections.Keys.ToHashSet();

        // step 0: initialize puzzle array
        var puzzle = new PuzzlePiece[sideSize][];
        for (var i = 0; i < puzzle.Length; i++) puzzle[i] = new PuzzlePiece[sideSize];

        // step1: take one of the angles (this will be our 0,0) and find its true orientation/side
        var angle = connections.First(x => x.Value.Count == 2).Key;
        puzzle[0][0] = RotatePieceToMatch00Position(angle, connections);
        unprocessed.Remove(angle);

        // step2: fill the first column
        for (var i = 1; i < puzzle.Length; i++)
        {
            var previousPiece = puzzle[i - 1][0];
            var bottomPiece = connections[previousPiece]
                .Where(p => unprocessed.Contains(p))
                .First(p => p.AllSidesWithFlipped.Value.Contains(previousPiece.BottomSide.Value));
            puzzle[i][0] = bottomPiece.TransformSoTopMatchesWith(previousPiece.BottomSide.Value);
            unprocessed.Remove(bottomPiece);
        }

        // step3: fill each row using the first value as starting point
        foreach (var t in puzzle)
            for (var c = 1; c < t.Length; c++)
            {
                var previousPiece = t[c - 1];
                var rightPiece = connections[previousPiece]
                    .Where(p => unprocessed.Contains(p))
                    .First(p => p.AllSidesWithFlipped.Value.Contains(previousPiece.RightSide.Value));
                t[c] = rightPiece.TransformSoLeftMatchesWith(previousPiece.RightSide.Value);
                unprocessed.Remove(rightPiece);
            }

        return puzzle;
    }

    private static char[][] ExtractImagesFromPuzzle(IEnumerable<PuzzlePiece[]> puzzle)
    {
        const int pieceHeight = 10;
        var lines = new List<string>();

        foreach (var t in puzzle)
            for (var line = 1; line < pieceHeight - 1; line++)
                lines.Add(t.Aggregate("", (current, t1) => current + t1.GetLine(line)[1..^1]));

        return lines.Select(line => line.ToCharArray()).ToArray();
    }

    private static PuzzlePiece RotatePieceToMatch00Position(
        PuzzlePiece angle,
        IReadOnlyDictionary<PuzzlePiece, List<PuzzlePiece>> connections)
    {
        var conn1 = connections[angle][0];
        var conn2 = connections[angle][1];

        var angleSides = angle.Sides.Value.ToHashSet();
        var connectionsSides = conn1.SidesWithFlippedPaired.Value
            .Concat(conn2.SidesWithFlippedPaired.Value)
            .SelectMany(t => new[] { t.Item1, t.Item2 });

        angleSides.ExceptWith(connectionsSides);
        return angle.RotateUntilSidesCorrespondToTopLeft(angleSides);
    }

    private static int TagSeaMonsters(char[][] lines)
    {
        var images = new List<char[][]> { lines };
        lines = lines.Rotate();
        images.Add(lines);
        lines = lines.Rotate();
        images.Add(lines);
        lines = lines.Rotate();
        images.Add(lines);
        lines = lines.FlipHorizontally();
        images.Add(lines);
        lines = lines.Rotate();
        images.Add(lines);
        lines = lines.Rotate();
        images.Add(lines);
        lines = lines.Rotate();
        images.Add(lines);

        return images.Select(CountSeaMonstersInImage).Sum();
    }

    private static int CountSeaMonstersInImage(char[][] lines)
    {
        var singleLine = lines.Aggregate("", (curr, next) => curr + new string(next));
        return MonsterRegex().Matches(singleLine).Count;
    }

    private class PuzzlePiece
    {
        public readonly long Id;
        private readonly char[][] _piece;
        private readonly Lazy<string> _topSide;
        public readonly Lazy<string> RightSide;
        public readonly Lazy<string> BottomSide;
        private readonly Lazy<string> _leftSide;
        public readonly Lazy<string[]> Sides;
        public readonly Lazy<HashSet<string>> AllSidesWithFlipped;
        public readonly Lazy<(string, string)[]> SidesWithFlippedPaired;

        public static PuzzlePiece CreatePieceFromString(string[] pieceWithId)
        {
            var id = long.Parse(pieceWithId[0][5..^1]);
            var piece = pieceWithId[1..].Select(x => x.ToCharArray()).ToArray();
            return new(id, piece);
        }

        private PuzzlePiece(long id, char[][] piece)
        {
            Id = id;
            _piece = piece;

            _topSide = new(() => new(piece[0]));
            RightSide = new(() => new(piece.Select(line => line[^1]).ToArray()));
            BottomSide = new(() => new(piece[^1].Reverse().ToArray()));
            _leftSide = new(() => new(piece.Select(line => line[0]).Reverse().ToArray()));
            Sides = new(() => [_topSide.Value, RightSide.Value, BottomSide.Value, _leftSide.Value]);
            SidesWithFlippedPaired = new(() => CalculateSidesWithFlipped(this));
            AllSidesWithFlipped = new(() => CalculateAllSidesWithFlipped(this));
        }

        public override bool Equals(object? obj) => obj is PuzzlePiece piece && Id == piece.Id;
        public override int GetHashCode() => HashCode.Combine(Id);
        public override string ToString() => Id.ToString();

        public PuzzlePiece TransformSoTopMatchesWith(string sideToMatch) =>
            TransformSoSideMatchesWith(new(sideToMatch.Reverse().ToArray()), p => p._topSide.Value);

        public PuzzlePiece TransformSoLeftMatchesWith(string sideToMatch) =>
            TransformSoSideMatchesWith(new(sideToMatch.Reverse().ToArray()), p => p._leftSide.Value);

        private PuzzlePiece TransformSoSideMatchesWith(string sideToMatch, Func<PuzzlePiece, string> getSide)
        {
            var side = getSide(this);
            if (side == sideToMatch) return this;
            return Sides.Value.ToHashSet().Contains(sideToMatch)
                ? Rotated().TransformSoSideMatchesWith(sideToMatch, getSide)
                : Flipped().TransformSoSideMatchesWith(sideToMatch, getSide);
        }

        public PuzzlePiece RotateUntilSidesCorrespondToTopLeft(IReadOnlySet<string> sides) =>
            sides.Contains(_leftSide.Value) && sides.Contains(_topSide.Value)
                ? this
                : Rotated().RotateUntilSidesCorrespondToTopLeft(sides);

        private PuzzlePiece Rotated() => new(Id, _piece.Rotate());

        private PuzzlePiece Flipped() => new(Id, _piece.FlipHorizontally());

        public string GetLine(int l) => new(_piece[l]);

        private static (string, string)[] CalculateSidesWithFlipped(PuzzlePiece piece) =>
        [
            (piece._topSide.Value, new(piece._topSide.Value.Reverse().ToArray())),
            (piece.RightSide.Value, new(piece.RightSide.Value.Reverse().ToArray())),
            (piece.BottomSide.Value, new(piece.BottomSide.Value.Reverse().ToArray())),
            (piece._leftSide.Value, new(piece._leftSide.Value.Reverse().ToArray())),
        ];

        private static HashSet<string> CalculateAllSidesWithFlipped(PuzzlePiece piece) =>
            piece.Sides.Value.Concat(piece.Sides.Value.Select(s => new string(s.Reverse().ToArray()))).ToHashSet();
    }
}
