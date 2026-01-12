public class UIModel
{
    public int Score { get; private set; }
    public int Level  { get; private set; }
    public int ClearCount  { get; private set; }
    public int Limit { get; private set; } = 5;


    public void SumScore(int value)
    {
        ClearCount += value;
        Score += 100 * (value * value);
    }

    public void LevelScaling(ref double fallInterval)
    {
        if (ClearCount >= Limit)
        {
            Level++;
            Limit += Limit;
            
            fallInterval = Math.Clamp(fallInterval -= 0.1d, 0.1d, 1d);
        }
    }

    public void Clear()
    {
        Score = 0;
        Level = 1;
        ClearCount = 0;
        Limit = 5;
    }
}