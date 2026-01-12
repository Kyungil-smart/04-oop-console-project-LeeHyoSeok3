public record DrawObject(int x, int y, string text, Color fg, Color bg);

public class RenderState
{
    public List<DrawObject> Requests { get; private set; } = new();
    
    public void DrawRequest(int x, int y, string text,
        Color fg = Color.White, Color bg = Color.Black)
    { 
        Requests.Add(new DrawObject(x, y, text, fg, bg));  
    }

    public void DrawRequest(int x, int y, char text,
        Color fg = Color.White, Color bg = Color.Black)
    {
        Requests.Add(new DrawObject(x, y, text.ToString(), fg, bg));
    }
    
    public void ClearDrawRequest() => Requests.Clear();
}
