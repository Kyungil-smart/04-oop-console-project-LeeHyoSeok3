public class GameModel
{
    public Board Board { get; } = new();
    public TetrominoManager TetrominoManager { get; } = new();
    public UIModel UI { get; } = new();

    public void Update(double deltaTime)
    {
        TetrominoManager.Update(deltaTime, Board, UI);
    }
}