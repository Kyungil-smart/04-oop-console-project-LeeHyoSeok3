public class TetrominoManager
{
    public Tetromino Current { get; private set; }
    public Tetromino Next { get; private set; }
    public Tetromino Hold { get; private set; }
    public Tetromino Ghost { get; private set; }
    public double FallTimer { get; set; } = 1d;
    public double FallInterval = 1d;

    public bool Update(double deltaTime, Board board, UIModel ui)
    {
        if ((FallTimer += deltaTime) < FallInterval) return true;
        FallTimer -= FallInterval;
        bool gameState = true;

        if (Current == null)
            gameState = SpawnCurrent(board);
        
        if (Next == null) SpawnNext();
        
        if (board.CanPlace(Current, 0, 1))
        {
            Current.Position.Y++;
            GhostUpdate(board);
        }
        else
        {
            board.Lock(Current);
            ui.SumScore(board.ClearCompletedLines());
            ui.LevelScaling(ref FallInterval);
            gameState = SpawnCurrent(board);
            SpawnNext();
        }

        return gameState;
    }
    
    private bool SpawnCurrent(Board board)
    {
        if (Next == null) SpawnNext();

        Current = Next;
        Ghost = new Tetromino(Next);

        Current.Position = new Point(Board.Width / 2, 0);
        GhostUpdate(board);

        Next = null;

        if (!board.CanPlace(Current, 0, 0)) return false;

        return true;
    }

    public void Clear()
    {
        Current = null;
        Ghost = null;
        Next = null;
        Hold = null;
        FallTimer = 0d;
        FallInterval = 1d;
    }

    private void SpawnNext()
    {
        var shape = TetrominoFactory.CreateRandom();
        Next = new Tetromino(shape.shape, shape.color,
            new Point(32, 3), shape.type);
    }

    private void SpawnHold(Board board)
    {
        Hold = new Tetromino(Current);
        Hold.Position = new Point(23, 3);

        SpawnCurrent(board);
        SpawnNext();
    }

    public void SwapHold(Board board)
    {
        if (Hold == null) SpawnHold(board);
        else
        {
            (Hold.Blocks, Current.Blocks) = (Current.Blocks, Hold.Blocks);
            (Hold.Colors, Current.Colors) = (Current.Colors, Hold.Colors);
            (Hold.Type, Current.Type) = (Current.Type, Hold.Type);
        }
        
        Hold.Blocks = TetrominoFactory.FindShape(Hold.Type).shape;
        board.CanRotate(Current);
        GhostUpdate(board);
    }

    public void RotateTetromino(GameModel _model)
    {
        if (Current == null) return;
        
        var b = Current.Blocks;
        Current.Blocks = new Point[] {
            new Point(-b[0].Y, b[0].X),
            new Point(-b[1].Y, b[1].X),
            new Point(-b[2].Y, b[2].X),
            new Point(-b[3].Y, b[3].X)};
        
        _model.Board.CanRotate(Current);
        GhostUpdate(_model.Board);
    }

    public void DropTetromino()
    { 
        if(Current == null || Ghost == null) return;
        
        Current.Position = Ghost.Position;
        FallTimer = FallInterval;
    }

    public void MoveTetromino(GameModel _model, int dir)
    {
        if (Current == null) return;
        if(_model.Board.CanPlace(Current, dir, 0))
            Current.Position.X += dir;
        
        GhostUpdate(_model.Board);
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