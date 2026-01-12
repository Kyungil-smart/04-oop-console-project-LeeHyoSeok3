public class TetrominoManager
{
    public Tetromino Current { get; private set; }
    public Tetromino Ghost { get; private set; }
    public double FallTimer { get; set; } = 1d;
    public double FallInterval = 1d;

    public bool TrySpawn(Board board)
    {
        var shape = TetrominoFactory.CreateRandom();
        Tetromino Next = new Tetromino(shape.shape, shape.color,
            new Point(Board.Width / 2, 0));
        
        if (!board.CanPlace(Next, 0, 0))
        {
            Current = null;
            Ghost = null;
            return false;
        }

        Current = Next;
        Ghost = new Tetromino(Next);
        GhostUpdate(board);
        return true;
    }

    public void Update(double deltaTime, Board board, UIModel ui)
    {
        FallTimer += deltaTime;
        if (FallTimer < FallInterval) return;
        FallTimer -= FallInterval;
        
        if (Current == null)
            if (!TrySpawn(board))
                return;

        if (board.CanPlace(Current, 0, 1)) {
            Current.Position.Y++;
            GhostUpdate(board);
        }
        else {
            board.Lock(Current);
            ui.SumScore(board.ClearCompletedLines());
            ui.LevelScaling(ref FallInterval);
            TrySpawn(board);
        }
    }

    public void GhostUpdate(Board board)
    {
        if (Ghost == null) return;

        Ghost.Position = Current.Position;
        Ghost.Blocks = (Point[])Current.Blocks.Clone();
        
        for (int i = 0; i <= Board.Height; i++)
        {
            if (!board.CanPlace(Ghost, 0, i + 1))
            {
                Ghost.Position.Y = Math.Clamp(Ghost.Position.Y + i, 0, Board.Height);
                break;
            }
        }
    }
}