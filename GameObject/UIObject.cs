public class UIObject : IGameObject
{
    private readonly UIModel _ui;

    public UIObject(UIModel ui)
    {
        _ui = ui;
    }

    public void Update() { }

    public void Render(RenderState state)
    {
        state.DrawRequest(21, 0, $"SCORE: {_ui.Score}");
        state.DrawRequest(21, 1, $"LEVEL: {_ui.Level}");
    }
}