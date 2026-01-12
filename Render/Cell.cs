public class Cell
{
    public char _char;
    public ConsoleColor _fg;
    public ConsoleColor _bg;

    public Cell(char c, Color fg = Color.White, Color bg = Color.Black)
    {
        _char = c;
        _fg = fg;
        _bg = bg;
    }

    public Cell(Cell other)
    {
        _char = other._char;
        _fg = other._fg;
        _bg = other._bg;
    }
}