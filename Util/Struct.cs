public struct Colors
{
    public Color fg;
    public Color bg;

    public Colors(Color fg, Color bg)
    {
        this.fg = fg;
        this.bg = bg;
    }
}

public struct Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }
}