public class BoardView : IGameObject
{
    private readonly Board _board;

    public BoardView(Board board)
    {
        _board = board;
    }

    public void Update()
    {
    }

    public void Render(RenderState state)
    {
        var cells = _board.GetCells();
        for (int y = 0; y < Board.Height; y++)
        {
            for (int x = 0; x < Board.Width; x++)
            {
                Cell cell = cells[y, x];
                state.DrawRequest(x, y, cell._char, cell._fg, cell._bg);
            }
        }
    }
}