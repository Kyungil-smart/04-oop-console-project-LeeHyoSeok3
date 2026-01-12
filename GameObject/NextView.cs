public class NextView : IGameObject
{
    private readonly TetrominoManager _manager;

    public NextView(TetrominoManager manager)
    {
        _manager = manager;
    }

    public void Update()
    {
        
    }

    public void Render(RenderState state)
    {
        var t = _manager.Next;
        if (t == null) return;
        
        for(int i = 0; i < 2; i++)
            state.DrawRequest(30, 3 + i, "         ");    
        
        foreach (var b in t.Blocks)
        {
            int x = t.Position.X + (b.X * 2);
            int y = t.Position.Y + b.Y;
            
            state.DrawRequest(x, y, "██", t.Colors.fg, t.Colors.bg);
        }
    }
}