public class Board
{
    public const int Width = 20;
    public const int Height = 20;

    private readonly Cell[,] _cells = new Cell[Height, Width];

    public Board()
    {
        Clear();
    }

    public void Clear()
    {
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                _cells[y, x] = new Cell('.');
            }    
        }
    }
    
    public bool IsEmpty(int x, int y)
    {
        if (x < 0 || x + 1 >= Width) return false;
        if (y < 0 || y >= Height) return false;

        // ██ 두 칸 모두 비어 있어야 함
        return _cells[y, x]._char == '.' && _cells[y, x + 1]._char == '.';
    }

    public void CanRotate(Tetromino t)
    {
        foreach (var b in t.Blocks)
        {
            int x = t.Position.X + (b.X * 2);
            int y = t.Position.Y + b.Y;
            
            if (x < 0 || x + 1 >= Width || y < 0 || y >= Height)
            {
                int px = x - Math.Clamp(x, 0, Width - 2);
                int py = y - Math.Clamp(y, 0, Height - 1);
                
                t.Position.X += -px;
                t.Position.Y += -py;
            }
        }
    }
    
    public bool CanPlace(Tetromino t, int dx, int dy)
    {
        foreach (var b in t.Blocks)
        {
            int x = t.Position.X + (b.X * 2);
            int y = t.Position.Y + b.Y;

            if (!IsEmpty(x + dx, y + dy))
                return false;
        }
        return true;
    }

    public void Lock(Tetromino t)
    {
        foreach (var b in t.Blocks)
        {
            int x = t.Position.X + (b.X * 2);
            int y = t.Position.Y + b.Y;

            if (x < 0 || x + 1 >= Width || y < 0 || y >= Height)
                continue;

            _cells[y, x] = new Cell('█', t.Colors.fg, t.Colors.bg);
            _cells[y, x + 1] = new Cell('█', t.Colors.fg, t.Colors.bg);
            
            // _cells[y, x]._char     = '█';
            // _cells[y, x + 1]._char = '█';
        }
    }

    public int ClearCompletedLines()
    {
        int cleared = 0;

        for (int y = Height - 1; y >= 0; y--)
        {
            bool full = true;

            for (int x = 0; x < Width; x += 2)
            {
                if (_cells[y, x]._char == '.')
                {
                    full = false;
                    break;
                }
            }

            if (full)
            {
                cleared++;

                for (int row = y; row > 0; row--)
                for (int x = 0; x < Width; x++)
                    _cells[row, x] = _cells[row - 1, x];

                for (int x = 0; x < Width; x++)
                    _cells[0, x] = new Cell('.');

                y++;
            }
        }

        return cleared;
    }

    public Cell[,] GetCells() => _cells;
}