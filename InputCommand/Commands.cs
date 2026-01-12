public class StartGameCommand : ICommand
{
    private GameModel _model;
    private SceneManager _sceneManager;
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
    private GameModel _model;
    private TetrominoManager _manager;
    public ArrowUpCommand(GameModel gameModel)
    {
        _model = gameModel;
        _manager = _model.TetrominoManager;
    }

    public void Execute()
    {
        _manager.RotateTetromino(_model);
    }
}

public class ArrowDownCommand : ICommand
{
    private TetrominoManager _manager;
    public ArrowDownCommand(GameModel gameModel) =>_manager = gameModel.TetrominoManager;
    public void Execute() => _manager.FallTimer = _manager.FallInterval;
}

public class ArrowLeftCommand : ICommand
{
    private GameModel _model;
    private TetrominoManager _manager;
    public ArrowLeftCommand(GameModel gameModel)
    {
        _model = gameModel;
        _manager = _model.TetrominoManager;
    }
    public void Execute()
    {
        _manager.MoveTetromino(_model, -2);
    }
}

public class ArrowRightCommand : ICommand
{
    private GameModel _model;
    private TetrominoManager _manager;
    public ArrowRightCommand(GameModel gameModel)
    {
        _model = gameModel;
        _manager = _model.TetrominoManager;
    }
    public void Execute()
    {
        _manager.MoveTetromino(_model, 2);
    }
}

public class SpaceBarCommand : ICommand
{
    private TetrominoManager _manager;
    public SpaceBarCommand(GameModel gameModel)
    {
        _manager = gameModel.TetrominoManager;
    }
    public void Execute()
    {
        _manager.DropTetromino();
    }
}

public class HoldCommand : ICommand
{
    private GameModel _model;
    private TetrominoManager _manager;
    
    public HoldCommand(GameModel gameModel)
    {
        _model = gameModel;
        _manager = _model.TetrominoManager;
    }
    
    public void Execute()
    {
        _manager.SwapHold(_model.Board);
        if((_manager.FallInterval / 2) < _manager.FallTimer)
            _manager.FallTimer = _manager.FallInterval / 2;
    }
}