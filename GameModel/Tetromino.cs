public class Tetromino
{
    public Point Position;
    public Point[] Blocks;
    public Colors Colors;

    public Tetromino(Point[] blocks, Colors colors, Point position)
    {
        Blocks = blocks;
        Position = position;
        Colors = colors;
    }

    public Tetromino(Tetromino other)
    {
        Blocks = (Point[])other.Blocks.Clone();
        Position = other.Position;
    }
}