public static class TetrominoFactory
{
    private static readonly Random random = new();

    private static (Point[], Colors)[] shapes = new[]
    {
        (new Point[]{new(-1, 0), new(0, 0), new(1, 0), new(2, 0)},
            new Colors(Color.Cyan, Color.Black)), // I
        
        (new Point[]{new(0, 0), new(1, 0), new(0, 1), new(1, 1)},
            new Colors(Color.Yellow, Color.Black)), // O
        
        (new Point[]{new(0, 0), new(-1, 1), new(0, 1), new(1, 1)},
            new Colors(Color.Magenta, Color.Black)), // T 
        
        (new Point[]{new(0, 0), new(1, 0), new(-1, 1), new(0, 1)},
            new Colors(Color.Green, Color.Black)), // S
        
        (new Point[]{new(-1, 0), new(0, 0), new(0, 1), new(1, 1)},
            new Colors(Color.Red, Color.Black)), // Z
        
        (new Point[]{new(-1, 0), new(-1, 1), new(0, 1), new(1, 1)},
            new Colors(Color.Blue, Color.Black)), // J
        
        (new Point[]{new(1, 0), new(-1, 1), new(0, 1), new(1, 1)},
            new Colors(Color.DarkYellow, Color.Black)), // L
        
        
        // new Point[]{new(0, 0), new(1, 0), new(0, 1), new(1, 1)}, // O
        // new Point[]{new(0, 0), new(-1, 1), new(0, 1), new(1, 1)}, // T
        // new Point[]{new(0, 0), new(1, 0), new(-1, 1), new(0, 1)}, // S
        // new Point[]{new(-1, 0), new(0, 0), new(0, 1), new(1, 1)}, // Z
        // new Point[]{new(-1, 0), new(-1, 1), new(0, 1), new(1, 1)}, // J
        // new Point[]{new(1, 0), new(-1, 1), new(0, 1), new(1, 1)}, // L
        
    };
    
    public static (Point[] shape, Colors color) CreateRandom()
    {
        return shapes[random.Next(shapes.Length)];
    }

}