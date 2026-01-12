using System.Diagnostics;

public class MainGame
{
    private bool isRunning = false;
    private SceneManager sceneManager;
    private InputManager inputManager;
    private GameModel _gameModel;
    private Renderer renderer;

    public MainGame()
    {
        sceneManager = new();
        inputManager = new();
        _gameModel = new(sceneManager, inputManager);
        renderer = new();
        
        sceneManager.ChangeScene(new TitleScene(
            sceneManager,
            _gameModel,
            inputManager));
    }

    private void GameUpdate(double deltaTime)
    {
        inputManager.InputUpdate();
        sceneManager.Update(deltaTime);
        sceneManager.Render(renderer);
    }

    public void Run()
    {
        const double frameTime = 1000.0 / 120;
        Stopwatch stopwatch = Stopwatch.StartNew();
        double previousTime = stopwatch.Elapsed.TotalMilliseconds;

        while (!isRunning)
        {
            double currentTime = stopwatch.Elapsed.TotalMilliseconds;
            double elapsedMs = currentTime - previousTime;
            previousTime = currentTime;

            double deltaTime = elapsedMs / 1000.0;
            
            GameUpdate(deltaTime);

            double sleepTime = frameTime - elapsedMs;
            if (sleepTime > 0)
                Thread.Sleep((int)sleepTime);
        }
    }
}