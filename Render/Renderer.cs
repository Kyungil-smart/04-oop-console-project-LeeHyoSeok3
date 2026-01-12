

public class Renderer
{
    static public readonly int _width = 100;
    static public readonly int _height = 100;
    private Cell[,] _frontBuffer;
    private Cell[,] _backBuffer;

    public Renderer()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;
        Console.SetWindowSize(_width, _height);
        Console.SetBufferSize(_width, _height);
        Console.Clear();
        Console.CursorVisible = false;
        
        _frontBuffer = new Cell[_height, _width];
        _backBuffer = new Cell[_height, _width];

        for (int y = 0; y < _height; y++)
        {
            for (int x = 0; x < _width; x++)
            {
                _frontBuffer[y, x] = new Cell(' ');
                _backBuffer[y, x] = new Cell(' ');
            }
        }
        
        Present();
    }

    // private Cell[,] CreateBuffer()
    // {
    //     var buffer = new Cell[_height, _width];
    //
    //     for (int y = 0; y < _height; y++)
    //     {
    //         for (int x = 0; x < _width; x++)
    //             buffer[y, x] = new Cell(' ');
    //     }
    //     
    //     return buffer;
    // }

    private void ClearBuffer(Cell[,] buffer)
    {
        for (int y = 0; y < _height; y++)
        {
            for (int x = 0; x < _width; x++)
                buffer[y, x]._char = ' ';    
        }
    }

    // public void Clear() => ClearBuffer(_backBuffer);

    public void DrawText(int x, int y, string text, Color fg, Color bg)
    {
        for (int i = 0; i < text.Length; i++)
        {
            int px = x + i;
            if (px < 0 || px >= _width || y < 0 || y >= _height)
                continue;
            
            _backBuffer[y, px] = new Cell(text[i], fg, bg);
        }
    }

    public void Present()
    {
        for (int y = 0; y < _height; y++)
        {
            for (int x = 0; x < _width; x++)
            {
                Cell newCell = _backBuffer[y, x];
                Cell oldCell = _frontBuffer[y, x];

                if (newCell._char != oldCell._char ||
                    newCell._fg != oldCell._fg ||
                    newCell._bg != oldCell._bg)
                {
                    Console.SetCursorPosition(x, y);
                    Console.ForegroundColor = newCell._fg;
                    Console.BackgroundColor = newCell._bg;
                    Console.Write(newCell._char);
                    _frontBuffer[y, x] = new Cell(newCell);
                }
            }
        }
    }
}