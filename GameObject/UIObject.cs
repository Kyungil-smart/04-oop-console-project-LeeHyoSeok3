public class UIObject : IGameObject
{
    private readonly UIModel _ui;

    public UIObject(UIModel ui)
    {
        _ui = ui;
    }

    public void Update()
    {
    }

    public void Render(RenderState state)
    {
        state.DrawRequest(21, 1, "|HOLD|");
        state.DrawRequest(30, 1, "|NEXT|");
        
        var Stat = AscciObject.Stat;
        for (int i = 0; i < Stat.Length; i++)
            state.DrawRequest(21, 7 + i, Stat[i]);
        
        var Help = AscciObject.Help;
        for (int i = 0; i < Help.Length; i++)
            state.DrawRequest(21, 12 + i, Help[i]);
        
        state.DrawRequest(29, 8, $"{_ui.Score}");
        state.DrawRequest(29, 9, $"{_ui.Level}");
    }
}