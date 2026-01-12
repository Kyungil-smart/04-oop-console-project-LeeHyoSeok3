

public class StageScene : IScene
{
    private GameModel _gameModel;
    private InputManager _inputManager;
    private GameObjectManager _gom = new();

    public StageScene(GameModel gameModel,
        InputManager inputManager)
    {
        _gameModel = gameModel;
        _inputManager = inputManager;
    }
    
    public void Enter(RenderState state)
    {
        state.ClearDrawRequest();
        for (int y = 0; y < Renderer._height; y++)
            state.DrawRequest(0, y, new string(' ', Renderer._width));
        
        _gom.Clear();
        _gom.Add(new BoardView(_gameModel.Board));
        _gom.Add(new UIObject(_gameModel.UI));
        _gom.Add(new GhostView(_gameModel.TetrominoManager));
        _gom.Add(new HoldView(_gameModel.TetrominoManager));
        _gom.Add(new NextView(_gameModel.TetrominoManager));
        _gom.Add(new TetrominoView(_gameModel.TetrominoManager));
        
        _inputManager.BindCommand(ConsoleKey.UpArrow, new ArrowUpCommand(_gameModel));
        _inputManager.BindCommand(ConsoleKey.DownArrow, new ArrowDownCommand(_gameModel));
        _inputManager.BindCommand(ConsoleKey.LeftArrow, new ArrowLeftCommand(_gameModel));
        _inputManager.BindCommand(ConsoleKey.RightArrow, new ArrowRightCommand(_gameModel));
        _inputManager.BindCommand(ConsoleKey.Spacebar, new SpaceBarCommand(_gameModel));
        _inputManager.BindCommand(ConsoleKey.Z, new HoldCommand(_gameModel));
    }

    public void Exit(RenderState state)
    {
        _gom.Clear();
        _gameModel.Clear();
        _inputManager.ClearCommands();
    }

    
    public void Update(double deltaTime)
    {
        _gameModel.Update(deltaTime);
        _gom.Update();
    }
    
    public void Render(RenderState state)
    {
        state.ClearDrawRequest();
        _gom.Render(state);
    }
}