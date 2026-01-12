public class StartGameCommand : ICommand
{
    private SceneManager _sceneManager;
    private GameModel _model;
    private InputManager _inputManager;
    
    public StartGameCommand(SceneManager sceneManager,
        GameModel model,
        InputManager inputManager) 
    {
        _sceneManager = sceneManager;
        _model = model;
        _inputManager = inputManager;
    }
    
    public void Execute() 
    {
        _sceneManager.ChangeScene(new StageScene(_model, _inputManager));
    }
}

public class ArrowUpCommand : ICommand
{
    private TetrominoManager _tetroManager;
    private GameModel _model;
    public ArrowUpCommand(GameModel gameModel)
    {
        _model = gameModel;
        _tetroManager = _model.TetrominoManager;
    }

    public void Execute()
    {
        Tetromino Current = _tetroManager.Current;
        if (Current == null) return;
        
        var b = Current.Blocks;
        Current.Blocks = new Point[] {
            new Point(-b[0].Y, b[0].X),
            new Point(-b[1].Y, b[1].X),
            new Point(-b[2].Y, b[2].X),
            new Point(-b[3].Y, b[3].X)};
        
        _model.Board.CanRotate(Current);
        _tetroManager.GhostUpdate(_model.Board);
    }
}

public class ArrowDownCommand : ICommand
{
    private TetrominoManager _tetroManager;
    public ArrowDownCommand(GameModel gameModel) =>_tetroManager = gameModel.TetrominoManager;
    public void Execute() => _tetroManager.FallTimer = _tetroManager.FallInterval;
}

public class ArrowLeftCommand : ICommand
{
    private TetrominoManager _tetroManager;
    private GameModel _model;
    public ArrowLeftCommand(GameModel gameModel)
    {
        _model = gameModel;
        _tetroManager = _model.TetrominoManager;
    }
    public void Execute()
    {
        Tetromino Current = _tetroManager.Current;
        
        if (Current == null) return;
        if(_model.Board.CanMove(Current, -2))
            Current.Position.X -= 2;
        
        _tetroManager.GhostUpdate(_model.Board);
    }
}

public class ArrowRightCommand : ICommand
{
    private TetrominoManager _tetroManager;
    private GameModel _model;
    public ArrowRightCommand(GameModel gameModel)
    {
        _model = gameModel;
        _tetroManager = _model.TetrominoManager;
    }
    public void Execute()
    {
        Tetromino Current = _tetroManager.Current;
        
        if (Current == null) return;
        if(_model.Board.CanMove(Current, 2))
            Current.Position.X += 2;
        
        _tetroManager.GhostUpdate(_model.Board);
    }
}

public class SpaceBarCommand : ICommand
{
    private GameModel _model;
    private TetrominoManager _tetroManager;
    public SpaceBarCommand(GameModel gameModel)
    {
        _model = gameModel;
        _tetroManager = _model.TetrominoManager;
    }
    public void Execute()
    {
        Tetromino Current = _tetroManager.Current;
        Tetromino Ghost = _tetroManager.Ghost;
        if(Current == null || Ghost == null) return;
        
        Current.Position = Ghost.Position;
        _tetroManager.FallTimer = _tetroManager.FallInterval;
    }
}