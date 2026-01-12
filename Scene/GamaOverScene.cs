public class GameOverScene : IScene
{
    private InputManager _inputManager;
    private SceneManager _sceneManager;
    private GameModel _gameModel;
        
    
    public GameOverScene(SceneManager sceneManager,
        GameModel gameModel,
        InputManager inputManager)
    {
        _inputManager = inputManager;
        _sceneManager = sceneManager;
        _gameModel = gameModel;
    }
    
    public void Enter(RenderState state)
    {
        state.ClearDrawRequest();
        for (int y = 0; y < Renderer._height; y++)
            state.DrawRequest(0, y, new string(' ', Renderer._width));
        
        state.DrawRequest(0, 0, "GameOver");
        state.DrawRequest(0, 1, "Press enter to Retry");
        
        _inputManager.BindCommand
        (ConsoleKey.Enter, new StartGameCommand(
            _sceneManager,
            _gameModel,
            _inputManager));
    }

    public void Exit(RenderState state)
    {
        _inputManager.UnBindCommand(ConsoleKey.Enter);
    }

    public void Update(double deltaTime)
    {
    }

    public void Render(RenderState state)
    {

    }
}