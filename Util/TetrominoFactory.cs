

public static class TetrominoFactory
{
    private static readonly Random random = new();
    
    private static (Point[] shape, Colors colors, MinoType type)[] shapes = new[]
    {
        (new Point[]{new(-1, 0), new(0, 0), new(1, 0), new(2, 0)},
            new Colors(Color.Cyan, Color.Black), MinoType.I), // I
        
        (new Point[]{new(0, 0), new(1, 0), new(0, 1), new(1, 1)},
            new Colors(Color.Yellow, Color.Black), MinoType.O), // O
        
        (new Point[]{new(0, 0), new(-1, 1), new(0, 1), new(1, 1)},
            new Colors(Color.Magenta, Color.Black), MinoType.T), // T 
        
        (new Point[]{new(0, 0), new(1, 0), new(-1, 1), new(0, 1)},
            new Colors(Color.Green, Color.Black), MinoType.S), // S
        
        (new Point[]{new(-1, 0), new(0, 0), new(0, 1), new(1, 1)},
            new Colors(Color.Red, Color.Black), MinoType.Z), // Z
        
        (new Point[]{new(-1, 0), new(-1, 1), new(0, 1), new(1, 1)},
            new Colors(Color.Blue, Color.Black), MinoType.J), // J
        
        (new Point[]{new(1, 0), new(-1, 1), new(0, 1), new(1, 1)},
            new Colors(Color.DarkYellow, Color.Black), MinoType.L), // L
        
        
        // new Point[]{new(0, 0), new(1, 0), new(0, 1), new(1, 1)}, // O
        // new Point[]{new(0, 0), new(-1, 1), new(0, 1), new(1, 1)}, // T
        // new Point[]{new(0, 0), new(1, 0), new(-1, 1), new(0, 1)}, // S
        // new Point[]{new(-1, 0), new(0, 0), new(0, 1), new(1, 1)}, // Z
        // new Point[]{new(-1, 0), new(-1, 1), new(0, 1), new(1, 1)}, // J
        // new Point[]{new(1, 0), new(-1, 1), new(0, 1), new(1, 1)}, // L
        
    };
    
    public static (Point[] shape, Colors color, MinoType type) CreateRandom()
    {
        return shapes[random.Next(shapes.Length)];
    }

    public static (Point[] shape, Colors color, MinoType type) FindShape(MinoType type)
    {
        return shapes[(int)type];
    }

}