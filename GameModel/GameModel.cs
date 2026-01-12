public class GameModel
{
    private SceneManager _sceneManager;
    private InputManager _inputManager;
    
    public Board Board { get; } = new();
    public TetrominoManager TetrominoManager { get; } = new();
    public UIModel UI { get; } = new();

    public GameModel(SceneManager sceneManager, InputManager inputManager)
    {
        _sceneManager = sceneManager;
        _inputManager = inputManager;
    }
    
    public void Update(double deltaTime)
    {
        if (!TetrominoManager.Update(deltaTime, Board, UI))
        {
            _sceneManager.ChangeScene(new GameOverScene(_sceneManager, this, _inputManager));
        }
    }

    public void Clear()
    {
        TetrominoManager.Clear();
        Board.Clear();
        UI.Clear();
    }
}