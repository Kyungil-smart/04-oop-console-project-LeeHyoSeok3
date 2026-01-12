public class Tetromino
{
    public Point Position;
    public Point[] Blocks;
    public Colors Colors;
    public MinoType Type;

    public Tetromino(Point[] blocks, Colors colors, Point position, MinoType type)
    {
        Blocks = blocks;
        Position = position;
        Colors = colors;
        Type = type;
    }

    public Tetromino(Tetromino other)
    {
        Blocks = (Point[])other.Blocks.Clone();
        Colors =  other.Colors;
        Position = other.Position;
        Type = other.Type;
    }
}