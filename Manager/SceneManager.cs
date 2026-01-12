public class SceneManager
{
    private IScene _scene;
    private RenderState _renderState = new();
    
    public void ChangeScene(IScene next)
    {
        _scene?.Exit(_renderState);
        _scene = next;
        _scene.Enter(_renderState);
    }

    public void Update(double deltaTime)
    {
        _scene.Update(deltaTime);
    }

    public void Render(Renderer renderer)
    {
        foreach (var cmd in _renderState.Requests)
            renderer.DrawText(cmd.x, cmd.y, cmd.text, cmd.fg, cmd.bg);
        
        _scene.Render(_renderState);
        
        renderer.Present();
    }
}