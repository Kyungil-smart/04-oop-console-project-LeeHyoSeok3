using ConsoleProject_Tetris;

public class TitleScene : IScene
{
    private InputManager _inputManager;
    private SceneManager _sceneManager;
    private GameModel _gameModel;
        
    
    public TitleScene(SceneManager sceneManager,
                      GameModel gameModel,
                      InputManager inputManager)
    {
        _inputManager = inputManager;
        _sceneManager = sceneManager;
        _gameModel = gameModel;
    }
    
    public void Enter(RenderState state)
    {
        var logo = AscciObject.Logo;
        for (int i = 0; i < logo.Length; i++)
            state.DrawRequest(0,i,logo[i]);
        
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