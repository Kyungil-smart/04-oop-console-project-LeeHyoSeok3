public class GhostView : IGameObject
{
    private readonly TetrominoManager _manager;

    public GhostView(TetrominoManager manager)
    {
        _manager = manager;
    }

    public void Update()
    {
        
    }

    public void Render(RenderState state)
    {
        var t = _manager.Ghost;
        if (t == null) return;
        
        foreach (var b in t.Blocks)
        {
            int x = t.Position.X + (b.X * 2);
            int y = t.Position.Y + b.Y;
            
            state.DrawRequest(x, y, "░░");
        }
    }
}